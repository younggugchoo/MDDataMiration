using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MD_DataMigration.Data
{
    public class MariaDBDAL
    {
        public MariaDBDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MariaDB"];
            var provider = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(provider);
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ConnectionString;
            connection.Open();
        }
        
    }
}
