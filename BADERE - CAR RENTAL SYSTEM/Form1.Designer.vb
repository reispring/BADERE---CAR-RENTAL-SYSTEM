<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblCarModel = New System.Windows.Forms.Label()
        Me.txtCarModel = New System.Windows.Forms.TextBox()
        Me.lblRenter = New System.Windows.Forms.Label()
        Me.txtRenterName = New System.Windows.Forms.TextBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnLoadAll = New System.Windows.Forms.Button()
        Me.dgvRentals = New System.Windows.Forms.DataGridView()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.dgvRentals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDetails
        '
        Me.grpDetails.Location = New System.Drawing.Point(12, 53)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(200, 25)
        Me.grpDetails.TabIndex = 0
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Rental Details"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(82, 123)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(21, 13)
        Me.lblID.TabIndex = 2
        Me.lblID.Text = "ID:"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(109, 116)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(289, 20)
        Me.txtID.TabIndex = 3
        '
        'lblCarModel
        '
        Me.lblCarModel.AutoSize = True
        Me.lblCarModel.Location = New System.Drawing.Point(82, 149)
        Me.lblCarModel.Name = "lblCarModel"
        Me.lblCarModel.Size = New System.Drawing.Size(58, 13)
        Me.lblCarModel.TabIndex = 4
        Me.lblCarModel.Text = "Car Model:"
        '
        'txtCarModel
        '
        Me.txtCarModel.Location = New System.Drawing.Point(146, 142)
        Me.txtCarModel.Name = "txtCarModel"
        Me.txtCarModel.Size = New System.Drawing.Size(252, 20)
        Me.txtCarModel.TabIndex = 5
        '
        'lblRenter
        '
        Me.lblRenter.AutoSize = True
        Me.lblRenter.Location = New System.Drawing.Point(82, 178)
        Me.lblRenter.Name = "lblRenter"
        Me.lblRenter.Size = New System.Drawing.Size(73, 13)
        Me.lblRenter.TabIndex = 6
        Me.lblRenter.Text = "Renter Name:"
        '
        'txtRenterName
        '
        Me.txtRenterName.Location = New System.Drawing.Point(161, 171)
        Me.txtRenterName.Name = "txtRenterName"
        Me.txtRenterName.Size = New System.Drawing.Size(237, 20)
        Me.txtRenterName.TabIndex = 7
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(82, 209)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(58, 13)
        Me.lblStart.TabIndex = 8
        Me.lblStart.Text = "Start Date:"
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(161, 203)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(237, 20)
        Me.dtpStart.TabIndex = 9
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(82, 239)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(55, 13)
        Me.lblEnd.TabIndex = 10
        Me.lblEnd.Text = "End Date:"
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(161, 233)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(237, 20)
        Me.dtpEnd.TabIndex = 11
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(80, 268)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(161, 268)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 13
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(242, 268)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(323, 268)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(77, 314)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(44, 13)
        Me.lblSearch.TabIndex = 16
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(126, 307)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(110, 20)
        Me.txtSearch.TabIndex = 17
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(242, 304)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 18
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnLoadAll
        '
        Me.btnLoadAll.Location = New System.Drawing.Point(323, 305)
        Me.btnLoadAll.Name = "btnLoadAll"
        Me.btnLoadAll.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadAll.TabIndex = 19
        Me.btnLoadAll.Text = "Load All"
        Me.btnLoadAll.UseVisualStyleBackColor = True
        '
        'dgvRentals
        '
        Me.dgvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRentals.Location = New System.Drawing.Point(12, 363)
        Me.dgvRentals.Name = "dgvRentals"
        Me.dgvRentals.ReadOnly = True
        Me.dgvRentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect
        Me.dgvRentals.Size = New System.Drawing.Size(436, 208)
        Me.dgvRentals.TabIndex = 20
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(143, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(168, 16)
        Me.lblTitle.TabIndex = 22
        Me.lblTitle.Text = "CAR RENTAL SYSTEM"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 593)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.dgvRentals)
        Me.Controls.Add(Me.btnLoadAll)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.txtRenterName)
        Me.Controls.Add(Me.lblRenter)
        Me.Controls.Add(Me.txtCarModel)
        Me.Controls.Add(Me.lblCarModel)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.grpDetails)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvRentals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents lblID As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblCarModel As Label
    Friend WithEvents txtCarModel As TextBox
    Friend WithEvents lblRenter As Label
    Friend WithEvents txtRenterName As TextBox
    Friend WithEvents lblStart As Label
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents lblEnd As Label
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnLoadAll As Button
    Friend WithEvents dgvRentals As DataGridView
    Friend WithEvents lblTitle As Label
End Class
