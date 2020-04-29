Public Class frmXMLEdit

    Private ds As DataSet


    Private Sub btnLoadSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSchema.Click

        openSchema.ShowDialog()
        txtSchema.Text = openSchema.FileName

    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click

        openData.ShowDialog()
        txtData.Text = openData.FileName

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Try
            ds.Dispose()
        Catch ex As Exception
        End Try

        ds = New DataSet

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

		If Me.txtSchema.Text <> Nothing Then
			Try
	            ds.ReadXmlSchema(txtSchema.Text)
	        Catch ex As Exception
	            MsgBox("Cannot load schema" & vbLf & ex.Message)
	            Exit Sub
	        End Try	
		End If

        If IO.File.Exists(txtData.Text) Then
            Try
                ds.ReadXml(txtData.Text)
            Catch ex As Exception
                MsgBox("Cannot load data" & vbLf & ex.Message)
                Exit Sub
            End Try
        Else
            If txtData.Text <> "" Then
                IO.File.Create(txtData.Text)
                MsgBox("Data file does not exist. the file '" & txtData.Text & "' has been created.")
                btnSave_Click(Me, System.EventArgs.Empty)
            End If
        End If


        For Each table As Data.DataTable In ds.Tables
            ListBox1.Items.Add(table.TableName.ToString)
        Next

        If ListBox1.Items.Count > 0 Then
            Try
                ListBox1.SelectedIndex = 0
            Catch ex As Exception
            End Try
            Try
                ListBox2.SelectedIndex = 0
            Catch ex As Exception
            End Try
            setTable(ListBox1.Items(0).ToString)
        End If


    End Sub

    Private Sub setTable(ByVal tableName As String)

        Try
            Me.BindingSource1.DataSource = ds
            Me.BindingSource1.DataMember = tableName
            Me.DataGridView1.DataSource = BindingSource1
            Me.BindingNavigator1.BindingSource = Me.BindingSource1
            Me.DataGridView1.Refresh()
        Catch ex As Exception
            MsgBox("Data didn't fit in grid for some reason." & vbLf & ex.Message)
        End Try

    End Sub

    Private Sub ListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged

        Try
            Me.DataGridView1.EndEdit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            setTable(Me.ListBox1.SelectedItem.ToString)
            If ListBox1.Items.Count > 0 Then
                ListBox2.Items.Clear()
                For Each column As DataColumn In ds.Tables(Me.ListBox1.SelectedItem.ToString).Columns
                    ListBox2.Items.Add(column.ColumnName.ToString)
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click

        If ds.Tables.Count = 0 Then
            MsgBox("Nothing to save!")
            Exit Sub
        End If

        If IO.File.Exists(txtData.Text) Then
            If MsgBox("File already exists, overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Try
            ds.WriteXml(txtData.Text)
        Catch ex As Exception
            MsgBox("Could not write data to file: " & ex.Message)
        End Try

    End Sub

    Private Sub btnSaveSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSchema.Click

        If ds.Tables.Count = 0 Then
            MsgBox("Nothing to save!")
            Exit Sub
        End If

        If IO.File.Exists(txtSchema.Text) Then
            If MsgBox("File already exists, overwrite?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Try
            ds.WriteXmlSchema(txtSchema.Text)
        Catch ex As Exception
            MsgBox("Could not write schema to file: " & ex.Message)
        End Try

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ds = New DataSet

    End Sub

    Private Sub ListBox2_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedValueChanged

        If Me.ListBox2.SelectedItems.Count > 0 Then
            Me.txtColumnName.Text = Me.ListBox2.SelectedItem.ToString
            Me.cboColumnType.Text = ds.Tables(Me.ListBox1.SelectedItem.ToString).Columns(Me.ListBox2.SelectedItem.ToString).DataType.ToString
        Else
            Me.txtColumnName.Text = Nothing
            Me.cboColumnType.Text = Nothing
        End If


    End Sub

    Private Sub btnAddTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTable.Click

        Dim newTableName As String = InputBox("Enter Table Name")

        Try
            ds.Tables.Add(newTableName)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ListBox1.Items.Add(newTableName)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If ListBox1.SelectedItems.Count > 0 Then

            Try
                ds.Tables.Remove(ListBox1.SelectedItem.ToString)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox1.Items.Remove(ListBox1.SelectedItem.ToString)
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.Refresh()
            Me.ListBox2.Items.Clear()
            Me.txtColumnName.Text = Nothing
            Me.cboColumnType.Text = Nothing


        End If

    End Sub

    Private Sub btnEditTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTable.Click

        If ListBox1.SelectedItems.Count > 0 Then

            Dim newTableName As String = InputBox("Enter Table Name")

            Try
                ds.Tables(ListBox1.SelectedItem.ToString).TableName = newTableName
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox1.Items(ListBox1.SelectedIndex) = newTableName

        End If

    End Sub

    Private Sub btnAddColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddColumn.Click

        If ListBox1.SelectedItems.Count > 0 And Me.txtColumnName.Text.Length > 0 And Me.cboColumnType.Text.Length > 0 Then

            Try
                ds.Tables(ListBox1.SelectedItem.ToString).Columns.Add(Me.txtColumnName.Text, System.Type.GetType(Me.cboColumnType.Text))
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox2.Items.Add(Me.txtColumnName.Text)

        End If

    End Sub

    Private Sub btnDeleteColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteColumn.Click

        If ListBox2.SelectedItems.Count > 0 Then

            Try
                ds.Tables(ListBox1.SelectedItem.ToString).Columns.Remove(ListBox2.SelectedItem.ToString)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            Me.txtColumnName.Text = Nothing
            Me.cboColumnType.Text = Nothing
            Me.ListBox2.Items.Remove(ListBox2.SelectedItem)

        End If

    End Sub

    Private Sub btnEditColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditColumn.Click

        If ListBox1.SelectedItems.Count > 0 And Me.txtColumnName.Text.Length > 0 And Me.cboColumnType.Text.Length > 0 Then

            Try
                ds.Tables(ListBox1.SelectedItem.ToString).Columns(Me.ListBox2.SelectedItem.ToString).DataType = System.Type.GetType(Me.cboColumnType.Text)
                ds.Tables(ListBox1.SelectedItem.ToString).Columns(Me.ListBox2.SelectedItem.ToString).ColumnName = Me.txtColumnName.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox2.Items(ListBox2.SelectedIndex) = txtColumnName.Text

        End If

    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

        MsgBox(e.Exception.Message.ToString)

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

		If Me.txtSchema.Text <> Nothing Then
			If MsgBox("Save Schema?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
	            Me.btnSaveSchema_Click(Me, System.EventArgs.Empty)
	        End If	
		End If

		If MsgBox("Save Data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.btnSave_Click(Me, System.EventArgs.Empty)
        End If
        
    End Sub
    
End Class
