
Public Class frmLogin
    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        If MsgBox("Bạn có muốn thoát khỏi chương trình không ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thoát") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        If txtDangNhap.Text = "admin" And txtMatKhau.Text = "admin" Then
            MsgBox("Đăng nhập thành công !", vbCurrency, "Đăng nhập")
            Me.Hide()
            frmXinChao.ShowDialog()
        ElseIf txtDangNhap.Text = "" Or txtMatKhau.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !", vbCritical, "Thông báo lỗi")
        ElseIf txtDangNhap.Text <> "admin" Or txtMatKhau.Text <> "admin" Then
            MsgBox("Mật khẩu hoặc tài khoản không đúng !", vbCritical, "Thông báo lỗi")
        End If
    End Sub
End Class