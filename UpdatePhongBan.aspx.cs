using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdatePhongBan : System.Web.UI.Page
    {
       
        String sql;
        OleDbConnection conn = new OleDbConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            conn.Open();
            if (!Page.IsPostBack)
            {
                String SQL = "SELECT * FROM [Phòng Ban]";
                OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "TenPhongBan";
                DropDownList1.DataValueField = "MaPhongBan";
                DropDownList1.DataBind();

                GridView_2.DataSource = dt;
                GridView_2.DataBind();
            }
        }

        
        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ""; // Clear previous messages
            try
            {
                if (txtTen.Text.Length > 0)
                {
                    sql = "UPDATE [Phòng Ban] SET TenPhongBan = @TenPhongBan WHERE MaPhongBan = @MaPhongBan";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenPhongBan", txtTen.Text);
                        cmd.Parameters.AddWithValue("@MaPhongBan", DropDownList1.SelectedValue);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            string SQL = "SELECT * FROM [Phòng Ban]";
                            OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            GridView_2.DataSource = dt;
                            GridView_2.DataBind();

                            lblMessage.Text = "Cập nhật thành công";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "Cập nhật thất bại";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Tên phòng ban không được để trống";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                conn.Close();
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
                string sql1 = string.Format(@"select * from [Phòng Ban] where MaPhongBan = '{0}'", DropDownList1.SelectedValue);
                OleDbDataAdapter ad = new OleDbDataAdapter(sql1, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtTen.Text = dt.Rows[0]["TenPhongBan"].ToString();
                }
            
        }
    }
}
