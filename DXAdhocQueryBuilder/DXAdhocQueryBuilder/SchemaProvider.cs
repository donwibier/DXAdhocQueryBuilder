using DevExpress.DataAccess.Sql;
using DevExpress.Xpo.DB;
using DevExpress.XtraReports.Web.ReportDesigner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXAdhocQueryBuilder
{
    public class SchemaProvider : IDBSchemaProvider
    {
        public DBSchema GetSchema(SqlDataConnection connection)
        {
            //Load DB Schema without loading columns 
            DBSchema defaultSchema = connection.GetDBSchema(false);
            //Select only required tables/views/procedures 
            DBTable[] tables = defaultSchema.Tables.Where((table) => { return !table.Name.StartsWith("Order"); }).ToArray();
            DBTable[] views = defaultSchema.Views.ToArray();
            DBStoredProcedure[] storedProcedures = defaultSchema.StoredProcedures.ToArray();
            //Create a new schema 
            return new DBSchema(tables, views, storedProcedures);
        }

        public void LoadColumns(SqlDataConnection connection, params DBTable[] tables)
        {
            //Load columns for current tables 
            connection.LoadDBColumns(tables);
        }
    }
    public class MySchemaProviderFactory : IDataSourceWizardDBSchemaProviderFactory
    {
        public IDBSchemaProvider Create()
        {
            return new SchemaProvider();
        }
    }
}
