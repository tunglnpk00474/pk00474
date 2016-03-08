<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.lblTenLogin = New System.Windows.Forms.Label()
        Me.lblMatKhauLogin = New System.Windows.Forms.Label()
        Me.btnDangNhap = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.txtDangNhap = New System.Windows.Forms.TextBox()
        Me.txtMatKhau = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTenLogin
        '
        Me.lblTenLogin.AutoSize = True
        Me.lblTenLogin.Location = New System.Drawing.Point(47, 34)
        Me.lblTenLogin.Name = "lblTenLogin"
        Me.lblTenLogin.Size = New System.Drawing.Size(62, 13)
        Me.lblTenLogin.TabIndex = 0
        Me.lblTenLogin.Text = "Đăng Nhập"
        '
        'lblMatKhauLogin
        '
        Me.lblMatKhauLogin.AutoSize = True
        Me.lblMatKhauLogin.Location = New System.Drawing.Point(56, 74)
        Me.lblMatKhauLogin.Name = "lblMatKhauLogin"
        Me.lblMatKhauLogin.Size = New System.Drawing.Size(53, 13)
        Me.lblMatKhauLogin.TabIndex = 0
        Me.lblMatKhauLogin.Text = "Mật Khẩu"
        '
        'btnDangNhap
        '
        Me.btnDangNhap.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDangNhap.Location = New System.Drawing.Point(112, 117)
        Me.btnDangNhap.Name = "btnDangNhap"
        Me.btnDangNhap.Size = New System.Drawing.Size(75, 23)
        Me.btnDangNhap.TabIndex = 3
        Me.btnDangNhap.Text = "Đăng Nhập"
        Me.btnDangNhap.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnThoat.Location = New System.Drawing.Point(224, 117)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 23)
        Me.btnThoat.TabIndex = 4
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'txtDangNhap
        '
        Me.txtDangNhap.Location = New System.Drawing.Point(112, 31)
        Me.txtDangNhap.Name = "txtDangNhap"
        Me.txtDangNhap.Size = New System.Drawing.Size(187, 20)
        Me.txtDangNhap.TabIndex = 1
        '
        'txtMatKhau
        '
        Me.txtMatKhau.Location = New System.Drawing.Point(112, 71)
        Me.txtMatKhau.Name = "txtMatKhau"
        Me.txtMatKhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatKhau.Size = New System.Drawing.Size(187, 20)
        Me.txtMatKhau.TabIndex = 2
        Me.txtMatKhau.UseSystemPasswordChar = True
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnDangNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnThoat
        Me.ClientSize = New System.Drawing.Size(360, 161)
        Me.Controls.Add(Me.txtMatKhau)
        Me.Controls.Add(Me.txtDangNhap)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnDangNhap)
        Me.Controls.Add(Me.lblMatKhauLogin)
        Me.Controls.Add(Me.lblTenLogin)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng Nhập"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTenLogin As Label
    Friend WithEvents lblMatKhauLogin As Label
    Friend WithEvents btnDangNhap As Button
    Friend WithEvents btnThoat As Button
    Friend WithEvents txtDangNhap As TextBox
    Friend WithEvents txtMatKhau As TextBox
End Class
