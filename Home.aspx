<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BaiTapLon_QlyNhanSu.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css" />
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

    </style>
<body>
    <form id="form1" runat="server">
        <div class="dad">
            <div class="son1">
                <div class="header">
                    <h2>Quản lý nhân sự</h2>
                </div>
                <div class="nav">
                    <div class="chon"><a href="Home.aspx"><i class="fa fa-home" aria-hidden="true"></i>Trang chủ</a> </div>
                    <div><a href="Nhanvien.aspx"><i class="fas fa-users"></i>Nhân viên</a></div>
                    <div><a href="Chamcong.aspx"><i class="fas fa-hand-pointer"></i>Chấm công</a></div>
                    <div><a href="Chucvu.aspx"><i class="fas fa-briefcase"></i>Chức vụ</a></div>
                    <div><a href="Phongban.aspx"><i class="fas fa-building"></i>Phòng ban</a></div>
                    <div><a href="Luong.aspx"><i class="far fa-calendar-alt"></i>Lương</a></div>
                    <div><a href="Khenthuong.aspx"><i class="fas fa-file-medical"></i>Khen thưởng</a></div>
                    <div><a href="Kyluat.aspx"><i class="fas fa-file-download"></i>Kỷ luật</a></div>
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
                    <div class="slider">
                        <div class="row">
                            <div class="column1" style="">
                                <div>                                
                                <span class="client1">
                                    <img src="\img\anh1.png" alt="Alternate Text" />
                                </span>
                                <span class="client2">
                                    <b>Số lượng nhân viên hiện tại</b> <br />
                                    Tổng <asp:Label ID="nhanvien" runat="server" Text=""></asp:Label> nhân viên
                                </span>
                                 </div>
                            </div>
                            <div class="column2">
                                <div>                                
                                    <span class="client1">
                                        <img src="\img\anh2.png" alt="Alternate Text" />
                                    </span>
                                    <span class="client2">
                                        <b>Phòng ban có chỉ tiêu tốt nhất</b> <br />
                                            Phòng ban  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </span>
                                </div>
                            </div>
                            <div class="column3">
                                <div>                                
                                    <span class="client1">
                                        <img src="\img\anh3.png" alt="Alternate Text" />
                                    </span>
                                    <span class="client2">
                                        <b>Số lượng nhân viên sinh nhật trong tháng</b> <br />
                                            Tổng <asp:Label ID="Label2" runat="server" Text=""></asp:Label> nhân viên
                                    </span>
                                </div>
                            </div>
                        </div>
                        <h2>Báo cáo đánh giá hiệu quả tuyển dụng</h2>
                        <div class="thongke">
                            Thống kê bảng ở đây
                        </div>
                    </div>



                </div>            
            </div>
        </div>
    </form>
</body>
</html>
