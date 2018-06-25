using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Configuration;

namespace Template
{
    public partial class Data_Entry : System.Web.UI.Page
    {
        static string ConnStr_Test = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        OdbcConnection Conn_Test = new OdbcConnection(ConnStr_Test);
        protected void Page_Load(object sender, EventArgs e)
        {
                        
        }

        protected void txt_uid_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();            
            txt_name.Text = "";
            OdbcCommand cmd_Test = Conn_Test.CreateCommand();
            cmd_Test.CommandText = "select * from test_emp_mst where pers_no='"+txt_uid.Text+"'";
            Conn_Test.Open();
            OdbcDataReader dr = cmd_Test.ExecuteReader();
            
            while(dr.Read())
            {
                txt_name.ForeColor = System.Drawing.Color.Black;
                txt_name.Text = dr["name"].ToString();                
            }
            if(!dr.HasRows)
            {
                txt_name.ForeColor = System.Drawing.Color.Red;
                txt_name.Text = "*Invalid Personal No.";
            }
            else
            {
                OdbcCommand cmd1_Test = Conn_Test.CreateCommand();
                //cmd1_Test.CommandText = "select test_dept.dept_name from test_dept inner join test_emp_mst on test_dept.dept_cd=test_emp_mst.dept_cd where test_emp_mst.pers_no='"+txt_uid.Text+"'";
                cmd1_Test.CommandText = "select distinct dept_name from test_dept";
                OdbcDataAdapter da = new OdbcDataAdapter(cmd1_Test);                
                da.SelectCommand = cmd1_Test;
                dt.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {                    
                    drp_dept.DataSource = dt;
                    drp_dept.DataTextField = "dept_name";
                    drp_dept.DataValueField = "dept_name";                    
                    drp_dept.DataBind();                    
                }
            }
            Conn_Test.Close();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {

        }

        protected void drp_dept_DataBound(object sender, EventArgs e)
        {
            string dept = null;
            OdbcCommand cmd2_test = Conn_Test.CreateCommand();
            cmd2_test.CommandText = "select test_dept.dept_name from test_dept inner join test_emp_mst on test_dept.dept_cd=test_emp_mst.dept_cd where test_emp_mst.pers_no='" + txt_uid.Text + "'";
            OdbcDataReader dr1 = cmd2_test.ExecuteReader();
            while (dr1.Read())
            {
                dept = dr1["dept_name"].ToString();
            }
            drp_dept.SelectedValue = dept;
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {

        }
    }
}