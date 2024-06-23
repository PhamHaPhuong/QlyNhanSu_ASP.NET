<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kyluat.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="\css\home.css" rel="stylesheet" />
</head>

    <script type="text/javascript">
        function searchProducts() {
            var txtSearch = document.getElementById('<%= txtSearch.ClientID %>').value;
            __doPostBack('txtSearch', txtSearch);
        }

    </script>
    <style>
.thaotac{
      display: inline-block;
        }
.search {
    position: relative;
    width: 100px;
    
}

.searchinput {
    width: 100%;
    padding: 10px 20px 10px 40px;
    border-radius: 5px;
    border: 1px solid #ccc;
    box-shadow: 0 8px 8px rgba(0,0,0,0.1);
    font-size: 16px;
}

.search i {
    position: absolute;
    top: 50%;
    left: 15px;
    transform: translateY(-50%);
    font-size: 18px;
    color: black;
}
.form{
    padding: 3% 5%
}
        #Print {
            width: 80px;
            height:40px;
            border:none;
            background-color: #DBDADA;
            border-radius: 20px;
            box-shadow: 0px 4px 8px rgba(0,0,0,0.3);        
        }
        .print-button {
  
            padding-left: 30px;
        
             background-image: url('https://path-to-your-print-icon.png');
             background-repeat: no-repeat;
             background-position: left center; /* Adjust icon position */
             padding: 10px 20px; /* Adjust padding to suit your design */
             text-align: center; /* Center text horizontally */
        }

        .print-button::before {
            content: url('https://path-to-your-print-icon.png'); 
            position: absolute;
            left: 10px;
            top: 50%;
            transform: translateY(-50%);
        }
        #them{
           width: 180px;
            height:40px;
            border:none;
            background-color: #F9F3CC;
            border-radius: 20px;
            box-shadow: 0px 4px 8px rgba(0,0,0,0.3);
        }
        .table{
            margin: 3% 0;
            padding: 2% 5%;
            background-color: white;
        }

    </style>
<body>
    <form id="form1" runat="server">
        <div class="dad">
            <div class="son1">
                <div class="header">
                    <h2>Quản lý nhân sự</h2>
                </div>
                <div class="nav">
                    <div><a href="Home.aspx"><i class="fa fa-home" aria-hidden="true"></i>Trang chủ</a> </div>
                    <div><a href="Nhanvien.aspx"><i class="fas fa-users"></i>Nhân viên</a></div>
                    <div><a href="Chamcong.aspx"><i class="fas fa-hand-pointer"></i>Chấm công</a></div>
                    <div><a href="Chucvu.aspx"><i class="fas fa-briefcase"></i>Chức vụ</a></div>
                    <div><a href="Phongban.aspx"><i class="fas fa-building"></i>Phòng ban</a></div>
                    <div><a href="Luong.aspx"><i class="far fa-calendar-alt"></i>Lương</a></div>
                    <div><a href="Khenthuong.aspx"><i class="fas fa-file-medical"></i>Khen thưởng</a></div>
                    <div class="chon"><a href="Kyluat.aspx"><i class="fas fa-file-download"></i>Kỷ luật</a></div>
                </div>
            </div>
            <div class="son2">
                <div class="header2">
                    <div class="search-container">
                        <i class="fas fa-search"></i>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="search-input" placeholder="Tìm kiếm tại đây ..." onkeyup="searchProducts()" AutoPostBack="true"></asp:TextBox>
                     </div>
                </div>
                <div class="content">
                    <div class="form">
                        <div class="thaotac"><h2>Danh sách kỷ luật</h2></div>
                        <div class="thaotac" style="float:right;">
                            <asp:Button ID="them" runat="server" Text="Thêm kỷ luật" OnClick="them_Click1" />
                        </div>
                        
                        <div class="table">
                            <div class="thaotac">
                                <div class="search">
                                    <i class="fas fa-search"></i>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="searchinput" placeholder="Tìm kiếm  ..." onkeyup="searchProducts()" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="thaotac" style="float:right;">
                                
                                <asp:Button ID="Print" runat="server" Text="In" CssClass="print-button" OnClientClick="printPage()" />
                            </div>

                            <div class="bang">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="MaNhanVien" HeaderText="Mã Nhân Viên"></asp:BoundField>
                                        <asp:BoundField DataField="HoTen" HeaderText="Tên Nhân Viên"></asp:BoundField>
                                        <asp:BoundField DataField="LyDo" HeaderText="Lý do"></asp:BoundField>
                                        
                                         <asp:TemplateField HeaderText="Thao tác">
                                         <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="DeleteRow" ImageUrl="~/Images/delete-icon.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                        </ItemTemplate>
                                        </asp:TemplateField>           
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    



                </div>            
            </div>
        </div>
    </form>
</body>
</html>
