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
    public partial class WebForm2 : System.Web.UI.Page
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
                    string SQL = @"
                        SELECT NV.MaNhanVien, NV.HoTen, NV.NgaySinh, NV.GioiTinh, NV.CCCD, NV.DiaChi, NV.SDT,
                               CV.TenChucVu, HV.TrinhDo, DT.TenDanToc, TG.TenTonGiao, PB.TenPhongBan
                        FROM (((([Nhân Viên] AS NV
                        LEFT JOIN [Chức Vụ] AS CV ON NV.IDChucVu = CV.IDChucVu)
                        LEFT JOIN [Học Vấn] AS HV ON NV.IDTrinhDo = HV.IDTrinhDo)
                        LEFT JOIN [Dân Tộc] AS DT ON NV.IDDanToc = DT.IDDanToc)
                        LEFT JOIN [Tôn Giáo] AS TG ON NV.IDTonGiao = TG.IDTonGiao)
                        LEFT JOIN [Phòng Ban] AS PB ON NV.MaPhongBan = PB.MaPhongBan";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string maNhanVien = e.CommandArgument.ToString();
                DeleteEmployee(maNhanVien);
                LoadData();
            }
        }

        private void DeleteEmployee(string maNhanVien)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string SQL = "DELETE FROM [Nhân Viên] WHERE MaNhanVien = @MaNhanVien";
                    using (OleDbCommand cmd = new OleDbCommand(SQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.ExecuteNonQuery();
                    }
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
            // Code để thêm nhân viên mới
        }
    }
}
