<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Themnv.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.WebForm11" %>

<!DOCTYPE html>
<script runat="server">

    protected void btn_Them_Click(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    .bo:after{
        content: "";
        display: table;
        width: 100%;
        clear: both;
    }
    .con{
        width: 30%;
        float: left;
    }
    .bo{
        margin-left: 10%;
    }
    .con:after{
        content: "";
        display: table;
        width: 100%;
        clear: both;

    }
    .chau1{
        width: 35%;
        float: left;
    }
    .chau2{
        width: 65%;
        float:left;
    }
    .label{
        margin-bottom: 7px;

    }
    .txt{
        margin: 1% 0 5%;
    }
    .xuly{
        margin-top: 50%;
    }
    #btn_Them{
        width: 120px ;
        height: 30px;
        background-color: #F9F3CC;
        box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        border: none;
        border-radius: 10px;
        margin-right: 10px;
    }
    #btn_Thoat{
        width: 100px ;
        height: 30px;
        background-color: #D2E0FB;
        box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        border: none;
        border-radius: 10px;
    }
    .bo2{
        margin: 5% 10%;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Thêm nhân viên </h2>
            <div class="bo">
                <div class="con">
                    <div class="chau1">
                        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Mã nhân viên"></asp:Label><br /> <br />
                        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Họ tên"></asp:Label><br /> <br />
                        <asp:Label ID="Label4" CssClass="label" runat="server" Text="Ngày sinh"></asp:Label><br /> <br />
                        <asp:Label ID="Label5" CssClass="label" runat="server" Text="Giới tính"></asp:Label><br /> <br />
                        <asp:Label ID="Label6" CssClass="label" runat="server" Text="CCCD"></asp:Label><br /> <br />
                        <asp:Label ID="Label7" CssClass="label" runat="server" Text="Địa chỉ"></asp:Label>
                    </div>
                    <div class="chau2">
                        <asp:TextBox ID="TextBox4" CssClass="txt" runat="server"></asp:TextBox>                        
                        <asp:TextBox ID="TextBox2" CssClass="txt" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" CssClass="txt" runat="server"></asp:TextBox> <br /> 
                        <asp:TextBox ID="TextBox3" CssClass="txt" runat="server"></asp:TextBox> <br /> 
                        
                        <asp:TextBox ID="TextBox6" CssClass="txt" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox1" CssClass="txt" runat="server"></asp:TextBox>
                    </div>
                    
                </div>
                <div class="con">
                     <div class="chau1">
                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="SDT"></asp:Label><br /> <br />
                        <asp:Label ID="Label8" CssClass="label" runat="server" Text="Chức vụ"></asp:Label><br /> <br />
                        <asp:Label ID="Label9" CssClass="label" runat="server" Text="Phòng ban"></asp:Label><br /> <br />
                        <asp:Label ID="Label10" CssClass="label" runat="server" Text="Trình độ "></asp:Label><br /> <br />
                        <asp:Label ID="Label11" CssClass="label" runat="server" Text="Dân tộc"></asp:Label><br /> <br />
                        <asp:Label ID="Label12" CssClass="label" runat="server" Text="Tôn giáo"></asp:Label>
                    </div>
                    <div class="chau2">
                        <asp:TextBox ID="TextBox7" CssClass="txt" runat="server"></asp:TextBox>  <br />                      
                        <asp:DropDownList ID="DropDownList2"  CssClass="" runat="server"></asp:DropDownList> <br /> <br /> 
                        <asp:DropDownList ID="DropDownList3"  CssClass="" runat="server"></asp:DropDownList> <br />  <br />
                        <asp:DropDownList ID="DropDownList4"  CssClass="" runat="server"></asp:DropDownList> <br />  <br />
                        <asp:DropDownList ID="DropDownList5"  CssClass="" runat="server"></asp:DropDownList> <br /> <br />
                        <asp:DropDownList ID="DropDownList1"  CssClass="" runat="server"></asp:DropDownList> <br /> <br />
                        
                    </div>
                    
                </div>
                <div class="con">
                    <div class="xuly">
                        <asp:Button ID="btn_Them" runat="server" Text="Thêm " OnClick="btn_Them_Click" /><asp:Button ID="btn_Thoat" runat="server" Text="Thoát" />

                    </div>
                </div>


            </div>
            <div class="bo2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataFormatString="MaNhanVien" HeaderText="M&#227; nv"></asp:BoundField>
                        <asp:BoundField DataField="HoTen" HeaderText="Họ T&#234;n"></asp:BoundField>
                        <asp:BoundField DataField="NgaySinh" HeaderText="Ng&#224;y Sinh"></asp:BoundField>
                        <asp:BoundField DataField="GioiTinh" HeaderText="Giới t&#237;nh"></asp:BoundField>
                        <asp:BoundField DataField="CCCD" HeaderText="CCCD"></asp:BoundField>
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ"></asp:BoundField>
                        <asp:BoundField DataField="SDT" HeaderText="SDT"></asp:BoundField>
                        <asp:BoundField DataField="IDChucVu" HeaderText="Chức vụ"></asp:BoundField>
                        <asp:BoundField DataField="MaPhongBan" HeaderText="Ph&#242;ng ban"></asp:BoundField>
                        <asp:BoundField DataField="IDTrinhDo" HeaderText="Tr&#236;nh độ"></asp:BoundField>
                        <asp:BoundField DataField="IDDanToc" HeaderText="D&#226;n tộc"></asp:BoundField>
                        <asp:BoundField DataField="IDTonGiao" HeaderText="T&#244;n gi&#225;o"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
