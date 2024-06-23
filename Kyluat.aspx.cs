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
    public partial class WebForm7 : System.Web.UI.Page
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
                    string SQL = @"SELECT MaNhanVien, HoTen, LyDo FROM [Kỷ Luật]";
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

        }

        protected void them_Click1(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int MaNhanVien = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(MaNhanVien);
                LoadData();
            }
        }

        private void DeleteRecord(int MaNhanVien)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            string query = "DELETE FROM Kỷ Luật WHERE MaNhanVien = @MaNhanVien";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}