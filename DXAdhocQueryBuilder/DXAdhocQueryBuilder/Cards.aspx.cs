using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXAdhocQueryBuilder
{
    public partial class Cards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SQL"] != null)
            {
                SqlDataSource1.SelectCommand = (string)Session["SQL"];
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Query.aspx?S=Card");
        }

        protected void ASPxCardView1_DataBinding(object sender, EventArgs e)
        {
            AddColumns(sender as ASPxCardView);
        }

        #region Column Creation

        private void AddColumns(ASPxCardView cardView)
        {
            if (cardView == null)
                return;

            cardView.Columns.Clear();
            DataView dw = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataColumn c in dw.Table.Columns)
            {
                AddColumn(cardView, c.ColumnName, c.DataType);
            }
            cardView.KeyFieldName = dw.Table.Columns[0].ColumnName;
            //cardView.Columns[0].Visible = false;
        }

        static readonly Dictionary<Type, Type> columnMap = new Dictionary<Type, Type>()
        {
            { typeof(int), typeof(CardViewSpinEditColumn) },
            { typeof(DateTime), typeof(CardViewDateColumn) },
            { typeof(byte[]), typeof(CardViewBinaryImageColumn) }
            // more datatype/columntype mappings here...
        };

        private static void AddColumn(ASPxCardView cardView, string fieldName, Type fieldType)
        {
            Type colType = columnMap.ContainsKey(fieldType) ? columnMap[fieldType] : typeof(CardViewTextColumn);
            CardViewColumn c = Activator.CreateInstance(colType) as CardViewColumn;
            c.FieldName = fieldName;
            cardView.Columns.Add(c);
        }

        #endregion
    }
}