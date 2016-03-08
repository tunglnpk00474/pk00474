Public Class frmMain
    Dim sqlConnect As New Database
    Private Sub btnThemLoai_Click(sender As Object, e As EventArgs) Handles btnThemLoai.Click
        If txtTenLoai.Text = "" Or txtMoTa.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !")
        Else

            sqlConnect.ExecuteNoneQuery("Insert into LoaiSanPham(TenLoai,MoTa) values(N'" + txtTenLoai.Text + "',N'" + txtMoTa.Text + "')")
        End If

        LoadLoaiSanPham()
        txtMaLoai.Text = ""
        txtTenLoai.Text = ""
        txtMoTa.Text = ""
    End Sub
    Private Sub LoadLoaiSanPham()
        lsLoaiSanPham.Items.Clear()
        Dim dt As DataTable = sqlConnect.GetDataTable("Select * from LoaiSanPham")

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim item As New ListViewItem(lsLoaiSanPham.Items.Count + 1)
            item.SubItems.Add(dt.Rows(i).ItemArray(0))
            item.SubItems.Add(dt.Rows(i).ItemArray(1))
            item.SubItems.Add(dt.Rows(i).ItemArray(2))

            lsLoaiSanPham.Items.Add(item)
        Next
    End Sub
    Private Sub btnThoatLoai_Click(sender As Object, e As EventArgs) Handles btnThoatLoai.Click
        If MsgBox("Bạn có muốn thoát khỏi chương trình không ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thoát") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub lsLoaiSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsLoaiSanPham.SelectedIndexChanged
        If lsLoaiSanPham.SelectedItems.Count = 1 Then
            For Each List As ListViewItem In lsLoaiSanPham.SelectedItems
                txtMaLoai.Text = List.SubItems(1).Text
                txtTenLoai.Text = List.SubItems(2).Text
                txtMoTa.Text = List.SubItems(3).Text
            Next
        End If
    End Sub

    Private Sub grbLoaiSanPham_Enter(sender As Object, e As EventArgs) Handles grbLoaiSanPham.Enter
        LoadLoaiSanPham()
    End Sub

    Private Sub btnXoaLoai_Click(sender As Object, e As EventArgs) Handles btnXoaLoai.Click
        If txtTenLoai.Text = "" Or txtMoTa.Text = "" Then
            MsgBox("Bạn cần chọn Loại Sản Phẩm để xóa !")
        Else
            For i As Integer = lsLoaiSanPham.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanXoa As Integer = lsLoaiSanPham.SelectedIndices(i)
                Dim maSPCanXoa As String = lsLoaiSanPham.Items(viTriCanXoa).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Delete from LoaiSanPham where MaLoai = " + maSPCanXoa)

            Next

        End If

        LoadLoaiSanPham()
        txtMaLoai.Text = ""
        txtTenLoai.Text = ""
        txtMoTa.Text = ""
    End Sub

    Private Sub btnSuaLoai_Click(sender As Object, e As EventArgs) Handles btnSuaLoai.Click
        If txtTenLoai.Text = "" Or txtMoTa.Text = "" Then
            MsgBox("Bạn cần chọn Loại Sản Phẩm để Sữa !")
        Else
            For i As Integer = lsLoaiSanPham.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanSua As Integer = lsLoaiSanPham.SelectedIndices(i)
                Dim maSPCanSua As String = lsLoaiSanPham.Items(viTriCanSua).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Update LoaiSanPham SET TenLoai ='" + txtTenLoai.Text + "',MoTa ='" + txtMoTa.Text + "' where MaLoai = " + maSPCanSua)
            Next


        End If
        LoadLoaiSanPham()
        txtMaLoai.Text = ""
        txtTenLoai.Text = ""
        txtMoTa.Text = ""
    End Sub



    'Thêm Sữa Xóa Sản Phẩm'
    Private Sub lsSanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsSanPham.SelectedIndexChanged
        If lsSanPham.SelectedItems.Count = 1 Then
            For Each List As ListViewItem In lsSanPham.SelectedItems
                txtMaLoaiSP.Text = List.SubItems(1).Text
                txtMaSP.Text = List.SubItems(0).Text
                txtTenSP.Text = List.SubItems(3).Text
                txtGiaSP.Text = List.SubItems(4).Text
            Next
        End If

    End Sub
    Private Sub LoadSanPham()
        lsSanPham.Items.Clear()
        Dim dt As DataTable = sqlConnect.GetDataTable("Select * from SanPham")

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim item As New ListViewItem(lsSanPham.Items.Count + 1)
            item.SubItems.Add(dt.Rows(i).ItemArray(3))
            item.SubItems.Add(dt.Rows(i).ItemArray(0))
            item.SubItems.Add(dt.Rows(i).ItemArray(1))
            item.SubItems.Add(dt.Rows(i).ItemArray(2))

            lsSanPham.Items.Add(item)
        Next
    End Sub
    Private Sub grbSanPham_Enter(sender As Object, e As EventArgs) Handles grbSanPham.Enter
        LoadSanPham()
    End Sub

    Private Sub btnThoatSP_Click(sender As Object, e As EventArgs) Handles btnThoatSP.Click
        If MsgBox("Bạn có muốn thoát khỏi chương trình không ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thoát") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub lblChuThichSP_TextChanged(sender As Object, e As EventArgs) Handles txtChuThichSP.TextChanged
    End Sub

    Private Sub btnThemSP_Click(sender As Object, e As EventArgs) Handles btnThemSP.Click
        If txtTenSP.Text = "" Or txtGiaSP.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !")
        Else

            sqlConnect.ExecuteNoneQuery("Insert into SanPham(TenSP,GiaSP,MaLoai) values(N'" + txtTenSP.Text + "',N'" + txtGiaSP.Text + "', '" + txtMaLoaiSP.Text + "')")
        End If

        LoadSanPham()
        txtMaLoaiSP.Text = ""
        txtTenSP.Text = ""
        txtGiaSP.Text = ""
        txtMaSP.Text = ""
    End Sub

    Private Sub btnSuaSP_Click(sender As Object, e As EventArgs) Handles btnSuaSP.Click
        If txtTenSP.Text = "" Or txtGiaSP.Text = "" Or txtMaLoaiSP.Text = "" Then
            MsgBox("Bạn cần chọn Sản Phẩm để Sữa !")
        Else
            For i As Integer = lsSanPham.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanSua As Integer = lsSanPham.SelectedIndices(i)
                Dim maSPCanSua As String = lsSanPham.Items(viTriCanSua).SubItems(2).Text
                sqlConnect.ExecuteNoneQuery("Update SanPham SET TenSP ='" + txtTenSP.Text + "',GiaSP ='" + txtGiaSP.Text + "', MaLoai = '" + txtMaLoaiSP.Text + "' where MaSP = " + maSPCanSua)
            Next


        End If

        LoadSanPham()
        txtMaLoaiSP.Text = ""
        txtTenSP.Text = ""
        txtGiaSP.Text = ""
        txtMaSP.Text = ""
    End Sub

    Private Sub btnXoaSP_Click(sender As Object, e As EventArgs) Handles btnXoaSP.Click
        If txtTenSP.Text = "" Or txtGiaSP.Text = "" Or txtMaLoaiSP.Text = "" Then
            MsgBox("Bạn cần chọn Sản Phẩm để xóa !")
        Else
            For i As Integer = lsSanPham.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanXoa As Integer = lsSanPham.SelectedIndices(i)
                Dim maSPCanXoa As String = lsSanPham.Items(viTriCanXoa).SubItems(2).Text
                sqlConnect.ExecuteNoneQuery("Delete from SanPham where MaSP = " + maSPCanXoa)

            Next

        End If
        LoadSanPham()
        txtMaLoaiSP.Text = ""
        txtTenSP.Text = ""
        txtGiaSP.Text = ""
        txtMaSP.Text = ""
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSanPham()
        LoadLoaiSanPham()
        LoadNhanVien()
        LoadHoaDon()
        LoadChiTietHoaDon()

    End Sub



    'Thêm Sữa Xóa Nhân Viên'
    Private Sub lsNhanVien_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsNhanVien.SelectedIndexChanged
        If lsNhanVien.SelectedItems.Count = 1 Then
            For Each List As ListViewItem In lsNhanVien.SelectedItems
                txtMaNV.Text = List.SubItems(1).Text
                txtTenNV.Text = List.SubItems(2).Text
                txtGioiTinhNV.Text = List.SubItems(3).Text
                txtDiaChi.Text = List.SubItems(4).Text
                txtSDTNV.Text = List.SubItems(5).Text
                txtMatKhauNV.Text = List.SubItems(6).Text

            Next
        End If
    End Sub

    Private Sub LoadNhanVien()
        lsNhanVien.Items.Clear()
        Dim dt As DataTable = sqlConnect.GetDataTable("Select * from NhanVien")

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim item As New ListViewItem(lsNhanVien.Items.Count + 1)
            item.SubItems.Add(dt.Rows(i).ItemArray(0))
            item.SubItems.Add(dt.Rows(i).ItemArray(1))
            item.SubItems.Add(dt.Rows(i).ItemArray(2))
            item.SubItems.Add(dt.Rows(i).ItemArray(3))
            item.SubItems.Add(dt.Rows(i).ItemArray(4))
            item.SubItems.Add(dt.Rows(i).ItemArray(5))
            lsNhanVien.Items.Add(item)
        Next
    End Sub

    Private Sub grbNhanVien_Enter(sender As Object, e As EventArgs) Handles grbNhanVien.Enter
        LoadNhanVien()
    End Sub

    Private Sub btnThoatNV_Click(sender As Object, e As EventArgs) Handles btnThoatNV.Click
        If MsgBox("Bạn có muốn thoát khỏi chương trình không ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thoát") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub btnThemNV_Click(sender As Object, e As EventArgs) Handles btnThemNV.Click
        If txtTenNV.Text = "" Or txtGioiTinhNV.Text = "" Or txtMatKhauNV.Text = "" Or txtDiaChi.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !")
        Else

            sqlConnect.ExecuteNoneQuery("Insert into NhanVien(TenNV,GioiTinh,DiaChi,SDT,MatKhau) values(N'" + txtTenNV.Text + "',N'" + txtGioiTinhNV.Text + "', N'" + txtDiaChi.Text + "',N'" + txtSDTNV.Text + "',N'" + txtMatKhauNV.Text + "')")
        End If
        LoadNhanVien()
        txtMaNV.Text = ""
        txtTenNV.Text = ""
        txtGioiTinhNV.Text = ""
        txtDiaChi.Text = ""
        txtSDTNV.Text = ""
        txtMatKhauNV.Text = ""
    End Sub

    Private Sub btnSuaNV_Click(sender As Object, e As EventArgs) Handles btnSuaNV.Click
        If txtTenNV.Text = "" Or txtGioiTinhNV.Text = "" Or txtMatKhauNV.Text = "" Or txtDiaChi.Text = "" Then
            MsgBox("Bạn cần chọn Nhân Viên để Sữa !")
        Else
            For i As Integer = lsNhanVien.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanSua As Integer = lsNhanVien.SelectedIndices(i)
                Dim maNVCanSua As String = lsNhanVien.Items(viTriCanSua).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Update NhanVien SET TenNV ='" + txtTenNV.Text + "',GioiTinh ='" + txtGioiTinhNV.Text + "', DiaChi = '" + txtDiaChi.Text + "', SDT = '" + txtSDTNV.Text + "',MatKhau = '" + txtMatKhauNV.Text + "' where MaNV = " + maNVCanSua)
            Next
        End If

        LoadNhanVien()
        txtMaNV.Text = ""
        txtTenNV.Text = ""
        txtGioiTinhNV.Text = ""
        txtDiaChi.Text = ""
        txtSDTNV.Text = ""
        txtMatKhauNV.Text = ""

    End Sub

    Private Sub btnXoaNV_Click(sender As Object, e As EventArgs) Handles btnXoaNV.Click
        If txtTenNV.Text = "" Or txtGioiTinhNV.Text = "" Or txtMatKhauNV.Text = "" Or txtDiaChi.Text = "" Then
            MsgBox("Bạn cần chọn Nhân Viên để xóa !")
        Else
            For i As Integer = lsNhanVien.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanXoa As Integer = lsNhanVien.SelectedIndices(i)
                Dim maNVCanXoa As String = lsNhanVien.Items(viTriCanXoa).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Delete from NhanVien where MaNV = " + maNVCanXoa)

            Next

        End If
        txtMaNV.Text = ""
        txtTenNV.Text = ""
        txtGioiTinhNV.Text = ""
        txtDiaChi.Text = ""
        txtSDTNV.Text = ""
        txtMatKhauNV.Text = ""
        LoadNhanVien()

    End Sub


    'Thêm Sữa Xóa HoaDon'

    Private Sub grbHoaDon_Enter(sender As Object, e As EventArgs) Handles grbHoaDon.Enter
        LoadHoaDon()
    End Sub
    Private Sub LoadHoaDon()
        lsHoaDon.Items.Clear()
        Dim dt As DataTable = sqlConnect.GetDataTable("Select * from HoaDon")

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim item As New ListViewItem(lsHoaDon.Items.Count + 1)
            item.SubItems.Add(dt.Rows(i).ItemArray(0))
            item.SubItems.Add(dt.Rows(i).ItemArray(1))
            item.SubItems.Add(dt.Rows(i).ItemArray(2))
            item.SubItems.Add(dt.Rows(i).ItemArray(3))
            item.SubItems.Add(dt.Rows(i).ItemArray(4))

            lsHoaDon.Items.Add(item)
        Next
    End Sub

    Private Sub lsHoaDon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsHoaDon.SelectedIndexChanged
        If lsHoaDon.SelectedItems.Count = 1 Then
            For Each List As ListViewItem In lsHoaDon.SelectedItems
                txtMaHD.Text = List.SubItems(1).Text
                txtNgayLap.Text = List.SubItems(2).Text
                txtMaNVHD.Text = List.SubItems(3).Text
                txtMaKHHD.Text = List.SubItems(4).Text
                txtTongTienHD.Text = List.SubItems(5).Text
            Next
        End If
    End Sub

    Private Sub btnThoatHD_Click(sender As Object, e As EventArgs) Handles btnThoatHD.Click
        If MsgBox("Bạn có muốn thoát khỏi chương trình không ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thoát") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub btnThemHD_Click(sender As Object, e As EventArgs) Handles btnThemHD.Click
        If txtMaNVHD.Text = "" Or txtNgayLap.Text = "" Or txtMaKHHD.Text = "" Or txtTongTienHD.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !")
        Else

            sqlConnect.ExecuteNoneQuery("Insert into HoaDon(NgayLap,MaNV,MaKH,TongTien) values(N'" + txtNgayLap.Text + "',N'" + txtMaNVHD.Text + "', N'" + txtMaKHHD.Text + "',N'" + txtTongTienHD.Text + "')")
        End If
        LoadHoaDon()
        txtMaHD.Text = ""
        txtMaNVHD.Text = ""
        txtNgayLap.Text = ""
        txtMaKHHD.Text = ""
        txtTongTienHD.Text = ""
    End Sub

    Private Sub btnSuaHD_Click(sender As Object, e As EventArgs) Handles btnSuaHD.Click
        If txtMaNVHD.Text = "" Or txtNgayLap.Text = "" Or txtMaKHHD.Text = "" Or txtTongTienHD.Text = "" Then
            MsgBox("Bạn cần chọn Hóa Đơn để Sữa !")
        Else
            For i As Integer = lsHoaDon.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanSua As Integer = lsHoaDon.SelectedIndices(i)
                Dim maHDCanSua As String = lsHoaDon.Items(viTriCanSua).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Update HoaDon SET NgayLap ='" + txtNgayLap.Text + "',MaNV ='" + txtMaNVHD.Text + "', MaKH = '" + txtMaKHHD.Text + "', TongTien = '" + txtTongTienHD.Text + "' where MaHD = " + maHDCanSua)
            Next
        End If
        LoadHoaDon()
        txtMaHD.Text = ""
        txtMaNVHD.Text = ""
        txtNgayLap.Text = ""
        txtMaKHHD.Text = ""
        txtTongTienHD.Text = ""
    End Sub

    Private Sub btnXoaHD_Click(sender As Object, e As EventArgs) Handles btnXoaHD.Click
        If txtMaNVHD.Text = "" Or txtNgayLap.Text = "" Or txtMaKHHD.Text = "" Or txtTongTienHD.Text = "" Then
            MsgBox("Bạn cần chọn Hóa Đơn để xóa !")
        Else
            For i As Integer = lsHoaDon.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanXoa As Integer = lsHoaDon.SelectedIndices(i)
                Dim maHDCanXoa As String = lsHoaDon.Items(viTriCanXoa).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Delete from HoaDon where MaHD = " + maHDCanXoa)

            Next
        End If
        LoadHoaDon()
        txtMaHD.Text = ""
        txtMaNVHD.Text = ""
        txtNgayLap.Text = ""
        txtMaKHHD.Text = ""
        txtTongTienHD.Text = ""
    End Sub

    



    'Thêm Sữa Xóa Chi Tiết Hóa Đơn'
    Private Sub btnThoatCTHD_Click(sender As Object, e As EventArgs) Handles btnThoatCTHD.Click
        Close()
    End Sub
    Private Sub txtThanhTienCTHD_TextChanged(sender As Object, e As EventArgs) Handles txtThanhTienCTHD.TextChanged
        'txtThanhTienCTHD.Text = Boolean.Parse("txtDonGiaCTHD.Text" * "txtSoLuongCTHD.Text")
    End Sub

    Private Sub grbChiTietHoaDon_Enter(sender As Object, e As EventArgs) Handles grbChiTietHoaDon.Enter
        LoadChiTietHoaDon()
    End Sub

    Private Sub LoadChiTietHoaDon()
        lsCTHD.Items.Clear()
        Dim dt As DataTable = sqlConnect.GetDataTable("Select * from ChiTietHoaDon")

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim item As New ListViewItem(lsCTHD.Items.Count + 1)
            item.SubItems.Add(dt.Rows(i).ItemArray(0))
            item.SubItems.Add(dt.Rows(i).ItemArray(1))
            item.SubItems.Add(dt.Rows(i).ItemArray(2))
            item.SubItems.Add(dt.Rows(i).ItemArray(3))
            item.SubItems.Add(dt.Rows(i).ItemArray(4))
            item.SubItems.Add(dt.Rows(i).ItemArray(5))
            item.SubItems.Add(dt.Rows(i).ItemArray(6))
            lsCTHD.Items.Add(item)
        Next
    End Sub

    Private Sub lsCTHD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsCTHD.SelectedIndexChanged
        If lsCTHD.SelectedItems.Count = 1 Then
            For Each List As ListViewItem In lsCTHD.SelectedItems
                txtMaCTHD.Text = List.SubItems(1).Text
                txtMaHDCTHD.Text = List.SubItems(2).Text
                txtMaSPCTHD.Text = List.SubItems(3).Text
                txtTenSPCTHD.Text = List.SubItems(4).Text
                txtDonGiaCTHD.Text = List.SubItems(5).Text
                txtSoLuongCTHD.Text = List.SubItems(6).Text
                txtThanhTienCTHD.Text = List.SubItems(7).Text
            Next
        End If
    End Sub

    Private Sub btnThemCTHD_Click(sender As Object, e As EventArgs) Handles btnThemCTHD.Click
        If txtTenSPCTHD.Text = "" Or txtDonGiaCTHD.Text = "" Or txtSoLuongCTHD.Text = "" Then
            MsgBox("Bạn cần nhập đầy đủ thông tin !")
        Else

            sqlConnect.ExecuteNoneQuery("Insert into ChiTietHoaDon(MaHD,MaSP,TenSP,DonGia,SoLuong,ThanhTien) values('" + txtMaHDCTHD.Text + "', '" + txtMaSPCTHD.Text + "','" + txtTenSPCTHD.Text + "',N'" + txtDonGiaCTHD.Text + "', N'" + txtSoLuongCTHD.Text + "',N'" + txtThanhTienCTHD.Text + "')")
        End If
        LoadChiTietHoaDon()
        txtMaCTHD.Text = ""
        txtMaHDCTHD.Text = ""
        txtMaSPCTHD.Text = ""
        txtTenSPCTHD.Text = ""
        txtDonGiaCTHD.Text = ""
        txtSoLuongCTHD.Text = ""
        txtThanhTienCTHD.Text = ""
    End Sub

    Private Sub btnSuaCTHD_Click(sender As Object, e As EventArgs) Handles btnSuaCTHD.Click
        If txtMaSPCTHD.Text = "" Or txtTenSPCTHD.Text = "" Or txtDonGiaCTHD.Text = "" Or txtSoLuongCTHD.Text = "" Then
            MsgBox("Bạn cần chọn để Sữa !")
        Else
            For i As Integer = lsCTHD.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanSua As Integer = lsCTHD.SelectedIndices(i)
                Dim maCTHDCanSua As String = lsCTHD.Items(viTriCanSua).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Update ChiTietHoaDon SET MaHD = '" + txtMaHDCTHD.Text + "', MaSP ='" + txtMaSPCTHD.Text + "',TenSP ='" + txtTenSPCTHD.Text + "', DonGia = '" + txtDonGiaCTHD.Text + "',SoLuong ='" + txtSoLuongCTHD.Text + "', ThanhTien = '" + txtThanhTienCTHD.Text + "' where MaCTHD = " + maCTHDCanSua)
            Next
        End If
        LoadChiTietHoaDon()
        txtMaCTHD.Text = ""
        txtMaHDCTHD.Text = ""
        txtMaSPCTHD.Text = ""
        txtTenSPCTHD.Text = ""
        txtDonGiaCTHD.Text = ""
        txtSoLuongCTHD.Text = ""
        txtThanhTienCTHD.Text = ""
    End Sub


    Private Sub btnXoaCTHD_Click(sender As Object, e As EventArgs) Handles btnXoaCTHD.Click
        If txtTenSPCTHD.Text = "" Or txtDonGiaCTHD.Text = "" Or txtSoLuongCTHD.Text = "" Then
            MsgBox("Bạn cần chọn để xóa !")
        Else
            For i As Integer = lsCTHD.SelectedIndices.Count - 1 To 0 Step -1
                Dim viTriCanXoa As Integer = lsCTHD.SelectedIndices(i)
                Dim maCTHDCanXoa As String = lsCTHD.Items(viTriCanXoa).SubItems(1).Text
                sqlConnect.ExecuteNoneQuery("Delete from ChiTietHoaDon where MaCTHD = " + maCTHDCanXoa)

            Next
        End If
        LoadChiTietHoaDon()
        txtMaCTHD.Text = ""
        txtMaHDCTHD.Text = ""
        txtMaSPCTHD.Text = ""
        txtTenSPCTHD.Text = ""
        txtDonGiaCTHD.Text = ""
        txtSoLuongCTHD.Text = ""
        txtThanhTienCTHD.Text = ""
    End Sub


End Class
