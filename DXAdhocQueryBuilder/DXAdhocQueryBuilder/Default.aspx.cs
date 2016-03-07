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
    public partial class Default : System.Web.UI.Page
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
            Response.Redirect("~/Query.aspx");
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            AddColumns(sender as ASPxGridView);
        }

        #region Column creation

        private void AddColumns(ASPxGridView grid)
        {
            if (grid == null)
                return;
                        
            grid.Columns.Clear();
            DataView dw = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataColumn c in dw.Table.Columns)
            {
                AddColumn(grid, c.ColumnName, c.DataType);
            }
            grid.KeyFieldName = dw.Table.Columns[0].ColumnName;
            //cardView.Columns[0].Visible = false;
        }

        static readonly Dictionary<Type, Type> columnMap = new Dictionary<Type, Type>()
        {
            { typeof(int), typeof(GridViewDataSpinEditColumn) },
            { typeof(DateTime), typeof(GridViewDataDateColumn) },
            { typeof(byte[]), typeof(GridViewDataBinaryImageColumn) }
            // more datatype/columntype mappings here...
        };
        private static void AddColumn(ASPxGridView grid, string fieldName, Type fieldType)
        {
            Type colType = columnMap.ContainsKey(fieldType) ? columnMap[fieldType] : typeof(GridViewDataTextColumn);
            GridViewDataColumn c = Activator.CreateInstance(colType) as GridViewDataColumn;
            c.FieldName = fieldName;
            grid.Columns.Add(c);
        }

        #endregion
    }
}