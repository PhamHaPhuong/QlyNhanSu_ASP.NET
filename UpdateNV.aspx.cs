using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdateNV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                PopulateDropDownLists();
            }
        }

        // Hàm để hiển thị dữ liệu từ bảng Nhân Viên lên GridView
        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM [Nhân Viên]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        // Hàm để điền dữ liệu vào các DropDownList
        private void PopulateDropDownLists()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                // Đổ dữ liệu cho DropDownList Chức vụ
                string queryChucVu = "SELECT * FROM [Chức vụ]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryChucVu, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlChucVu.DataSource = dt;
                    ddlChucVu.DataTextField = "TenChucVu"; // Tên trường chứa dữ liệu hiển thị
                    ddlChucVu.DataValueField = "IDChucVu"; // Tên trường chứa giá trị của mục
                    ddlChucVu.DataBind();
                }

                // Đổ dữ liệu cho DropDownList Phòng ban
                string queryPhongBan = "SELECT * FROM [Phòng ban]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryPhongBan, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlPhongBan.DataSource = dt;
                    ddlPhongBan.DataTextField = "TenPhongBan";
                    ddlPhongBan.DataValueField = "MaPhongBan";
                    ddlPhongBan.DataBind();
                }

                // Đổ dữ liệu cho DropDownList Trình độ
                string queryTrinhDo = "SELECT * FROM [Trình độ]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryTrinhDo, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlTrinhDo.DataSource = dt;
                    ddlTrinhDo.DataTextField = "TenTrinhDo";
                    ddlTrinhDo.DataValueField = "IDTrinhDo";
                    ddlTrinhDo.DataBind();
                }

                // Đổ dữ liệu cho DropDownList Dân tộc
                string queryDanToc = "SELECT * FROM [Dân tộc]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryDanToc, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlDanToc.DataSource = dt;
                    ddlDanToc.DataTextField = "TenDanToc";
                    ddlDanToc.DataValueField = "IDDanToc";
                    ddlDanToc.DataBind();
                }

                // Đổ dữ liệu cho DropDownList Tôn giáo
                string queryTonGiao = "SELECT * FROM [Tôn giáo]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(queryTonGiao, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlTonGiao.DataSource = dt;
                    ddlTonGiao.DataTextField = "TenTonGiao";
                    ddlTonGiao.DataValueField = "IDTonGiao";
                    ddlTonGiao.DataBind();
                }
            }
        }

        // Sự kiện khi người dùng chọn một dòng trong GridView
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                txtMaNhanVien.Text = row.Cells[1].Text; // Thay thế 1 bằng chỉ số của cột MaNhanVien trong GridView
                txtHoTen.Text = row.Cells[2].Text; // Thay thế 2 bằng chỉ số của cột HoTen trong GridView
                txtNgaySinh.Text = row.Cells[3].Text; // Thay thế 3 bằng chỉ số của cột NgaySinh trong GridView
                txtGioiTinh.Text = row.Cells[4].Text; // Thay thế 4 bằng chỉ số của cột GioiTinh trong GridView
                txtCCCD.Text = row.Cells[5].Text; // Thay thế 5 bằng chỉ số của cột CCCD trong GridView
                txtDiaChi.Text = row.Cells[6].Text; // Thay thế 6 bằng chỉ số của cột DiaChi trong GridView
                txtSDT.Text = row.Cells[7].Text; // Thay thế 7 bằng chỉ số của cột SDT trong GridView

                // Chọn giá trị của các DropDownList tương ứng với dòng đã chọn trong GridView
                ddlChucVu.SelectedValue = row.Cells[8].Text; // Thay thế 8 bằng chỉ số của cột IDChucVu trong GridView
                ddlPhongBan.SelectedValue = row.Cells[9].Text; // Thay thế 9 bằng chỉ số của cột MaPhongBan trong GridView
                ddlTrinhDo.SelectedValue = row.Cells[10].Text; // Thay thế 10 bằng chỉ số của cột IDTrinhDo trong GridView
                ddlDanToc.SelectedValue = row.Cells[11].Text; // Thay thế 11 bằng chỉ số của cột IDDanToc trong GridView
                ddlTonGiao.SelectedValue = row.Cells[12].Text; // Thay thế 12 bằng chỉ số của cột IDTonGiao trong GridView
            }
        }

        // Sự kiện khi người dùng nhấn nút "Sửa"
        protected void btn_Sua_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            string hoTen = txtHoTen.Text;
            string ngaySinh = txtNgaySinh.Text;
            string gioiTinh = txtGioiTinh.Text;
            string cccd = txtCCCD.Text;
            string diaChi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string idChucVu = ddlChucVu.SelectedValue;
            string maPhongBan = ddlPhongBan.SelectedValue;
            string idTrinhDo = ddlTrinhDo.SelectedValue;
            string idDanToc = ddlDanToc.SelectedValue;
            string idTonGiao = ddlTonGiao.SelectedValue;

            // Cập nhật dữ liệu vào cơ sở dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string updateQuery = @"
                    UPDATE [Nhân Viên] 
                    SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, CCCD = @CCCD, DiaChi = @DiaChi, SDT = @SDT, 
                        IDChucVu = @IDChucVu, MaPhongBan = @MaPhongBan, IDTrinhDo = @IDTrinhDo, IDDanToc = @IDDanToc, IDTonGiao = @IDTonGiao 
                    WHERE MaNhanVien = @MaNhanVien";

                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
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
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        // Hiển thị thông báo thành công
                        lblMessage.Text = "Cập nhật nhân viên thành công.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                        // Sau khi cập nhật thành công, làm mới GridView và các TextBox, DropDownList
                        BindGridView();
                        ClearFields();
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi
                        lblMessage.Text = "Cập nhật nhân viên thất bại.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        // Hàm để xóa nội dung các TextBox và DropDownList sau khi cập nhật thành công
        private void ClearFields()
        {
            txtMaNhanVien.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtNgaySinh.Text = string.Empty;
            txtGioiTinh.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;

            // Đặt lại SelectedIndex cho các DropDownList
            ddlChucVu.SelectedIndex = 0;
            ddlPhongBan.SelectedIndex = 0;
            ddlTrinhDo.SelectedIndex = 0;
            ddlDanToc.SelectedIndex = 0;
            ddlTonGiao.SelectedIndex = 0;
        }
    }
}
