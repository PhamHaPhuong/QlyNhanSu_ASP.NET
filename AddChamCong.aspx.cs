using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class AddChamCong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                String SQL = string.Format("Select * From [Chấm Công]");
                OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        protected void btn_Them_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string IDChamCong = txtIDChamCong.Text;
                    string MaLuong = txtMaLuong.Text;
                    string NgayChamCong = txtNgayChamCong.Text;
                    string TrangThai = txtTrangThai.Text;

                    string insertQuery = "INSERT INTO [Chấm Công ] (IDChamCong, MaLuong, NgayChamCong , TrangThai  ) " +
                        "VALUES (@IDChamCong, @MaLuong , @NgayChamCong , @TrangThai )";
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDChamCong", IDChamCong);
                        cmd.Parameters.AddWithValue("@MaLuong", MaLuong);
                        cmd.Parameters.AddWithValue("@NgayChamCong", NgayChamCong);
                        cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                        cmd.ExecuteNonQuery();
                    }

                    String SQL = string.Format("Select * From [Chấm Công]");
                    OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Lỗi: {ex.Message}');", true);
                }
            }
        }
    }
}