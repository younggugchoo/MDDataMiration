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
               
                DataSet ds = factory.ExecuteDataSet(@"
                                        select 
                                          grp_table_name as TABLE_NAME
                                          , max(table_id) as TABLE_ID
                                          , max(isYearly) as IS_YEARLY
                                          , cast(avg(cnt) as int) as AVG_CNT
                                        from
                                        (
                                          select
                                            table_name
                                            , table_id
                                            , count as cnt
                                            , case when isnumeric(substring(table_name, len(table_name) - 3, len(table_name))) = 1
                                                then  substring(table_name, 1, len(table_name) - 4) 
                                                else table_name
                                              end as grp_table_name
                                            , case when isnumeric(substring(table_name, len(table_name) - 3, len(table_name))) = 1
                                                then  'Y'
                                                else 'N'
                                              end as isYearly
                                          from systable
                                          where count > 0
                                        )a
                                        group by grp_table_name
                                        order by grp_table_name", CommandType.Text);

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
