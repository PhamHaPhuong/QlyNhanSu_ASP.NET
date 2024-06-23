using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class AddNv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDownLists();
                LoadGridView();
            }
        }

        private void LoadGridView()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM [Nhân Viên]";
                using (OleDbDataAdapter da = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        private void LoadDropDownLists()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Load Chức Vụ
                    string chucVuQuery = "SELECT IDChucVu, TenChucVu FROM [Chức Vụ]";
                    using (OleDbCommand cmd = new OleDbCommand(chucVuQuery, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlChucVu.DataSource = reader;
                        ddlChucVu.DataTextField = "TenChucVu";
                        ddlChucVu.DataValueField = "IDChucVu";
                        ddlChucVu.DataBind();
                    }

                    // Load Phòng Ban
                    string phongBanQuery = "SELECT MaPhongBan, TenPhongBan FROM [Phòng Ban]";
                    using (OleDbCommand cmd = new OleDbCommand(phongBanQuery, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlPhongBan.DataSource = reader;
                        ddlPhongBan.DataTextField = "TenPhongBan";
                        ddlPhongBan.DataValueField = "MaPhongBan";
                        ddlPhongBan.DataBind();
                    }

                    // Load Trình Độ
                    string trinhDoQuery = "SELECT IDTrinhDo, TrinhDo FROM [Học Vấn]";
                    using (OleDbCommand cmd = new OleDbCommand(trinhDoQuery, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlTrinhDo.DataSource = reader;
                        ddlTrinhDo.DataTextField = "TrinhDo";
                        ddlTrinhDo.DataValueField = "IDTrinhDo";
                        ddlTrinhDo.DataBind();
                    }

                    // Load Dân Tộc
                    string danTocQuery = "SELECT IDDanToc, TenDanToc FROM [Dân Tộc]";
                    using (OleDbCommand cmd = new OleDbCommand(danTocQuery, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlDanToc.DataSource = reader;
                        ddlDanToc.DataTextField = "TenDanToc";
                        ddlDanToc.DataValueField = "IDDanToc";
                        ddlDanToc.DataBind();
                    }

                    // Load Tôn Giáo
                    string tonGiaoQuery = "SELECT IDTonGiao, TenTonGiao FROM [Tôn Giáo]";
                    using (OleDbCommand cmd = new OleDbCommand(tonGiaoQuery, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlTonGiao.DataSource = reader;
                        ddlTonGiao.DataTextField = "TenTonGiao";
                        ddlTonGiao.DataValueField = "IDTonGiao";
                        ddlTonGiao.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        protected void btn_Them_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh;
            bool isNgaySinhValid = DateTime.TryParse(txtNgaySinh.Text, out ngaySinh);
            string gioiTinh = txtGioiTinh.Text;
            string cccd = txtCCCD.Text;
            string diaChi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            int idChucVu = int.Parse(ddlChucVu.SelectedValue);
            string maPhongBan = ddlPhongBan.SelectedValue;
            int idTrinhDo = int.Parse(ddlTrinhDo.SelectedValue);
            int idDanToc = int.Parse(ddlDanToc.SelectedValue);
            int idTonGiao = int.Parse(ddlTonGiao.SelectedValue);

            if (!isNgaySinhValid)
            {
                lblMessage.Text = "Ngày sinh không hợp lệ.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = @"
                INSERT INTO [Nhân Viên] (MaNhanVien, HoTen, NgaySinh, GioiTinh, CCCD, DiaChi, SDT, IDChucVu, MaPhongBan, IDTrinhDo, IDDanToc, IDTonGiao)
                VALUES (@MaNhanVien, @HoTen, @NgaySinh, @GioiTinh, @CCCD, @DiaChi, @SDT, @IDChucVu, @MaPhongBan, @IDTrinhDo, @IDDanToc, @IDTonGiao)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", cccd);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        cmd.Parameters.AddWithValue("@IDChucVu", idChucVu);
                        cmd.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                        cmd.Parameters.AddWithValue("@IDTrinhDo", idTrinhDo);
                        cmd.Parameters.AddWithValue("@IDDanToc", idDanToc);
                        cmd.Parameters.AddWithValue("@IDTonGiao", idTonGiao);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Thêm nhân viên thành công.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                            // Load lại GridView để hiển thị nhân viên mới thêm
                            // LoadGridView();
                        }
                        else
                        {
                            lblMessage.Text = "Thêm nhân viên thất bại.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        LoadGridView();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
