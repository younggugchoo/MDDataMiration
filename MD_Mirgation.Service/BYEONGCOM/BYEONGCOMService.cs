using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class BYEONGCOMService
    {
        public void TestConnection()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                factory.DatabaseFactoryAccess("처방자료");
                DbDataReader dr = factory.ExecuteReader("Select top 10 * FROM 가격", CommandType.Text, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["처방코드"].ToString());
                    }
                }


            }
        }
    }
}
