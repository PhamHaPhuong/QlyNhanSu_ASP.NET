<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateChucVu.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.UpdateChucVu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý chức vụ</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Sửa chức vụ</h3>
            <p>
                <asp:Label runat="server" Text="Chức Vụ"></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
            </p>
            <p>
                <asp:Label runat="server" Text="Tên Chức Vụ"></asp:Label>
                <asp:TextBox runat="server" ID="txtTen"></asp:TextBox> 
            </p>
            <p>
                <asp:Button runat="server" Text="Sửa" OnClick="Unnamed4_Click" />
                <asp:Button runat="server" Text="Thoát" />
            </p>
            <asp:GridView runat="server" AutoGenerateColumns="False" ID="GridView_1">
                <Columns>
                    <asp:BoundField DataField="IDChucVu" HeaderText="Chức Vụ" />
                    <asp:BoundField DataField="TenChucVu" HeaderText="Tên Chức Vụ" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>