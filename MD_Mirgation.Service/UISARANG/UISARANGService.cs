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

                DataSet ds = factory.ExcuteDatSet("SELECT TOP 10 * FROM SMPSUGA", CommandType.Text);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["SEP_H"]);
                }

            }
        }
    }
}
