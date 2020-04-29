Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Data.OleDb
Imports System.IO

Public Class ExportAdapter
    'This class reads from a datatable object and exports to various formats

    Public Function DataTable2Excel(ByVal dt As DataTable, ByVal strExcelFile As String) As Boolean

        Dim myString As New StringBuilder
        Dim bFirstRecord As Boolean = True
        Dim rowIndex As Integer = 0

        DataTable2Excel = True

        Try

            'write the header row
            bFirstRecord = True
            For Each column As DataColumn In dt.Columns
                If Not bFirstRecord Then
                    myString.Append(vbTab)
                End If
                myString.Append(column.ColumnName)
                bFirstRecord = False
            Next
            myString.Append(Environment.NewLine)

            For Each dr As DataRow In dt.Rows

                rowIndex += 1
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString.Append(vbTab)
                    End If
                    myString.Append(field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString.Append(Environment.NewLine)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2Excel = False
            Exit Function
        End Try

        Try
            System.IO.File.WriteAllText(strExcelFile, myString.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2Excel = False
        End Try


    End Function

    Public Function DataTable2CSV(ByVal dt As DataTable, ByVal fileName As String) As Boolean

        Dim myString As New StringBuilder
        Dim bFirstRecord As Boolean = True
        Dim rowIndex As Integer = 0

        DataTable2CSV = True

        Try

            'write the header row
            bFirstRecord = True
            For Each column As DataColumn In dt.Columns
                If Not bFirstRecord Then
                    myString.Append(",")
                End If
                myString.Append(column.ColumnName)
                bFirstRecord = False
            Next
            myString.Append(Environment.NewLine)

            For Each dr As DataRow In dt.Rows

                rowIndex += 1
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString.Append(",")
                    End If
                    myString.Append(field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString.Append(Environment.NewLine)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2CSV = False
            Exit Function
        End Try

        Try
            System.IO.File.WriteAllText(fileName, myString.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2CSV = False
        End Try


    End Function

    Public Function DataTable2txt(ByVal dt As DataTable, ByVal fileName As String, ByVal delimiter As Char) As Boolean

        Dim myString As New StringBuilder
        Dim bFirstRecord As Boolean = True
        Dim rowIndex As Integer = 0

        DataTable2txt = True

        Try

            'write the header row
            bFirstRecord = True
            For Each column As DataColumn In dt.Columns
                If Not bFirstRecord Then
                    myString.Append(delimiter)
                End If
                myString.Append(column.ColumnName)
                bFirstRecord = False
            Next
            myString.Append(Environment.NewLine)

            For Each dr As DataRow In dt.Rows

                rowIndex += 1
                bFirstRecord = True
                For Each field As Object In dr.ItemArray
                    If Not bFirstRecord Then
                        myString.Append(delimiter)
                    End If
                    myString.Append(field.ToString)
                    bFirstRecord = False
                Next
                'New Line to differentiate next row
                myString.Append(Environment.NewLine)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2txt = False
            Exit Function
        End Try

        Try
            System.IO.File.WriteAllText(fileName, myString.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2txt = False
        End Try


    End Function


    Public Function ConvertToHtmlFile(ByVal targetTable As DataTable, ByVal fileName As String) As String
        Dim myHtmlFile As String = ""

        If (targetTable Is Nothing) Then
            Throw New System.ArgumentNullException("targetTable")
        Else
            'Continue.
        End If

        'Get a worker object.
        Dim myBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()

        'Open tags and write the top portion.
        myBuilder.Append("<html xmlns='http://www.w3.org/1999/xhtml'>")
        myBuilder.Append("<head>")
        myBuilder.Append("<title>")
        myBuilder.Append("Page-")
        myBuilder.Append(Guid.NewGuid().ToString())
        myBuilder.Append("</title>")
        myBuilder.Append("</head>")
        myBuilder.Append("<body>")
        myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ")
        myBuilder.Append("style='border: solid 1px Silver; font-size: x-small;'>")

        'Add the headings row.

        myBuilder.Append("<tr align='left' valign='top'>")

        For Each myColumn As DataColumn In targetTable.Columns
            myBuilder.Append("<td align='left' valign='top'>")
            myBuilder.Append(myColumn.ColumnName)
            myBuilder.Append("</td>")
        Next myColumn

        myBuilder.Append("</tr>")


        'Add the data rows.
        For Each myRow As DataRow In targetTable.Rows
            myBuilder.Append("<tr align='left' valign='top'>")

            For Each myColumn As DataColumn In targetTable.Columns
                myBuilder.Append("<td align='left' valign='top'>")
                If myRow(myColumn.ColumnName).ToString = Nothing Then
                    myBuilder.Append("&nbsp;")
                Else
                    myBuilder.Append(myRow(myColumn.ColumnName).ToString())
                End If
                'myBuilder.Append(myRow(myColumn.ColumnName).ToString())
                myBuilder.Append("</td>")
            Next myColumn


            myBuilder.Append("</tr>")
        Next myRow

        'Close tags.
        myBuilder.Append("</table>")
        myBuilder.Append("</body>")
        myBuilder.Append("</html>")

        'Get the string for return.
        myHtmlFile = myBuilder.ToString()

        Try
            System.IO.File.WriteAllText(fileName, myHtmlFile.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return myHtmlFile
    End Function
    
Public Function DataTable2Guardian(ByVal dt As DataTable, ByVal fileName As String) As Boolean

    Dim myString As New StringBuilder
    Dim bFirstRecord As Boolean = True
    Dim rowIndex As Integer = 0
    Dim delimiter As String = "¶"
    
    DataTable2Guardian = True

    Try

        'write the header row
        bFirstRecord = True
        For Each column As DataColumn In dt.Columns
            If Not bFirstRecord Then
                myString.Append(delimiter)
            End If
            myString.Append(column.ColumnName)
            bFirstRecord = False
        Next
        myString.Append(Environment.NewLine)

        For Each dr As DataRow In dt.Rows

            rowIndex += 1
            bFirstRecord = True
            For Each field As Object In dr.ItemArray
                If Not bFirstRecord Then
                    myString.Append(delimiter)
                End If
                myString.Append(Replace(Replace(field.tostring,Environment.NewLine,Nothing),"¶",Nothing))
                bFirstRecord = False
            Next
            'New Line to differentiate next row
            myString.Append(Environment.NewLine)
        Next
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2Guardian = False
            Exit Function
        End Try

        Try
            System.IO.File.WriteAllText(fileName, myString.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            DataTable2Guardian = False
        End Try


    End Function
    
End Class
