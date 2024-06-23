<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateChamCong.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.UpdateChamCong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sửa chấm công</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Sửa chấm công</h3>
            <p>
                <asp:Label runat="server" Text="Mã Lương "></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
            </p>
            <p>
    <asp:Label runat="server" Text="Mã Lương "></asp:Label>
    <asp:DropDownList runat="server" ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
</p>
            <p>
                <asp:Label runat="server" Text="Ngày chấm "></asp:Label>
                <asp:TextBox runat="server" ID="NgayChamCong"></asp:TextBox> 
            </p>
            <p>
                <asp:Button runat="server" Text="Sửa" OnClick="Unnamed4_Click" />
                <asp:Button runat="server" Text="Thoát" />
            </p>
            <asp:GridView runat="server" AutoGenerateColumns="False" ID="GridView_1">
                <Columns>
                    <asp:BoundField DataField="IDChamCong" HeaderText="ID Chấm Công" />
                    <asp:BoundField DataField="MaLuong" HeaderText="Mã Lương" />
                    <asp:BoundField DataField="NgayChamCong" HeaderText="Ngày Chấm Công" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
