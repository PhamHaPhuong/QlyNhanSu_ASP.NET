using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdateNV : System.Web.UI.Page
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindNhanVienDropDownList();
                BindDropDownLists();
                BindGridView();
            }
        }

        private void BindNhanVienDropDownList()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaNhanVien, HoTen FROM [Nhân Viên]";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlNhanVien.DataSource = dt;
                ddlNhanVien.DataTextField = "HoTen";
                ddlNhanVien.DataValueField = "MaNhanVien";
                ddlNhanVien.DataBind();
            }
        }

        private void BindGridView()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaNhanVien, HoTen, NgaySinh, GioiTinh, CCCD, DiaChi, SDT, IDChucVu, MaPhongBan, IDTrinhDo, IDDanToc, IDTonGiao FROM [Nhân Viên]";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void BindDropDownLists()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                try
                {
                    // Chức vụ
                    string chucVuQuery = "SELECT IDChucVu, TenChucVu FROM [Chức Vụ]";
                    OleDbDataAdapter chucVuDa = new OleDbDataAdapter(chucVuQuery, conn);
                    DataTable chucVuDt = new DataTable();
                    chucVuDa.Fill(chucVuDt);
                    ddlChucVu.DataSource = chucVuDt;
                    ddlChucVu.DataTextField = "TenChucVu";
                    ddlChucVu.DataValueField = "IDChucVu";
                    ddlChucVu.DataBind();
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi
                    Console.WriteLine("Lỗi tại Chức vụ: " + ex.Message);
                }

                try
                {
                    // Phòng ban
                    string phongBanQuery = "SELECT MaPhongBan, TenPhongBan FROM [Phòng Ban]";
                    OleDbDataAdapter phongBanDa = new OleDbDataAdapter(phongBanQuery, conn);
                    DataTable phongBanDt = new DataTable();
                    phongBanDa.Fill(phongBanDt);
                    ddlPhongBan.DataSource = phongBanDt;
                    ddlPhongBan.DataTextField = "TenPhongBan";
                    ddlPhongBan.DataValueField = "MaPhongBan";
                    ddlPhongBan.DataBind();
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi
                    Console.WriteLine("Lỗi tại Phòng ban: " + ex.Message);
                }

                try
                {
                    // Trình độ
                    string trinhDoQuery = "SELECT IDTrinhDo, TrinhDo FROM [Học Vấn]";
                    OleDbDataAdapter trinhDoDa = new OleDbDataAdapter(trinhDoQuery, conn);
                    DataTable trinhDoDt = new DataTable();
                    trinhDoDa.Fill(trinhDoDt);
                    ddlTrinhDo.DataSource = trinhDoDt;
                    ddlTrinhDo.DataTextField = "TrinhDo";
                    ddlTrinhDo.DataValueField = "IDTrinhDo";
                    ddlTrinhDo.DataBind();
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi
                    Console.WriteLine("Lỗi tại Trình độ: " + ex.Message);
                }

                try
                {
                    // Dân tộc
                    string danTocQuery = "SELECT IDDanToc, TenDanToc FROM [Dân Tộc]";
                    OleDbDataAdapter danTocDa = new OleDbDataAdapter(danTocQuery, conn);
                    DataTable danTocDt = new DataTable();
                    danTocDa.Fill(danTocDt);
                    ddlDanToc.DataSource = danTocDt;
                    ddlDanToc.DataTextField = "TenDanToc";
                    ddlDanToc.DataValueField = "IDDanToc";
                    ddlDanToc.DataBind();
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi
                    Console.WriteLine("Lỗi tại Dân tộc: " + ex.Message);
                }

                try
                {
                    // Tôn giáo
                    string tonGiaoQuery = "SELECT IDTonGiao, TenTonGiao FROM [Tôn Giáo]";
                    OleDbDataAdapter tonGiaoDa = new OleDbDataAdapter(tonGiaoQuery, conn);
                    DataTable tonGiaoDt = new DataTable();
                    tonGiaoDa.Fill(tonGiaoDt);
                    ddlTonGiao.DataSource = tonGiaoDt;
                    ddlTonGiao.DataTextField = "TenTonGiao";
                    ddlTonGiao.DataValueField = "IDTonGiao";
                    ddlTonGiao.DataBind();
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi
                    Console.WriteLine("Lỗi tại Tôn giáo: " + ex.Message);
                }
            }
        }

        protected void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlNhanVien.SelectedValue != "")
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE [Nhân Viên] SET HoTen = ?, NgaySinh = ?, GioiTinh = ?, CCCD = ?, DiaChi = ?, SDT = ?, IDChucVu = ?, MaPhongBan = ?, IDTrinhDo = ?, IDDanToc = ?, IDTonGiao = ? WHERE MaNhanVien = ?";
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                            cmd.Parameters.AddWithValue("@NgaySinh", txtNgaySinh.Text);
                            cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@IDChucVu", ddlChucVu.SelectedValue);
                            cmd.Parameters.AddWithValue("@MaPhongBan", ddlPhongBan.SelectedValue);
                            cmd.Parameters.AddWithValue("@IDTrinhDo", ddlTrinhDo.SelectedValue);
                            cmd.Parameters.AddWithValue("@IDDanToc", ddlDanToc.SelectedValue);
                            cmd.Parameters.AddWithValue("@IDTonGiao", ddlTonGiao.SelectedValue);
                            cmd.Parameters.AddWithValue("@MaNhanVien", ddlNhanVien.SelectedValue);

                            int affectedRows = cmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                BindGridView(); // Refresh lại GridView sau khi cập nhật thành công
                                lblMessage.Text = "Cập nhật thành công";
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                lblMessage.Text = "Cập nhật thất bại";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Vui lòng chọn nhân viên để cập nhật";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ddlNhanVien.SelectedValue = row.Cells[0].Text;
            txtHoTen.Text = row.Cells[1].Text;
            txtNgaySinh.Text = row.Cells[2].Text;
            txtGioiTinh.Text = row.Cells[3].Text;
            txtCCCD.Text = row.Cells[4].Text;
            txtDiaChi.Text = row.Cells[5].Text;
            txtSDT.Text = row.Cells[6].Text;
            ddlChucVu.SelectedValue = row.Cells[7].Text;
            ddlPhongBan.SelectedValue = row.Cells[8].Text;
            ddlTrinhDo.SelectedValue = row.Cells[9].Text;
            ddlDanToc.SelectedValue = row.Cells[10].Text;
            ddlTonGiao.SelectedValue = row.Cells[11].Text;
        }
    }
}
