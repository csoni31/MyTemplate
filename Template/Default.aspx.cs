using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Web.Security;

namespace Template
{
    public partial class Default : System.Web.UI.Page
    {
        static string ConnStr_Test = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        OdbcConnection Conn_Test = new OdbcConnection(ConnStr_Test);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            HttpCookie id = new HttpCookie("id");
            id.Value = txt_uid.Text.Trim();
            id.Expires = DateTime.Now.AddHours(1);
            OdbcCommand Cmd_Test = Conn_Test.CreateCommand();
            Cmd_Test.CommandText = "select password from app_common_login where pers_no='" + txt_uid.Text.Trim() + "'and password='" + txt_pass.Text.Trim() + "'and app='temp' and access='su'";
            Conn_Test.Open();
            OdbcDataReader dr = Cmd_Test.ExecuteReader();
            if(dr.Read())
            {
                Conn_Test.Close();
                string captchaText;
                captchaText = Application["CaptchaVerify"].ToString();
                if (txt_Captcha.Text.ToLower() == Application["CaptchaVerify"].ToString())
                {
                    Response.Cookies.Add(id);
                    Session["user"] = txt_uid.Text.Trim();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblCaptchaMessage.Text = "Please enter correct captcha !";
                    lblCaptchaMessage.ForeColor = System.Drawing.Color.Red;
                }  
                
                

                }
                
            
            else 
            {
                lbl_error.Visible = true;
            }
            
        }
    }
}