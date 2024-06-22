using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace BaiTapLon_QlyNhanSu
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string SQL = @"SELECT IDChucVu, TenChucVu FROM [Chức Vụ]";
                    OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    // Log error or show a message
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        protected void them_Click(object sender, EventArgs e)
        {
            // Handle button click event
        }
    }
}
