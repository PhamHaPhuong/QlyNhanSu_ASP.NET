<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePhongBan.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.UpdatePhongBan" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý phòng ban</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Sửa phòng ban</h3>
            <p>
                <asp:Label runat="server" Text="Phòng Ban"></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
            </p>
            <p>
                <asp:Label runat="server" Text="Tên Phòng Ban"></asp:Label>
                <asp:TextBox runat="server" ID="txtTen"></asp:TextBox> 
            </p>
            <p>
                <asp:Button runat="server" Text="Sửa" OnClick="Unnamed4_Click" />
                <asp:Button runat="server" Text="Thoát" />
            </p>
            <asp:GridView runat="server" AutoGenerateColumns="False" ID="GridView_2">
                <Columns>
                    <asp:BoundField DataField="MaPhongBan" HeaderText="Mã Phòng Ban" />
                    <asp:BoundField DataField="TenPhongBan" HeaderText="Tên Phòng Ban" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>

