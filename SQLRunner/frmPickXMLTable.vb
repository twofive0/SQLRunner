'
' Created by SharpDevelop.
' User: Media
' Date: 8/30/2013
' Time: 9:07 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class frmPickXMLTable
	
	Dim ds As DataSet
	Dim selectedTable As String
	
	Public Sub New(byref dts As DataSet)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		ds = dts
		Dim tList As New List(Of String)
		For Each t As DataTable In ds.Tables
			tList.Add(t.TableName)
		Next
		
		Me.lstTables.DataSource = tList
		

	End Sub
	
	
	Sub BtnSelectClick(sender As Object, e As EventArgs)
		
		selectedTable = Me.lstTables.SelectedValue.ToString
		Me.Close
		
	End Sub
	
	Public Function getSelectedTable As String
		
		getSelectedTable = selectedTable
		
	End Function

	
	Sub LstTablesDoubleClick(sender As Object, e As EventArgs)
		
		BtnSelectClick(Me, Nothing)
		
	End Sub
End Class

