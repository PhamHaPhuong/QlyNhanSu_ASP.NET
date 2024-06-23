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
    public partial class AddKL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                String SQL = string.Format("Select * From [Kỷ Luật]");
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
                    string MaNhanVien = txtMaNhanVien.Text;
                    string HoTen = txtHoTen.Text;
                    string LyDo = txtLyDo.Text;

                    string insertQuery = "INSERT INTO [Kỷ Luật] (MaNhanVien, HoTen , LyDo ) " +
                        "VALUES (@MaNhanVien, @HoTen , @LyDo )";
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cmd.Parameters.AddWithValue("@HoTen", HoTen);
                        cmd.Parameters.AddWithValue("@LyDo", LyDo);

                        cmd.ExecuteNonQuery();
                    }

                    String SQL = string.Format("Select * From [Kỷ Luật]");
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