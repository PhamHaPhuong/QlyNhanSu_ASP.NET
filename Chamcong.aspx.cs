using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT IDChamCong, MaLuong, NgayChamCong, TrangThai FROM [Chấm Công]";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int idChamCong;
                if (int.TryParse(e.CommandArgument.ToString(), out idChamCong))
                {
                    DeleteChamCong(idChamCong);
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                }
                else
                {
                    Response.Write("<script>alert('Không thể chuyển đổi CommandArgument thành int.');</script>");
                }
            }
        }

        private void DeleteChamCong(int idChamCong)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM [Chấm Công] WHERE IDChamCong = @IDChamCong";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDChamCong", idChamCong);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            // Hiển thị thông báo xóa thành công
                            Response.Write("<script>alert('Xóa thành công!');</script>");
                        }
                        else
                        {
                            // Hiển thị thông báo không tìm thấy bản ghi để xóa
                            Response.Write("<script>alert('Không tìm thấy bản ghi để xóa! ID: " + idChamCong + "');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi
                        Response.Write("<script>alert('Lỗi: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        protected void them_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện thêm chấm công
        }
    }
}
