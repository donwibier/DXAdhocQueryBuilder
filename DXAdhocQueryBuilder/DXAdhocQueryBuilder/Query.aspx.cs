using DevExpress.DataAccess.Sql;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXAdhocQueryBuilder
{
    public partial class Query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["T"] != null)
            {
                ASPxQueryBuilder1.OpenConnection("ApplicationServices", (TableQuery)Session["T"]);
            }
            else
            {
                ASPxQueryBuilder1.OpenConnection("ApplicationServices");
            }
        }

        protected void ASPxQueryBuilder1_SaveQuery(object sender, DevExpress.XtraReports.Web.SaveQueryEventArgs e)
        {
            Session["SQL"] = e.SelectStatement;
            Session["T"] = e.ResultQuery;
            ASPxEdit.RedirectOnCallback(Request.QueryString["S"] != "Card" ? "~/Default.aspx" : "~/Cards.aspx");
        }
    }
}