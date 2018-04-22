using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service
{
    public class ColunmExceptionAttribute : System.Attribute
    {
        public ColunmExceptionAttribute( bool isExcetpion)
        {
            this.ColumnException = isExcetpion;
        }
        public bool ColumnException { get; set; }
    }
}
