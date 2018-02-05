using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.Common;


namespace MD_DataMigration.Data
{
    public class DatabaseFactory
    {
        private DbConnection connection = null;

        public DatabaseFactory(string conn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MariaDB"];
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

        public DbDataReader ExecuteReader(string commandText, System.Data.CommandType commandType, params string [] param)
        {
            DbCommand dbCommand = CraeteCommand();
            dbCommand.CommandText = commandText;
            dbCommand.CommandType = commandType;

            return dbCommand.ExecuteReader();
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
    }
}
