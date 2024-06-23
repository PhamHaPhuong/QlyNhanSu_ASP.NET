<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateNV.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.UpdateNV" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cập nhật thông tin nhân viên</title>
    <style>
        .bo:after {
            content: "";
            display: table;
            width: 100%;
            clear: both;
        }
        .con {
            width: 30%;
            float: left;
        }
        .bo {
            margin-left: 10%;
        }
        .con:after {
            content: "";
            display: table;
            width: 100%;
            clear: both;
        }
        .chau1 {
            width: 35%;
            float: left;
        }
        .chau2 {
            width: 65%;
            float: left;
        }
        .label {
            margin-bottom: 7px;
        }
        .txt {
            margin: 1% 0 5%;
        }
        .xuly {
            margin-top: 50%;
        }
        #btn_Sua {
            width: 120px;
            height: 30px;
            background-color: #A0E178;
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
            border: none;
            border-radius: 10px;
            margin-right: 10px;
        }
        #btn_Thoat {
            width: 100px;
            height: 30px;
            background-color: #D2E0FB;
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
            border: none;
            border-radius: 10px;
        }
        .bo2 {
            margin: 5% 10%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Cập nhật thông tin nhân viên</h2>
            <div class="bo">
                <div class="con">
                    <div class="chau1">
                        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Mã nhân viên"></asp:Label><br /><br />
                        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Họ tên"></asp:Label><br /><br />
                        <asp:Label ID="Label4" CssClass="label" runat="server" Text="Ngày sinh"></asp:Label><br /><br />
                        <asp:Label ID="Label5" CssClass="label" runat="server" Text="Giới tính"></asp:Label><br /><br />
                        <asp:Label ID="Label6" CssClass="label" runat="server" Text="CCCD"></asp:Label><br /><br />
                        <asp:Label ID="Label7" CssClass="label" runat="server" Text="Địa chỉ"></asp:Label>
                    </div>
                    <div class="chau2">
                        <asp:DropDownList ID="ddlNhanVien" runat="server" CssClass="txt"></asp:DropDownList><br />
                        <asp:TextBox ID="txtHoTen" CssClass="txt" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtNgaySinh" CssClass="txt" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtGioiTinh" CssClass="txt" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtCCCD" CssClass="txt" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtDiaChi" CssClass="txt" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="con">
                    <div class="chau1">
                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="SDT"></asp:Label><br /><br />
                        <asp:Label ID="Label8" CssClass="label" runat="server" Text="Chức vụ"></asp:Label><br /><br />
                        <asp:Label ID="Label9" CssClass="label" runat="server" Text="Phòng ban"></asp:Label><br /><br />
                        <asp:Label ID="Label10" CssClass="label" runat="server" Text="Trình độ"></asp:Label><br /><br />
                        <asp:Label ID="Label11" CssClass="label" runat="server" Text="Dân tộc"></asp:Label><br /><br />
                        <asp:Label ID="Label12" CssClass="label" runat="server" Text="Tôn giáo"></asp:Label>
                    </div>
                    <div class="chau2">
                        <asp:TextBox ID="txtSDT" CssClass="txt" runat="server"></asp:TextBox><br />
                        <asp:DropDownList ID="ddlChucVu" runat="server" CssClass="txt"></asp:DropDownList><br />
                        <asp:DropDownList ID="ddlPhongBan" runat="server" CssClass="txt"></asp:DropDownList><br />
                        <asp:DropDownList ID="ddlTrinhDo" runat="server" CssClass="txt"></asp:DropDownList><br />
                        <asp:DropDownList ID="ddlDanToc" runat="server" CssClass="txt"></asp:DropDownList><br />
                        <asp:DropDownList ID="ddlTonGiao" runat="server" CssClass="txt"></asp:DropDownList><br />
                    </div>
                </div>
                <div class="con">
                    <div class="xuly">
                        <asp:Button ID="btn_Sua" runat="server" Text="Sửa" OnClick="btn_Sua_Click" CssClass="btn" />
                        <asp:Button ID="btn_Thoat" runat="server" Text="Thoát" CssClass="btn" />
                    </div>
                </div>
            </div>
            <div class="bo2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                        <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                        <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
                        <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
                        <asp:BoundField DataField="CCCD" HeaderText="CCCD" />
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                        <asp:BoundField DataField="SDT" HeaderText="SDT" />
                        <asp:BoundField DataField="IDChucVu" HeaderText="Chức vụ" />
                        <asp:BoundField DataField="MaPhongBan" HeaderText="Phòng ban" />
                        <asp:BoundField DataField="IDTrinhDo" HeaderText="Trình độ" />
                        <asp:BoundField DataField="IDDanToc" HeaderText="Dân tộc" />
                        <asp:BoundField DataField="IDTonGiao" HeaderText="Tôn giáo" />
                    </Columns>
                </asp:GridView>
                 <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
