'
' Created by SharpDevelop.
' User: Media
' Date: 8/30/2013
' Time: 9:07 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class frmPickXMLTable
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.lstTables = New System.Windows.Forms.ListBox()
		Me.btnSelect = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'lstTables
		'
		Me.lstTables.FormattingEnabled = true
		Me.lstTables.Location = New System.Drawing.Point(13, 13)
		Me.lstTables.Name = "lstTables"
		Me.lstTables.Size = New System.Drawing.Size(259, 186)
		Me.lstTables.TabIndex = 0
		AddHandler Me.lstTables.DoubleClick, AddressOf Me.LstTablesDoubleClick
		'
		'btnSelect
		'
		Me.btnSelect.Location = New System.Drawing.Point(99, 205)
		Me.btnSelect.Name = "btnSelect"
		Me.btnSelect.Size = New System.Drawing.Size(75, 23)
		Me.btnSelect.TabIndex = 1
		Me.btnSelect.Text = "&Select"
		Me.btnSelect.UseVisualStyleBackColor = true
		AddHandler Me.btnSelect.Click, AddressOf Me.BtnSelectClick
		'
		'frmPickXMLTable
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(284, 248)
		Me.Controls.Add(Me.btnSelect)
		Me.Controls.Add(Me.lstTables)
		Me.Name = "frmPickXMLTable"
		Me.Text = "Choose Table to Import"
		Me.ResumeLayout(false)
	End Sub
	Private btnSelect As System.Windows.Forms.Button
	Private lstTables As System.Windows.Forms.ListBox
End Class
