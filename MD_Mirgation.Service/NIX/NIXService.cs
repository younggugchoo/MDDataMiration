using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.NIX
{
    public class NIXService
    {
        public void TestConnection()
        {
            using (MD_DataMigration.Data.DatabaseFactory factory = new MD_DataMigration.Data.DatabaseFactory("MSSQL_NIXPEN"))
            {
                DbDataReader dr = factory.ExecuteReader("select top 10 * from person", CommandType.Text, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["code"].ToString());
                        Logger.Logger.INFO(dr["code"].ToString());
                    }
                }
            }
        }
    }
}
