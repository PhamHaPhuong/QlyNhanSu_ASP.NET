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
    public partial class AddChucVu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                String SQL = string.Format("Select * From [Chức Vụ]");
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
                    string IDChucVu = txtIDChucVu.Text;
                    string TenChucVu = txtTenChucVu.Text;
                    

                    string insertQuery = "INSERT INTO [Chức Vụ] (IDChucVu, TenChucVu ) " +
                        "VALUES (@IDChucVu, @TenChucVu )";
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDChucVu", IDChucVu);
                        cmd.Parameters.AddWithValue("@TenChucVu", TenChucVu);
                       
                        cmd.ExecuteNonQuery();
                    }

                    String SQL = string.Format("Select * From [Chức Vụ]");
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
