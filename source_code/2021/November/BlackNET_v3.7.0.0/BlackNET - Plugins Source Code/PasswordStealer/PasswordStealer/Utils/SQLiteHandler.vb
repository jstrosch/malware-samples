Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.CompilerServices
Public Class SqLiteHandler
    Private db_bytes As Byte()
    Private mEncoding As ULong
    Private field_names As String()
    Private master_table_entries As sqlite_master_entry()
    Private page_size As UShort
    Private SQLDataTypeSize As Byte() = New Byte() {0, 1, 2, 3, 4, 6, 8, 8, 0, 0}
    Private table_entries As table_entry()

    Public Sub New(baseName As String)
        If File.Exists(baseName) Then
            FileSystem.FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.[Shared], -1)
            Dim str As String = Strings.Space(CInt(FileSystem.LOF(1)))
            FileSystem.FileGet(1, str, -1L, False)
            FileSystem.FileClose(New Integer() {1})
            Me.db_bytes = System.Text.Encoding.Default.GetBytes(str)
            If String.Compare(System.Text.Encoding.Default.GetString(Me.db_bytes, 0, 15), "SQLite format 3", StringComparison.Ordinal) <> 0 Then
                Throw New Exception("Not a valid SQLite 3 Database File")
            End If
            If Me.db_bytes(&H34) <> 0 Then
                Throw New Exception("Auto-vacuum capable database is not supported")
            End If
            Me.page_size = CUShort(Me.ConvertToInteger(&H10, 2))
            Me.mEncoding = Me.ConvertToInteger(&H38, 4)
            If Decimal.Compare(New Decimal(Me.mEncoding), Decimal.Zero) = 0 Then
                Me.mEncoding = 1L
            End If
            Me.ReadMasterTable(100L)
        End If
    End Sub

    Private Function ConvertToInteger(startIndex As Integer, Size As Integer) As ULong
        If (Size > 8) Or (Size = 0) Then
            Return 0L
        End If
        Dim num2 As ULong = 0L
        Dim num4 As Integer = Size - 1
        For i As Integer = 0 To num4
            num2 = (num2 << 8) Or Me.db_bytes(startIndex + i)
        Next
        Return num2
    End Function

    Private Function CVL(startIndex As Integer, endIndex As Integer) As Long
        endIndex += 1
        Dim buffer As Byte() = New Byte(7) {}
        Dim num4 As Integer = endIndex - startIndex
        Dim flag As Boolean = False
        If (num4 = 0) Or (num4 > 9) Then
            Return 0L
        End If
        If num4 = 1 Then
            buffer(0) = CByte(Me.db_bytes(startIndex) And &H7F)
            Return BitConverter.ToInt64(buffer, 0)
        End If
        If num4 = 9 Then
            flag = True
        End If
        Dim num2 As Integer = 1
        Dim num3 As Integer = 7
        Dim index As Integer = 0
        If flag Then
            buffer(0) = Me.db_bytes(endIndex - 1)
            endIndex -= 1
            index = 1
        End If
        Dim num7 As Integer = startIndex
        Dim i As Integer = endIndex - 1
        While i >= num7
            If (i - 1) >= startIndex Then
                buffer(index) = CByte((CByte(Me.db_bytes(i) >> ((num2 - 1) And 7)) And (CInt(&HFF) >> num2)) Or CByte(Me.db_bytes(i - 1) << (num3 And 7)))
                num2 += 1
                index += 1
                num3 -= 1
            ElseIf Not flag Then
                buffer(index) = CByte(CByte(Me.db_bytes(i) >> ((num2 - 1) And 7)) And (CInt(&HFF) >> num2))
            End If
            i += -1
        End While
        Return BitConverter.ToInt64(buffer, 0)
    End Function

    Public Function GetRowCount() As Integer
        Return Me.table_entries.Length
    End Function

    Public Function GetTableNames() As String()
        Dim strArray2 As String() = Nothing
        Dim index As Integer = 0
        Dim num3 As Integer = Me.master_table_entries.Length - 1
        For i As Integer = 0 To num3
            If Me.master_table_entries(i).item_type = "table" Then
                strArray2 = DirectCast(Utils.CopyArray(DirectCast(strArray2, Array), New String(index) {}), String())
                strArray2(index) = Me.master_table_entries(i).item_name
                index += 1
            End If
        Next
        Return strArray2
    End Function

    Public Function GetValue(row_num As Integer, field As Integer) As String
        If row_num >= Me.table_entries.Length Then
            Return Nothing
        End If
        If field >= Me.table_entries(row_num).content.Length Then
            Return Nothing
        End If
        Return Me.table_entries(row_num).content(field)
    End Function

    Public Function GetValue(row_num As Integer, field As String) As String
        Dim num As Integer = -1
        Dim length As Integer = Me.field_names.Length - 1
        For i As Integer = 0 To length
            If Me.field_names(i).ToLower().CompareTo(field.ToLower()) = 0 Then
                num = i
                Exit For
            End If
        Next
        If num = -1 Then
            Return Nothing
        End If
        Return Me.GetValue(row_num, num)
    End Function

    Private Function GVL(startIndex As Integer) As Integer
        If startIndex > Me.db_bytes.Length Then
            Return 0
        End If
        Dim num3 As Integer = startIndex + 8
        For i As Integer = startIndex To num3
            If i > (Me.db_bytes.Length - 1) Then
                Return 0
            End If
            If (Me.db_bytes(i) And &H80) <> &H80 Then
                Return i
            End If
        Next
        Return (startIndex + 8)
    End Function

    Private Function IsOdd(value As Long) As Boolean
        Return ((value And 1L) = 1L)
    End Function

    Private Sub ReadMasterTable(Offset As ULong)
        If Me.db_bytes(CInt(Offset)) = 13 Then
            Dim num2 As UShort = Convert.ToUInt16(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(Offset), 3D)), 2)), Decimal.One))
            Dim length As Integer = 0
            If Me.master_table_entries IsNot Nothing Then
                length = Me.master_table_entries.Length
                Me.master_table_entries = DirectCast(Utils.CopyArray(DirectCast(Me.master_table_entries, Array), New sqlite_master_entry((Me.master_table_entries.Length + num2)) {}), sqlite_master_entry())
            Else
                Me.master_table_entries = New sqlite_master_entry(num2) {}
            End If
            Dim num13 As Integer = num2
            For i As Integer = 0 To num13
                Dim num As ULong = Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(Offset), 8D), New Decimal(i * 2))), 2)
                If Decimal.Compare(New Decimal(Offset), 100D) <> 0 Then
                    num += Offset
                End If
                Dim endIndex As Integer = Me.GVL(CInt(num))
                Dim num7 As Long = Me.CVL(CInt(num), endIndex)
                Dim num6 As Integer = Me.GVL(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(endIndex), New Decimal(num))), Decimal.One)))
                Me.master_table_entries(length + i).row_id = Me.CVL(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(endIndex), New Decimal(num))), Decimal.One)), num6)
                num = Convert.ToUInt64(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(num6), New Decimal(num))), Decimal.One))
                endIndex = Me.GVL(CInt(num))
                num6 = endIndex
                Dim num5 As Long = Me.CVL(CInt(num), endIndex)
                Dim numArray As Long() = New Long(4) {}
                Dim index As Integer = 0
                Do
                    endIndex = num6 + 1
                    num6 = Me.GVL(endIndex)
                    numArray(index) = Me.CVL(endIndex, num6)
                    If numArray(index) > 9L Then
                        If Me.IsOdd(numArray(index)) Then
                            numArray(index) = CLng(Math.Round(CDbl(CDbl(numArray(index) - 13L) / 2.0)))
                        Else
                            numArray(index) = CLng(Math.Round(CDbl(CDbl(numArray(index) - 12L) / 2.0)))
                        End If
                    Else
                        numArray(index) = Me.SQLDataTypeSize(CInt(numArray(index)))
                    End If
                    index += 1
                Loop While index <= 4
                If Decimal.Compare(New Decimal(Me.mEncoding), Decimal.One) = 0 Then
                    Me.master_table_entries(length + i).item_type = System.Text.Encoding.Default.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(New Decimal(num), New Decimal(num5))), CInt(numArray(0)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 2D) = 0 Then
                    Me.master_table_entries(length + i).item_type = System.Text.Encoding.Unicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(New Decimal(num), New Decimal(num5))), CInt(numArray(0)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 3D) = 0 Then
                    Me.master_table_entries(length + i).item_type = System.Text.Encoding.BigEndianUnicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(New Decimal(num), New Decimal(num5))), CInt(numArray(0)))
                End If
                If Decimal.Compare(New Decimal(Me.mEncoding), Decimal.One) = 0 Then
                    Me.master_table_entries(length + i).item_name = System.Text.Encoding.Default.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0)))), CInt(numArray(1)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 2D) = 0 Then
                    Me.master_table_entries(length + i).item_name = System.Text.Encoding.Unicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0)))), CInt(numArray(1)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 3D) = 0 Then
                    Me.master_table_entries(length + i).item_name = System.Text.Encoding.BigEndianUnicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0)))), CInt(numArray(1)))
                End If
                Me.master_table_entries(length + i).root_num = CLng(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0))), New Decimal(numArray(1))), New Decimal(numArray(2)))), CInt(numArray(3))))
                If Decimal.Compare(New Decimal(Me.mEncoding), Decimal.One) = 0 Then
                    Me.master_table_entries(length + i).sql_statement = System.Text.Encoding.Default.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0))), New Decimal(numArray(1))), New Decimal(numArray(2))), New Decimal(numArray(3)))), CInt(numArray(4)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 2D) = 0 Then
                    Me.master_table_entries(length + i).sql_statement = System.Text.Encoding.Unicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0))), New Decimal(numArray(1))), New Decimal(numArray(2))), New Decimal(numArray(3)))), CInt(numArray(4)))
                ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 3D) = 0 Then
                    Me.master_table_entries(length + i).sql_statement = System.Text.Encoding.BigEndianUnicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num5)), New Decimal(numArray(0))), New Decimal(numArray(1))), New Decimal(numArray(2))), New Decimal(numArray(3)))), CInt(numArray(4)))
                End If
            Next
        ElseIf Me.db_bytes(CInt(Offset)) = 5 Then
            Dim num11 As UShort = Convert.ToUInt16(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(Offset), 3D)), 2)), Decimal.One))
            Dim num14 As Integer = num11
            For j As Integer = 0 To num14
                Dim startIndex As UShort = CUShort(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(Offset), 12D), New Decimal(j * 2))), 2))
                If Decimal.Compare(New Decimal(Offset), 100D) = 0 Then
                    Me.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(New Decimal(Me.ConvertToInteger(startIndex, 4)), Decimal.One), New Decimal(Me.page_size))))
                Else
                    Me.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(New Decimal(Me.ConvertToInteger(CInt(Offset + startIndex), 4)), Decimal.One), New Decimal(Me.page_size))))
                End If
            Next
            Me.ReadMasterTable(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(Offset), 8D)), 4)), Decimal.One), New Decimal(Me.page_size))))
        End If
    End Sub

    Public Function ReadTable(TableName As String) As Boolean
        Dim index As Integer = -1
        Dim length As Integer = Me.master_table_entries.Length - 1
        For i As Integer = 0 To length
            If String.Compare(Me.master_table_entries(i).item_name.ToLower(), TableName.ToLower(), StringComparison.Ordinal) = 0 Then
                index = i
                Exit For
            End If
        Next
        If index = -1 Then
            Return False
        End If
        Dim strArray As String() = Me.master_table_entries(index).sql_statement.Substring(Me.master_table_entries(index).sql_statement.IndexOf("(", StringComparison.Ordinal) + 1).Split(New Char() {","c})
        Dim num6 As Integer = strArray.Length - 1
        For j As Integer = 0 To num6
            strArray(j) = (strArray(j)).TrimStart()
            Dim num4 As Integer = strArray(j).IndexOf(" ", StringComparison.Ordinal)
            If num4 > 0 Then
                strArray(j) = strArray(j).Substring(0, num4)
            End If
            If strArray(j).IndexOf("UNIQUE", StringComparison.Ordinal) = 0 Then
                Exit For
            End If
            Me.field_names = DirectCast(Utils.CopyArray(DirectCast(Me.field_names, Array), New String(j) {}), String())
            Me.field_names(j) = strArray(j)
        Next
        Return Me.ReadTableFromOffset(CULng((Me.master_table_entries(index).root_num - 1L) * Me.page_size))
    End Function

    Private Function ReadTableFromOffset(offset As ULong) As Boolean
        If Me.db_bytes(CInt(offset)) = 13 Then
            Dim num2 As Integer = Convert.ToInt32(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(offset), 3D)), 2)), Decimal.One))
            Dim length As Integer = 0
            If Me.table_entries IsNot Nothing Then
                length = Me.table_entries.Length
                Me.table_entries = DirectCast(Utils.CopyArray(DirectCast(Me.table_entries, Array), New table_entry((Me.table_entries.Length + num2)) {}), table_entry())
            Else
                Me.table_entries = New table_entry(num2) {}
            End If
            Dim num16 As Integer = num2
            For i As Integer = 0 To num16
                Dim _fieldArray As record_header_field() = Nothing
                Dim num As ULong = Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(offset), 8D), New Decimal(i * 2))), 2)
                If Decimal.Compare(New Decimal(offset), 100D) <> 0 Then
                    num += offset
                End If
                Dim endIndex As Integer = Me.GVL(CInt(num))
                Dim num9 As Long = Me.CVL(CInt(num), endIndex)
                Dim num8 As Integer = Me.GVL(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(endIndex), New Decimal(num))), Decimal.One)))
                Me.table_entries(length + i).row_id = Me.CVL(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(endIndex), New Decimal(num))), Decimal.One)), num8)
                num = Convert.ToUInt64(Decimal.Add(Decimal.Add(New Decimal(num), Decimal.Subtract(New Decimal(num8), New Decimal(num))), Decimal.One))
                endIndex = Me.GVL(CInt(num))
                num8 = endIndex
                Dim num7 As Long = Me.CVL(CInt(num), endIndex)
                Dim num10 As Long = Convert.ToInt64(Decimal.Add(Decimal.Subtract(New Decimal(num), New Decimal(endIndex)), Decimal.One))
                Dim j As Integer = 0
                While num10 < num7
                    _fieldArray = DirectCast(Utils.CopyArray(DirectCast(_fieldArray, Array), New record_header_field(j) {}), record_header_field())
                    endIndex = num8 + 1
                    num8 = Me.GVL(endIndex)
                    _fieldArray(j).type = Me.CVL(endIndex, num8)
                    If _fieldArray(j).type > 9L Then
                        _fieldArray(j).size = If(Me.IsOdd(_fieldArray(j).type), CLng(Math.Round(CDbl(CDbl(_fieldArray(j).type - 13L) / 2.0))), CLng(Math.Round(CDbl(CDbl(_fieldArray(j).type - 12L) / 2.0))))
                    Else
                        _fieldArray(j).size = Me.SQLDataTypeSize(CInt(_fieldArray(j).type))
                    End If
                    num10 = (num10 + (num8 - endIndex)) + 1L
                    j += 1
                End While
                Me.table_entries(length + i).content = New String((_fieldArray.Length - 1)) {}
                Dim num4 As Integer = 0
                Dim num17 As Integer = _fieldArray.Length - 1
                For k As Integer = 0 To num17
                    If _fieldArray(k).type > 9L Then
                        If Not Me.IsOdd(_fieldArray(k).type) Then
                            If Decimal.Compare(New Decimal(Me.mEncoding), Decimal.One) = 0 Then
                                Me.table_entries(length + i).content(k) = System.Text.Encoding.Default.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num7)), New Decimal(num4))), CInt(_fieldArray(k).size))
                            ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 2D) = 0 Then
                                Me.table_entries(length + i).content(k) = System.Text.Encoding.Unicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num7)), New Decimal(num4))), CInt(_fieldArray(k).size))
                            ElseIf Decimal.Compare(New Decimal(Me.mEncoding), 3D) = 0 Then
                                Me.table_entries(length + i).content(k) = System.Text.Encoding.BigEndianUnicode.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num7)), New Decimal(num4))), CInt(_fieldArray(k).size))
                            End If
                        Else
                            Me.table_entries(length + i).content(k) = System.Text.Encoding.Default.GetString(Me.db_bytes, Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num7)), New Decimal(num4))), CInt(_fieldArray(k).size))
                        End If
                    Else
                        Me.table_entries(length + i).content(k) = Conversions.ToString(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(num), New Decimal(num7)), New Decimal(num4))), CInt(_fieldArray(k).size)))
                    End If
                    num4 += CInt(_fieldArray(k).size)
                Next
            Next
        ElseIf Me.db_bytes(CInt(offset)) = 5 Then
            Dim num14 As UShort = Convert.ToUInt16(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(offset), 3D)), 2)), Decimal.One))
            Dim num18 As Integer = num14
            For m As Integer = 0 To num18
                Dim num13 As UShort = CUShort(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(Decimal.Add(New Decimal(offset), 12D), New Decimal(m * 2))), 2))
                Me.ReadTableFromOffset(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(New Decimal(Me.ConvertToInteger(CInt(offset + num13), 4)), Decimal.One), New Decimal(Me.page_size))))
            Next
            Me.ReadTableFromOffset(Convert.ToUInt64(Decimal.Multiply(Decimal.Subtract(New Decimal(Me.ConvertToInteger(Convert.ToInt32(Decimal.Add(New Decimal(offset), 8D)), 4)), Decimal.One), New Decimal(Me.page_size))))
        End If
        Return True
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure record_header_field
        Public size As Long
        Public type As Long
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure sqlite_master_entry
        Public row_id As Long
        Public item_type As String
        Public item_name As String
        Public astable_name As String
        Public root_num As Long
        Public sql_statement As String
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure table_entry
        Public row_id As Long
        Public content As String()
    End Structure
End Class