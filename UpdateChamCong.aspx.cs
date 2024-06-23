using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdateChamCong : System.Web.UI.Page
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
                string query = "SELECT IDChamCong, MaLuong, NgayChamCong FROM [Chấm Công]";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView_1.DataSource = dt;
                    GridView_1.DataBind();

                    // Bind dữ liệu cho DropDownList
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "MaLuong";
                    DropDownList1.DataValueField = "MaLuong";
                    DropDownList1.DataBind();
                }
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ""; // Xóa các thông báo trước

            try
            {
                int idChamCong;
                if (!int.TryParse(IDChamCong.Text, out idChamCong))
                {
                    lblMessage.Text = "ID chấm công phải là một số nguyên.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE [Chấm Công] SET MaLuong = @MaLuong, NgayChamCong = @NgayChamCong WHERE IDChamCong = @IDChamCong";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLuong", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@NgayChamCong", NgayChamCong.Text);
                        cmd.Parameters.AddWithValue("@IDChamCong", idChamCong);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Cập nhật thành công!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                            // Reload dữ liệu sau khi cập nhật
                            LoadData();
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy ID chấm công để cập nhật.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Điều chỉnh dữ liệu trong TextBox dựa trên lựa chọn của DropDownList
            // Điều này tùy thuộc vào yêu cầu cụ thể của bạn.
        }
    }
}
