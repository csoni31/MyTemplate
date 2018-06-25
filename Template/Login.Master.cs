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
    
    public partial class Login : System.Web.UI.MasterPage
    {
        static string ConnStr_Test = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        OdbcConnection Conn_Test = new OdbcConnection(ConnStr_Test);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}