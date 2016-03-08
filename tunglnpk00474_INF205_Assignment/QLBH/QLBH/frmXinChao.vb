Public Class frmXinChao

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Close()
    End Sub

    Private Sub btnTiepTuc_Click(sender As Object, e As EventArgs) Handles btnTiepTuc.Click
        Me.Hide()
        frmMain.ShowDialog()

    End Sub
End Class