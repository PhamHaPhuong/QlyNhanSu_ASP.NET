<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddKL.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.AddKL" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm kỷ luật </title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Thêm kỷ luật </h2>
            <div class="bo">
                <div class="con">
                    <div class="chau1">
                        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Mã nhân viên "></asp:Label><br /> <br />
                        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Họ tên "></asp:Label><br /> <br />
                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="Lý do"></asp:Label><br /> <br />
                    </div>
                      <div class="chau2">

                      <asp:TextBox ID="txtMaNhanVien" CssClass="txt" runat="server"></asp:TextBox>                        
                      <asp:TextBox ID="txtHoTen" CssClass="txt" runat="server"></asp:TextBox>
                      <asp:TextBox ID="txtLyDo" CssClass="txt" runat="server"></asp:TextBox>
     
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
                        <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên"></asp:BoundField>
                        <asp:BoundField DataField="HoTen" HeaderText="Họ tên"></asp:BoundField>
                        <asp:BoundField DataField="LyDo" HeaderText="Lý do"></asp:BoundField>
                       
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

