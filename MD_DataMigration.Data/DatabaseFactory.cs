using System;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Text;

namespace MD_DataMigration.Data
{
    public class DatabaseFactory: IDisposable
    {
        private DbConnection connection = null;

        public DatabaseFactory(string conn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[conn];
            var provider = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(provider); 
            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString;
            connection.Open();
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
                dbCommand.CommandText = commandText;
                dbCommand.CommandType = commandType;

                dbCommand.Prepare();
                if (paramValues != null) {
                    AttachParameters(dbCommand, paramValues);
                }

                Logger.Logger.INFO(dbCommand.CommandText);
                if (paramValues != null)
                {
                    StringBuilder sbParam = new StringBuilder();

                    foreach(IDbDataParameter p in paramValues)
                    {
                        sbParam.AppendFormat("{0}:{1},",  p.ParameterName, p.Value);
                    }
                    Logger.Logger.INFO(sbParam.ToString());
                }
                return dbCommand.ExecuteReader();
            }
        }

        public Object ExecuteScalar(string commandText, DbParameter[] param)
        {
            DbCommand dbCommand = CraeteCommand();
            dbCommand.CommandType = System.Data.CommandType.Text;
            dbCommand.CommandText = commandText;
            

            return dbCommand.ExecuteScalar();
        }

        public int ExecuteNonQuery(string commandText, params string[] param)
        {
            DbCommand dbCommand = CraeteCommand();
            dbCommand.CommandType = System.Data.CommandType.Text;
            dbCommand.CommandText = commandText;
            
            return dbCommand.ExecuteNonQuery();
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
            }
        }
    }
}
