using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdatePhongBan : System.Web.UI.Page
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDownList(); // Load dữ liệu vào DropDownList khi trang chưa PostBack
                BindGridView(); // Load dữ liệu vào GridView
            }
        }

        protected void BindDropDownList()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaPhongBan, TenPhongBan FROM [Phòng Ban]";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "TenPhongBan";
                DropDownList1.DataValueField = "MaPhongBan";
                DropDownList1.DataBind();
            }
        }

        protected void BindGridView()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaPhongBan, TenPhongBan FROM [Phòng Ban]";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView_2.DataSource = dt;
                GridView_2.DataBind();
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTen.Text) && DropDownList1.SelectedValue != "")
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE [Phòng Ban] SET TenPhongBan = ? WHERE MaPhongBan = ?";
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", txtTen.Text);
                            cmd.Parameters.AddWithValue("@p2", DropDownList1.SelectedValue);

                            int affectedRows = cmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                BindGridView(); // Refresh lại GridView sau khi cập nhật thành công

                                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                                    "alert('Cập nhật thành công');", true);
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                                    "alert('Cập nhật thất bại');", true);
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                        "alert('Tên phòng ban không được để trống và phải chọn một phòng ban để cập nhật');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                    "alert('Lỗi: " + ex.Message + "');", true);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT TenPhongBan FROM [Phòng Ban] WHERE MaPhongBan = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@p1", DropDownList1.SelectedValue);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        txtTen.Text = result.ToString();
                    }
                }
            }
        }
    }
}
