using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Forms.Util
{
    public class TableList
    {

        public TableList(string dbName, string tableName)
        {
            this.DbName = dbName;
            this.TableName = tableName;
        }
        public string DbName { get; set; }
        public string TableName { get; set; }
    }
}
