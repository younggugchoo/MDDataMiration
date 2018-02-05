using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.MDPARK
{
    public class MDPARKService
    {
        public void TestConnection()
        {
            using (MD_DataMigration.Data.DatabaseFactory factory = new MD_DataMigration.Data.DatabaseFactory("MariaDb"))
            {
                DbDataReader dr = factory.ExecuteReader("select * from user", CommandType.Text, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["FIRSTNAME"].ToString());
                    }
                }

                Logger.Logger.INFO();
            }
        }
    }
}
