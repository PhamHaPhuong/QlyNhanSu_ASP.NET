using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdateKL : System.Web.UI.Page
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDownList();
                LoadGridView();
            }
        }

        protected void LoadDropDownList()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaNhanVien, HoTen FROM [Kỷ Luật]";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DropDownList1.DataSource = reader;
                        DropDownList1.DataTextField = "HoTen";
                        DropDownList1.DataValueField = "MaNhanVien";
                        DropDownList1.DataBind();
                    }
                    conn.Close();
                }
            }
        }

        protected void LoadGridView()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "SELECT MaNhanVien, HoTen, LyDo FROM [Kỷ Luật]";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView_1.DataSource = dt;
                    GridView_1.DataBind();

                    conn.Close();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = "SELECT HoTen FROM [Kỷ Luật] WHERE MaNhanVien = @MaNhanVien";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", DropDownList1.SelectedValue);
                        conn.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                txtHoTen.Text = reader["HoTen"].ToString();
                            }
                        }
                    }
                }
            }
        

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            string maNhanVien = DropDownList1.SelectedValue;
            string hoTen = txtHoTen.Text;
            string lyDo = txtLyDo.Text;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "UPDATE [Kỷ Luật] SET HoTen = @HoTen, LyDo = @LyDo WHERE MaNhanVien = @MaNhanVien";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@LyDo", lyDo);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Cập nhật lý do thành công";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        LoadGridView(); // Reload GridView after successful update
                    }
                    else
                    {
                        lblMessage.Text = "Không có bản ghi nào được cập nhật";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
