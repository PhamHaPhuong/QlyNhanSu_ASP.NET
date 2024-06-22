﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLon_QlyNhanSu
{
    public partial class UpdateChucVu : System.Web.UI.Page
    {
        String sql;
        OleDbConnection conn = new OleDbConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\BaiTapLon_QlyNhanSu\QUANLYNHANSU.accdb";
            conn.Open();
            if (!Page.IsPostBack)
            {


                String SQL = string.Format("SELECT * from [Chức Vụ]");
                OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "TenChucVu";
                DropDownList1.DataValueField = "IDChucVu";
                DropDownList1.DataBind();

                GridView_1.DataSource = dt;
                GridView_1.DataBind();
            }
        }



        protected void btn_Them_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtTen.Text.Length > 0)
                {
                    sql = "UPDATE [Chức Vụ] SET TenChucVu = @TenChucVu WHERE IDChucVu = @IDChucVu";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenChucVu", txtTen.Text);
                        cmd.Parameters.AddWithValue("@IDChucVu", DropDownList1.SelectedValue);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            string SQL = "SELECT * FROM [Chức Vụ]";
                            OleDbDataAdapter ad = new OleDbDataAdapter(SQL, conn);
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            GridView_1.DataSource = dt;
                            GridView_1.DataBind();

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
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                        "alert('Tên chức vụ không được để trống');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                    "alert('Lỗi: " + ex.Message + "');", true);
            }
            finally
            {
                conn.Close();
            }
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = string.Format(@"select * from [Chức Vụ] where IDChucVu = '{0}'", DropDownList1.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql1, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtTen.Text = dt.Rows[0]["TenChucVu"].ToString();

            }

        }

    }
}




