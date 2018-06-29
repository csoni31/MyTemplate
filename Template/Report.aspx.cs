using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;

namespace Template
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ReportViewer1.Reset();
            DataTable dt = new DataTable();
            string conndat2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(conndat2))
            {

                SqlCommand cmd = new SqlCommand("select top 10 guarantee_date,expiry_date,section_code,guarantee_type from guarantees_data",cnn);
                //cnn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //adp.Fill(dt);
                adp.Fill(dt);
            }
            ReportDataSource rds = new ReportDataSource("DataSet2", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Report2.rdlc";
            reportparameter[] rptparams = new reportparameter[]
            { 
            new reportparameter("fromdate"),
            new reportparameter("todate"),
            new reportparameter("seccode"),
            new reportparameter("type")
            };

            this.reportviewer1.localreport.setparameters(rptparams);
            string currentdate = DateTime.Now.ToString("dd-MM-yyyy");
            ReportViewer1.LocalReport.DisplayName = "BG_Report";
            ReportViewer1.LocalReport.Refresh();
                    
        
        
        
    }

        
           protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}