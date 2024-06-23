<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateKL.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.UpdateKL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý kỷ luật</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Sửa kỷ luật</h3>
            <p>
                <asp:Label runat="server" Text="Mã nhân viên" ID="MaNhanVien"></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
            </p>
            <p>
                <asp:Label runat="server" Text="Họ tên" ID="HoTen"></asp:Label>
                <asp:TextBox runat="server" ID="txtHoTen"></asp:TextBox> 
            </p>
            <p>
                <asp:Label runat="server" Text="Lý do" ID="LyDo"></asp:Label>
                <asp:TextBox runat="server" ID="txtLyDo"></asp:TextBox>
            </p>
            <p>
                <asp:Button runat="server" Text="Sửa" OnClick="Unnamed4_Click" />
                <asp:Button runat="server" Text="Thoát" />
            </p>
            <asp:GridView runat="server" AutoGenerateColumns="False" ID="GridView_1">
                <Columns>
                    <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                    <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                    <asp:BoundField DataField="LyDo" HeaderText="Lý do" />
                </Columns>
            </asp:GridView>
             <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>

