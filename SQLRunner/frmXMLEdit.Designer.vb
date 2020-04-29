<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXMLEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    	Me.components = New System.ComponentModel.Container()
    	Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXMLEdit))
    	Me.txtSchema = New System.Windows.Forms.TextBox()
    	Me.txtData = New System.Windows.Forms.TextBox()
    	Me.btnLoadSchema = New System.Windows.Forms.Button()
    	Me.btnLoadData = New System.Windows.Forms.Button()
    	Me.btnLoad = New System.Windows.Forms.Button()
    	Me.btnSaveData = New System.Windows.Forms.Button()
    	Me.ListBox1 = New System.Windows.Forms.ListBox()
    	Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    	Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
    	Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
    	Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
    	Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
    	Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
    	Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    	Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
    	Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    	Me.Label1 = New System.Windows.Forms.Label()
    	Me.Label2 = New System.Windows.Forms.Label()
    	Me.openSchema = New System.Windows.Forms.OpenFileDialog()
    	Me.openData = New System.Windows.Forms.OpenFileDialog()
    	Me.ListBox2 = New System.Windows.Forms.ListBox()
    	Me.btnSaveSchema = New System.Windows.Forms.Button()
    	Me.txtColumnName = New System.Windows.Forms.TextBox()
    	Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    	Me.btnDelete = New System.Windows.Forms.Button()
    	Me.btnEditTable = New System.Windows.Forms.Button()
    	Me.btnAddTable = New System.Windows.Forms.Button()
    	Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    	Me.Label4 = New System.Windows.Forms.Label()
    	Me.Label3 = New System.Windows.Forms.Label()
    	Me.btnDeleteColumn = New System.Windows.Forms.Button()
    	Me.btnEditColumn = New System.Windows.Forms.Button()
    	Me.btnAddColumn = New System.Windows.Forms.Button()
    	Me.cboColumnType = New System.Windows.Forms.ComboBox()
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
    	CType(Me.BindingNavigator1,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.BindingNavigator1.SuspendLayout
    	CType(Me.BindingSource1,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.GroupBox1.SuspendLayout
    	Me.GroupBox2.SuspendLayout
    	Me.SuspendLayout
    	'
    	'txtSchema
    	'
    	Me.txtSchema.Location = New System.Drawing.Point(20, 26)
    	Me.txtSchema.Name = "txtSchema"
    	Me.txtSchema.Size = New System.Drawing.Size(212, 20)
    	Me.txtSchema.TabIndex = 0
    	'
    	'txtData
    	'
    	Me.txtData.Location = New System.Drawing.Point(280, 25)
    	Me.txtData.Name = "txtData"
    	Me.txtData.Size = New System.Drawing.Size(212, 20)
    	Me.txtData.TabIndex = 1
    	'
    	'btnLoadSchema
    	'
    	Me.btnLoadSchema.Location = New System.Drawing.Point(239, 27)
    	Me.btnLoadSchema.Name = "btnLoadSchema"
    	Me.btnLoadSchema.Size = New System.Drawing.Size(24, 19)
    	Me.btnLoadSchema.TabIndex = 2
    	Me.btnLoadSchema.Text = "..."
    	Me.btnLoadSchema.UseVisualStyleBackColor = true
    	'
    	'btnLoadData
    	'
    	Me.btnLoadData.Location = New System.Drawing.Point(501, 27)
    	Me.btnLoadData.Name = "btnLoadData"
    	Me.btnLoadData.Size = New System.Drawing.Size(25, 19)
    	Me.btnLoadData.TabIndex = 3
    	Me.btnLoadData.Text = "..."
    	Me.btnLoadData.UseVisualStyleBackColor = true
    	'
    	'btnLoad
    	'
    	Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnLoad.Location = New System.Drawing.Point(535, 6)
    	Me.btnLoad.Name = "btnLoad"
    	Me.btnLoad.Size = New System.Drawing.Size(85, 24)
    	Me.btnLoad.TabIndex = 4
    	Me.btnLoad.Text = "Load"
    	Me.btnLoad.UseVisualStyleBackColor = true
    	'
    	'btnSaveData
    	'
    	Me.btnSaveData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnSaveData.Location = New System.Drawing.Point(536, 33)
    	Me.btnSaveData.Name = "btnSaveData"
    	Me.btnSaveData.Size = New System.Drawing.Size(85, 24)
    	Me.btnSaveData.TabIndex = 5
    	Me.btnSaveData.Text = "Save Data"
    	Me.btnSaveData.UseVisualStyleBackColor = true
    	'
    	'ListBox1
    	'
    	Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    	Me.ListBox1.FormattingEnabled = true
    	Me.ListBox1.Location = New System.Drawing.Point(8, 21)
    	Me.ListBox1.Name = "ListBox1"
    	Me.ListBox1.Size = New System.Drawing.Size(166, 147)
    	Me.ListBox1.TabIndex = 6
    	'
    	'DataGridView1
    	'
    	Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Left)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    	Me.DataGridView1.Location = New System.Drawing.Point(250, 94)
    	Me.DataGridView1.Name = "DataGridView1"
    	Me.DataGridView1.Size = New System.Drawing.Size(370, 376)
    	Me.DataGridView1.TabIndex = 7
    	'
    	'BindingNavigator1
    	'
    	Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
    	Me.BindingNavigator1.BindingSource = Me.BindingSource1
    	Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
    	Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
    	Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
    	Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
    	Me.BindingNavigator1.Location = New System.Drawing.Point(249, 65)
    	Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
    	Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
    	Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
    	Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
    	Me.BindingNavigator1.Name = "BindingNavigator1"
    	Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
    	Me.BindingNavigator1.Size = New System.Drawing.Size(255, 25)
    	Me.BindingNavigator1.TabIndex = 8
    	Me.BindingNavigator1.Text = "BindingNavigator1"
    	'
    	'BindingNavigatorAddNewItem
    	'
    	Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
    	Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorAddNewItem.Text = "Add new"
    	'
    	'BindingNavigatorCountItem
    	'
    	Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
    	Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
    	Me.BindingNavigatorCountItem.Text = "of {0}"
    	Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
    	'
    	'BindingNavigatorDeleteItem
    	'
    	Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
    	Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorDeleteItem.Text = "Delete"
    	'
    	'BindingNavigatorMoveFirstItem
    	'
    	Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
    	Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorMoveFirstItem.Text = "Move first"
    	'
    	'BindingNavigatorMovePreviousItem
    	'
    	Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
    	Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
    	'
    	'BindingNavigatorSeparator
    	'
    	Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
    	Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
    	'
    	'BindingNavigatorPositionItem
    	'
    	Me.BindingNavigatorPositionItem.AccessibleName = "Position"
    	Me.BindingNavigatorPositionItem.AutoSize = false
    	Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
    	Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
    	Me.BindingNavigatorPositionItem.Text = "0"
    	Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
    	'
    	'BindingNavigatorSeparator1
    	'
    	Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
    	Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
    	'
    	'BindingNavigatorMoveNextItem
    	'
    	Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
    	Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorMoveNextItem.Text = "Move next"
    	'
    	'BindingNavigatorMoveLastItem
    	'
    	Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    	Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"),System.Drawing.Image)
    	Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
    	Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true
    	Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
    	Me.BindingNavigatorMoveLastItem.Text = "Move last"
    	'
    	'BindingNavigatorSeparator2
    	'
    	Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
    	Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
    	'
    	'Label1
    	'
    	Me.Label1.AutoSize = true
    	Me.Label1.Location = New System.Drawing.Point(281, 4)
    	Me.Label1.Name = "Label1"
    	Me.Label1.Size = New System.Drawing.Size(49, 13)
    	Me.Label1.TabIndex = 9
    	Me.Label1.Text = "Data File"
    	'
    	'Label2
    	'
    	Me.Label2.AutoSize = true
    	Me.Label2.Location = New System.Drawing.Point(21, 7)
    	Me.Label2.Name = "Label2"
    	Me.Label2.Size = New System.Drawing.Size(123, 13)
    	Me.Label2.TabIndex = 10
    	Me.Label2.Text = "Schema File (if separate)"
    	'
    	'openSchema
    	'
    	Me.openSchema.DefaultExt = "xsd"
    	Me.openSchema.Filter = "XML Schema Files (*.xsd)|*.xsd|All files (*.*)|*.*"
    	'
    	'openData
    	'
    	Me.openData.DefaultExt = "xml"
    	Me.openData.Filter = "XML Data Files (*.xml)|*.xml|All files (*.*)|*.*"
    	'
    	'ListBox2
    	'
    	Me.ListBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    	Me.ListBox2.FormattingEnabled = true
    	Me.ListBox2.Location = New System.Drawing.Point(7, 81)
    	Me.ListBox2.Name = "ListBox2"
    	Me.ListBox2.Size = New System.Drawing.Size(169, 121)
    	Me.ListBox2.TabIndex = 12
    	'
    	'btnSaveSchema
    	'
    	Me.btnSaveSchema.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnSaveSchema.Location = New System.Drawing.Point(536, 61)
    	Me.btnSaveSchema.Name = "btnSaveSchema"
    	Me.btnSaveSchema.Size = New System.Drawing.Size(85, 24)
    	Me.btnSaveSchema.TabIndex = 14
    	Me.btnSaveSchema.Text = "Save Schema"
    	Me.btnSaveSchema.UseVisualStyleBackColor = true
    	'
    	'txtColumnName
    	'
    	Me.txtColumnName.Location = New System.Drawing.Point(46, 28)
    	Me.txtColumnName.Name = "txtColumnName"
    	Me.txtColumnName.Size = New System.Drawing.Size(129, 20)
    	Me.txtColumnName.TabIndex = 15
    	'
    	'GroupBox1
    	'
    	Me.GroupBox1.Controls.Add(Me.btnDelete)
    	Me.GroupBox1.Controls.Add(Me.btnEditTable)
    	Me.GroupBox1.Controls.Add(Me.btnAddTable)
    	Me.GroupBox1.Controls.Add(Me.ListBox1)
    	Me.GroupBox1.Location = New System.Drawing.Point(9, 60)
    	Me.GroupBox1.Name = "GroupBox1"
    	Me.GroupBox1.Size = New System.Drawing.Size(236, 208)
    	Me.GroupBox1.TabIndex = 16
    	Me.GroupBox1.TabStop = false
    	Me.GroupBox1.Text = "Tables"
    	'
    	'btnDelete
    	'
    	Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnDelete.Location = New System.Drawing.Point(183, 76)
    	Me.btnDelete.Name = "btnDelete"
    	Me.btnDelete.Size = New System.Drawing.Size(48, 24)
    	Me.btnDelete.TabIndex = 17
    	Me.btnDelete.Text = "Delete"
    	Me.btnDelete.UseVisualStyleBackColor = true
    	'
    	'btnEditTable
    	'
    	Me.btnEditTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnEditTable.Location = New System.Drawing.Point(183, 48)
    	Me.btnEditTable.Name = "btnEditTable"
    	Me.btnEditTable.Size = New System.Drawing.Size(48, 24)
    	Me.btnEditTable.TabIndex = 16
    	Me.btnEditTable.Text = "Edit"
    	Me.btnEditTable.UseVisualStyleBackColor = true
    	'
    	'btnAddTable
    	'
    	Me.btnAddTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnAddTable.Location = New System.Drawing.Point(182, 21)
    	Me.btnAddTable.Name = "btnAddTable"
    	Me.btnAddTable.Size = New System.Drawing.Size(48, 24)
    	Me.btnAddTable.TabIndex = 15
    	Me.btnAddTable.Text = "Add"
    	Me.btnAddTable.UseVisualStyleBackColor = true
    	'
    	'GroupBox2
    	'
    	Me.GroupBox2.Controls.Add(Me.Label4)
    	Me.GroupBox2.Controls.Add(Me.Label3)
    	Me.GroupBox2.Controls.Add(Me.btnDeleteColumn)
    	Me.GroupBox2.Controls.Add(Me.btnEditColumn)
    	Me.GroupBox2.Controls.Add(Me.btnAddColumn)
    	Me.GroupBox2.Controls.Add(Me.cboColumnType)
    	Me.GroupBox2.Controls.Add(Me.ListBox2)
    	Me.GroupBox2.Controls.Add(Me.txtColumnName)
    	Me.GroupBox2.Location = New System.Drawing.Point(8, 277)
    	Me.GroupBox2.Name = "GroupBox2"
    	Me.GroupBox2.Size = New System.Drawing.Size(236, 208)
    	Me.GroupBox2.TabIndex = 17
    	Me.GroupBox2.TabStop = false
    	Me.GroupBox2.Text = "Columns"
    	'
    	'Label4
    	'
    	Me.Label4.AutoSize = true
    	Me.Label4.Location = New System.Drawing.Point(6, 58)
    	Me.Label4.Name = "Label4"
    	Me.Label4.Size = New System.Drawing.Size(31, 13)
    	Me.Label4.TabIndex = 21
    	Me.Label4.Text = "Type"
    	'
    	'Label3
    	'
    	Me.Label3.AutoSize = true
    	Me.Label3.Location = New System.Drawing.Point(4, 30)
    	Me.Label3.Name = "Label3"
    	Me.Label3.Size = New System.Drawing.Size(35, 13)
    	Me.Label3.TabIndex = 18
    	Me.Label3.Text = "Name"
    	'
    	'btnDeleteColumn
    	'
    	Me.btnDeleteColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnDeleteColumn.Location = New System.Drawing.Point(180, 83)
    	Me.btnDeleteColumn.Name = "btnDeleteColumn"
    	Me.btnDeleteColumn.Size = New System.Drawing.Size(48, 24)
    	Me.btnDeleteColumn.TabIndex = 20
    	Me.btnDeleteColumn.Text = "Delete"
    	Me.btnDeleteColumn.UseVisualStyleBackColor = true
    	'
    	'btnEditColumn
    	'
    	Me.btnEditColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnEditColumn.Location = New System.Drawing.Point(180, 55)
    	Me.btnEditColumn.Name = "btnEditColumn"
    	Me.btnEditColumn.Size = New System.Drawing.Size(48, 24)
    	Me.btnEditColumn.TabIndex = 19
    	Me.btnEditColumn.Text = "Save"
    	Me.btnEditColumn.UseVisualStyleBackColor = true
    	'
    	'btnAddColumn
    	'
    	Me.btnAddColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.btnAddColumn.Location = New System.Drawing.Point(179, 28)
    	Me.btnAddColumn.Name = "btnAddColumn"
    	Me.btnAddColumn.Size = New System.Drawing.Size(48, 24)
    	Me.btnAddColumn.TabIndex = 18
    	Me.btnAddColumn.Text = "Add"
    	Me.btnAddColumn.UseVisualStyleBackColor = true
    	'
    	'cboColumnType
    	'
    	Me.cboColumnType.FormattingEnabled = true
    	Me.cboColumnType.Items.AddRange(New Object() {"System.Boolean", "System.DateTime", "System.Double", "System.Int32", "System.String"})
    	Me.cboColumnType.Location = New System.Drawing.Point(46, 53)
    	Me.cboColumnType.Name = "cboColumnType"
    	Me.cboColumnType.Size = New System.Drawing.Size(130, 21)
    	Me.cboColumnType.TabIndex = 16
    	'
    	'frmMain
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(640, 500)
    	Me.Controls.Add(Me.GroupBox2)
    	Me.Controls.Add(Me.GroupBox1)
    	Me.Controls.Add(Me.btnSaveSchema)
    	Me.Controls.Add(Me.Label2)
    	Me.Controls.Add(Me.Label1)
    	Me.Controls.Add(Me.BindingNavigator1)
    	Me.Controls.Add(Me.DataGridView1)
    	Me.Controls.Add(Me.btnSaveData)
    	Me.Controls.Add(Me.btnLoad)
    	Me.Controls.Add(Me.btnLoadData)
    	Me.Controls.Add(Me.btnLoadSchema)
    	Me.Controls.Add(Me.txtData)
    	Me.Controls.Add(Me.txtSchema)
    	Me.Name = "frmMain"
    	Me.Text = "XML Edit"
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
    	CType(Me.BindingNavigator1,System.ComponentModel.ISupportInitialize).EndInit
    	Me.BindingNavigator1.ResumeLayout(false)
    	Me.BindingNavigator1.PerformLayout
    	CType(Me.BindingSource1,System.ComponentModel.ISupportInitialize).EndInit
    	Me.GroupBox1.ResumeLayout(false)
    	Me.GroupBox2.ResumeLayout(false)
    	Me.GroupBox2.PerformLayout
    	Me.ResumeLayout(false)
    	Me.PerformLayout
    End Sub
    Friend WithEvents txtSchema As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadSchema As System.Windows.Forms.Button
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSaveData As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents openSchema As System.Windows.Forms.OpenFileDialog
    Friend WithEvents openData As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents btnSaveSchema As System.Windows.Forms.Button
    Friend WithEvents txtColumnName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboColumnType As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEditTable As System.Windows.Forms.Button
    Friend WithEvents btnAddTable As System.Windows.Forms.Button
    Friend WithEvents btnDeleteColumn As System.Windows.Forms.Button
    Friend WithEvents btnEditColumn As System.Windows.Forms.Button
    Friend WithEvents btnAddColumn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
