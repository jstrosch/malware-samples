Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text

Namespace ChromeRecovery
    Class AesGcm
        Public Function Decrypt(ByVal key As Byte(), ByVal iv As Byte(), ByVal aad As Byte(), ByVal cipherText As Byte(), ByVal authTag As Byte()) As Byte()
            Dim hAlg As IntPtr = OpenAlgorithmProvider(BCrypt.BCRYPT_AES_ALGORITHM, BCrypt.MS_PRIMITIVE_PROVIDER, BCrypt.BCRYPT_CHAIN_MODE_GCM)
            Dim hKey As IntPtr, keyDataBuffer As IntPtr = ImportKey(hAlg, key, hKey)
            Dim plainText As Byte()
            Dim authInfo = New BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag)

            Using authInfo
                Dim ivData As Byte() = New Byte(MaxAuthTagSize(hAlg) - 1) {}
                Dim plainTextSize As Integer = 0
                Dim status As UInteger = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, authInfo, ivData, ivData.Length, Nothing, 0, plainTextSize, &H0)
                If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptDecrypt() (get size) failed with status code: {0}", status))
                plainText = New Byte(plainTextSize - 1) {}
                status = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, authInfo, ivData, ivData.Length, plainText, plainText.Length, plainTextSize, &H0)
                If status = BCrypt.STATUS_AUTH_TAG_MISMATCH Then Throw New CryptographicException("BCrypt.BCryptDecrypt(): authentication tag mismatch")
                If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptDecrypt() failed with status code:{0}", status))
            End Using

            BCrypt.BCryptDestroyKey(hKey)
            Marshal.FreeHGlobal(keyDataBuffer)
            BCrypt.BCryptCloseAlgorithmProvider(hAlg, &H0)
            Return plainText
        End Function

        Private Function MaxAuthTagSize(ByVal hAlg As IntPtr) As Integer
            Dim tagLengthsValue As Byte() = GetProperty(hAlg, BCrypt.BCRYPT_AUTH_TAG_LENGTH)
            Return BitConverter.ToInt32({tagLengthsValue(4), tagLengthsValue(5), tagLengthsValue(6), tagLengthsValue(7)}, 0)
        End Function

        Private Function OpenAlgorithmProvider(ByVal alg As String, ByVal provider As String, ByVal chainingMode As String) As IntPtr
            Dim hAlg As IntPtr = IntPtr.Zero
            Dim status As UInteger = BCrypt.BCryptOpenAlgorithmProvider(hAlg, alg, provider, &H0)
            If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptOpenAlgorithmProvider() failed with status code:{0}", status))
            Dim chainMode As Byte() = Encoding.Unicode.GetBytes(chainingMode)
            status = BCrypt.BCryptSetAlgorithmProperty(hAlg, BCrypt.BCRYPT_CHAINING_MODE, chainMode, chainMode.Length, &H0)
            If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptSetAlgorithmProperty(BCrypt.BCRYPT_CHAINING_MODE, BCrypt.BCRYPT_CHAIN_MODE_GCM) failed with status code:{0}", status))
            Return hAlg
        End Function

        Private Function ImportKey(ByVal hAlg As IntPtr, ByVal key As Byte(), <Out> ByRef hKey As IntPtr) As IntPtr
            Dim objLength As Byte() = GetProperty(hAlg, BCrypt.BCRYPT_OBJECT_LENGTH)
            Dim keyDataSize As Integer = BitConverter.ToInt32(objLength, 0)
            Dim keyDataBuffer As IntPtr = Marshal.AllocHGlobal(keyDataSize)
            Dim keyBlob As Byte() = Concat(BCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC, BitConverter.GetBytes(&H1), BitConverter.GetBytes(key.Length), key)
            Dim status As UInteger = BCrypt.BCryptImportKey(hAlg, IntPtr.Zero, BCrypt.BCRYPT_KEY_DATA_BLOB, hKey, keyDataBuffer, keyDataSize, keyBlob, keyBlob.Length, &H0)
            If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptImportKey() failed with status code:{0}", status))
            Return keyDataBuffer
        End Function

        Private Function GetProperty(ByVal hAlg As IntPtr, ByVal name As String) As Byte()
            Dim size As Integer = 0
            Dim status As UInteger = BCrypt.BCryptGetProperty(hAlg, name, Nothing, 0, size, &H0)
            If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptGetProperty() (get size) failed with status code:{0}", status))
            Dim value As Byte() = New Byte(size - 1) {}
            status = BCrypt.BCryptGetProperty(hAlg, name, value, value.Length, size, &H0)
            If status <> BCrypt.ERROR_SUCCESS Then Throw New CryptographicException(String.Format("BCrypt.BCryptGetProperty() failed with status code:{0}", status))
            Return value
        End Function

        Public Function Concat(ParamArray arrays As Byte()()) As Byte()
            Dim len As Integer = 0

            For Each array As Byte() In arrays
                If array Is Nothing Then Continue For
                len += array.Length
            Next

            Dim result As Byte() = New Byte(len - 1 + 1 - 1) {}
            Dim offset As Integer = 0

            For Each array As Byte() In arrays
                If array Is Nothing Then Continue For
                Buffer.BlockCopy(array, 0, result, offset, array.Length)
                offset += array.Length
            Next

            Return result
        End Function
    End Class
End Namespace

