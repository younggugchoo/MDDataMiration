using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    public class UISARANGService: IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void TestConnection()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {
                //DbDataReader dr = factory.ExecuteReader("SELECT TOP 10 * FROM SMPSUGA", CommandType.Text, null);

                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        Console.WriteLine(dr["SEP_H"].ToString());
                //    }   
                //}

                DataSet ds = factory.ExecuteDataSet("SELECT TOP 10 * FROM SMPSUGA", CommandType.Text);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["SEP_H"]);
                }

            }
        }

        public DataSet RetrieveTables()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {
               
                DataSet ds = factory.ExecuteDataSet("SELECT top 10 TABLE_NAME, COUNT, TABLE_ID FROM SYSTABLE WHERE COUNT > 0 ORDER BY TABLE_NAME", CommandType.Text);

                return ds;

            }
        }

        public DataSet RetrieveColumns(string tableId)
        {

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {

                DataSet ds = factory.ExecuteDataSet( string.Format("SELECT COLUMN_NAME, '' DESCRIPTION FROM SYSCOLUMN WHERE table_id = {0}", tableId), CommandType.Text);

                return ds;

            }
            
        }
    }
}
