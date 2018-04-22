using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.NIX
{
    public class NIXService
    {
        public void TestConnection()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MSSQL_NIXPEN"))
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

        public void TestConnectionParam()
        {



            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MariaDb_local"))
            {
                MySqlParameter[] parameter = new MySqlParameter[]
                {
                    new MySqlParameter("@PRICE", 100)
                    
                };

                //DbDataReader dr = factory.ExecuteReader("select * from products;", CommandType.Text, null);
                //DbDataReader dr = factory.ExecuteReader("select * from test.users;", CommandType.Text, null);
                DataSet ds = factory.ExecuteDataSet("select * from users", CommandType.Text);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["username"]);
                }

                parameter = new MySqlParameter[]
                {
                    new MySqlParameter("@USERNAME", "asfsafd")
                    , new MySqlParameter("@PASSWORD", "1234")
                    , new MySqlParameter("@ENABLED", 1)
                };

                try
                {
                    factory.ExecuteNonQuery("insert into users (username, password, enabled)values(@USERNAME, @PASSWORD, @ENABLED)", parameter);
                }
                catch
                {
                }

                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {                     
                //        Logger.Logger.INFO(dr["username"].ToString());
                //    }
                //}
            }

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MSSQL_Test"))
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@USE_F", "Y"),
                    new SqlParameter("@BL_CO_CD", 118)
                };

                //DbDataReader dr = factory.ExecuteReader("select top 10 * from T_MEM_M_IDV WHERE USE_F =@USE_F AND BL_CO_CD = @BL_CO_CD", CommandType.Text, parameter);
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        Logger.Logger.INFO(dr["MEM_KO_NM"].ToString());
                //    }
                //}

                DataSet ds = factory.ExecuteDataSet("select top 10 * from T_MEM_M_IDV WHERE USE_F =@USE_F AND BL_CO_CD = @BL_CO_CD", CommandType.Text, parameter);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["MEM_KO_NM"]);
                }

            }




        }
    }
}
