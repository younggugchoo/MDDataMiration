using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;

namespace MD_DataMigration.Data
{
    public class MSAccessDAL
    {
        public MSAccessDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MariaDB"];
            var provider = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(provider);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString;
            connection.Open();

            DbCommand cmd = connection.CreateCommand();
            cmd.
        }
    }
}
