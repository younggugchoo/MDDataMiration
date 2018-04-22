using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MD_DataMigration.Service
{

    public class ReadQuery
    {
        private static ReadQuery _instance = null;

        private static Object _mutex = new Object();
        private string fileName;

        private ReadQuery(string arg1)
        {
            fileName = arg1;
        }

        public static ReadQuery GetInstance(string arg1)
        {
            if (_instance == null)
            {
                lock (_mutex) // now I can claim some form of thread safety...
                {
                    if (_instance == null)
                    {
                        _instance = new ReadQuery(arg1);
                    }
                }
            }

            return _instance;
        }

        public string GetQueryText(string id)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"\sql\" + fileName);

            //doc.Load(Application.StartupPath +  @"\sql\sql-byeongcom.xml");


            var node = xmlDocument.SelectSingleNode(string.Format("//*[@id='{0}']", id));

            //XmlElement el = doc.GetElementById("test.testquery");

            return node.InnerText;
        }
    }

    

}
