using System;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using iAnywhere.Data.SQLAnywhere;
using System.Data.OleDb;

namespace MD_DataMigration.Data
{
    public class DatabaseFactory: IDisposable
    {
        private DbConnection connection = null;
        //private string mConnectionString = "";

        public DatabaseFactory()
        {

        }

        public DatabaseFactory(string conn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[conn];
            var provider = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(provider); 
            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString;
            //mConnectionString = connection.ConnectionString;
            connection.Open();
            Logger.Logger.INFO(string.Format("open database:{0}", connection.Database));
        }

        public void DatabaseFactoryAccess(string databaseFileName)
        {
            

            string rootPath = ConfigurationManager.AppSettings.Get("byengcomRootPath");
            string path = rootPath + "\\" + ConfigurationManager.AppSettings.Get(ConfigurationManager.AppSettings.Get(databaseFileName))+ "\\" + databaseFileName + ".mdb";
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";User Id=admin;";

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStr;
            conn.Open();

            Logger.Logger.INFO(path);

            connection = conn;
        }

      

        public DbCommand CraeteCommand()
        {
            return connection.CreateCommand();
        }
        
        public DbDataReader ExecuteReader(string commandText, System.Data.CommandType commandType, params IDbDataParameter[] paramValues)
        {
            if (connection == null) throw new ArgumentException("connection");
            using (DbCommand dbCommand = CraeteCommand())
            {
                try
                {
                    dbCommand.CommandText = commandText;
                    dbCommand.CommandType = commandType;

                    dbCommand.Prepare();
                    if (paramValues != null) AttachParameters(dbCommand, paramValues);
                    LoggingSqlStatement(dbCommand, paramValues);

                    return dbCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Logger.Logger.DEBUG(ex.Message, ex);
                    throw ex;
                }
                
            }
        }

        public DataSet ExcuteDatSet(string commandText, CommandType commandType, params IDbDataParameter[] paramValues)
        {
            if (connection == null) throw new ArgumentException("connection");
            using (DbCommand dbCommand = CraeteCommand())
            {
                try
                {
                    DataSet retRs = new DataSet();
                    dbCommand.CommandText = commandText;
                    dbCommand.CommandType = commandType;
                    dbCommand.Prepare();

                    if (paramValues != null) AttachParameters(dbCommand, paramValues);

                    DataAdapter da = null;
                    switch (dbCommand.Connection.ToString())
                    {
                        case "MySql.Data.MySqlClient.MySqlConnection":
                            MySqlDataAdapter myda = new MySqlDataAdapter((MySqlCommand)dbCommand);
                            da = (DataAdapter)myda;
                            break;
                        case "System.Data.SqlClient.SqlConnection":
                            SqlDataAdapter sqlDa = new SqlDataAdapter((SqlCommand)dbCommand);
                            da = (DataAdapter)sqlDa;
                            break;
                        case "iAnywhere.Data.SQLAnywhere.SAConnection":
                            SADataAdapter syDa = new SADataAdapter((SACommand)dbCommand);
                            da = (DataAdapter)syDa;
                            break;
                        case "System.Data.OleDb.OleDbConnection":
                            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter((OleDbCommand)dbCommand);
                            da = (DataAdapter)oleDbDataAdapter;
                            break;
                        default:
                            break;
                    }

                    LoggingSqlStatement(dbCommand, paramValues);

                    if (da == null) throw new Exception("no provider");

                    da.Fill(retRs);

                    Logger.Logger.INFO(string.Format("select counts:{0}", retRs.Tables[0].Rows.Count));
                    return retRs;
                }
                catch (Exception ex)
                {
                    Logger.Logger.DEBUG(ex.Message, ex);
                    throw ex;
                }
            }
            
        }
        
        public int ExecuteNonQuery(string commandText, params IDbDataParameter[] paramValues)
        {
            if (connection == null) throw new ArgumentException("connection");
            using (DbCommand dbCommand = CraeteCommand())
            {
                try
                {
                    dbCommand.CommandType = System.Data.CommandType.Text;
                    dbCommand.CommandText = commandText;

                    dbCommand.Prepare();
                    if (paramValues != null) AttachParameters(dbCommand, paramValues);
                    LoggingSqlStatement(dbCommand, paramValues);

                    return dbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.Logger.DEBUG(ex.Message, ex);
                    throw ex;
                }
            }

        }

        private void LoggingSqlStatement(DbCommand dbCommand, params IDbDataParameter[] paramValues)
        {
            Logger.Logger.DEBUG(dbCommand.CommandText);
            if (paramValues != null)
            {
                StringBuilder sbParam = new StringBuilder();
                sbParam.AppendFormat("parameters:");
                foreach (IDbDataParameter p in paramValues)
                {
                    sbParam.AppendFormat("{0}->{1},", p.ParameterName, p.Value);
                }
                Logger.Logger.DEBUG(sbParam.ToString());
            }
        }

        private static void AttachParameters(DbCommand command, IDbDataParameter[] commandParameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (commandParameters != null)
            {
                foreach (IDbDataParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }

                        command.Parameters.Add(p);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                Logger.Logger.INFO(string.Format("close database:{0}", connection.Database));
            }
        }
    }
}
