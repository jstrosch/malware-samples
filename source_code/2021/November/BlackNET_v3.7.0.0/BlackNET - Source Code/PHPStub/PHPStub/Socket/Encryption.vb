Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace HTTPSocket
    Public Module Encryption
        Public Function AES_Encrypt(ByVal plainText As String, ByVal secretKey As String) As String
            Dim encryptedPassword As Byte()
            Using outputStream As MemoryStream = New MemoryStream()
                Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
                Using cryptoStream As CryptoStream = New CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim inputBuffer() As Byte = Encoding.Unicode.GetBytes(plainText)
                    cryptoStream.Write(inputBuffer, 0, inputBuffer.Length)
                    cryptoStream.FlushFinalBlock()
                    encryptedPassword = outputStream.ToArray()
                End Using
            End Using
            Return Convert.ToBase64String(encryptedPassword)
        End Function

        Public Function AES_Decrypt(ByVal encryptedData As String, ByVal secretKey As String) As String
            Dim plainText As String = Nothing
            Using inputStream As MemoryStream = New MemoryStream(Convert.FromBase64String(encryptedData))
                Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
                Using cryptoStream As CryptoStream = New CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read)
                    Dim outputBuffer(0 To CType(inputStream.Length - 1, Integer)) As Byte
                    Dim readBytes As Integer = cryptoStream.Read(outputBuffer, 0, CType(inputStream.Length, Integer))
                    plainText = Encoding.Unicode.GetString(outputBuffer, 0, readBytes)
                End Using
            End Using
            Return plainText
        End Function

        Private Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged
            Const salt As String = "vtzh8iRo6puxnQpZHCoMBqGSyyj2zZfw9uejNzwpKH8y284imD35gsmUeAXle1DNOMSAsBcrqINQGbsk"
            Const keySize As Integer = 256

            Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt))
            Dim algorithm As RijndaelManaged = New RijndaelManaged()
            algorithm.KeySize = keySize
            algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
            algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
            algorithm.Padding = PaddingMode.PKCS7
            Return algorithm
        End Function
    End Module
End Namespace