using System;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using MD_DataMigration.Service;
using MD_DataMigration.Service.BYEONGCOM;
using MD_DataMigration.Service.NIX;
using MD_DataMigration.Service.UISARANG;

using System.Drawing;
using System.Drawing.Imaging;
using MD_DataMigration.Service.MDPARK;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using static MD_DataMigration.Service.CommonStatic;
using System.Xml;
using System.Reflection;
using MD_DataMigration.Service.MDPARK.model;

namespace MD_DataMigration.Forms.Util
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NIXService nix = new NIXService();
            //nix.TestConnection();
            nix.TestConnectionParam();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UISARANGService uISARANGService = new UISARANGService();
            uISARANGService.TestConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            BYEONGCOMService bYEONGCOMService = new BYEONGCOMService();

            using (DbDataReader dr = bYEONGCOMService.TestConnection())
            {

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {


                        byte[] byteFile = null;
                        byteFile = (byte[])dr["서식"];


                        MemoryStream ms = new MemoryStream();
                        Bitmap bm;
                        ms.Write(byteFile, 78, byteFile.Length - 78);
                        bm = new Bitmap(ms);
                        pictureBox1.Image = bm;
                        String strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.jpg";
                        bm.Save(strPath, ImageFormat.Jpeg);

                        //Console.WriteLine(dr["서식"].ToString());
                        return;

                    }

                }
            }


            //    OleDbConnection oleDbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\MDPark\05. 마음속내과 데이터\기초자료\처방자료.mdb;User Id=admin;");

            //    oleDbConnection.Open();


            //    string sql = "Select * FROM 가격";

            //    OleDbCommand cmd = new OleDbCommand(sql, oleDbConnection);

            //    cmd.CommandText = sql;


            //    OleDbDataReader reader = cmd.ExecuteReader();


            //    while (reader.Read())

            //    {

            //        string item = "";

            //        item += reader["처방코드"].ToString() + " ";

            //        item += reader["청구코드"].ToString() + " ";

            //        item += reader["적용일"].ToString() + " ";

            //        item += reader["재료가"].ToString();

            //        Console.WriteLine(item);

            //    }

            //    reader.Close();

            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MDPARKService service = new MDPARKService("MariaDbMDPark"))
            {
                StringBuilder sb = new StringBuilder();

                DataSet ds = service.SelectColumnList(txtTableName.Text);

                string txt = "public {0} {1} {get; set;}";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.AppendLine("/// <summary>");
                    sb.AppendLine("/// " + dr["column_comment"].ToString());
                    sb.AppendLine("/// </summary>");
                    sb.Append(string.Format("public {0} {1}", ConvertDataType(dr["data_type"].ToString()), ToPascalCase(dr["column_name"].ToString())));
                    sb.AppendLine(" {get; set;}");
                    sb.AppendLine();
                    //Logger.Logger.DEBUG(dr["column_name"].ToString());
                }

                txtResult.Text = sb.ToString();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (MDPARKService service = new MDPARKService("MariaDbMDPark"))
            {


                StringBuilder sb = new StringBuilder();
                DataSet tDs = service.SelectTableList();

                foreach (DataRow tDr in tDs.Tables[0].Rows)
                {
                    string tableName = tDr["TABLE_NAME"].ToString();

                   
                    DirectoryInfo dir = new DirectoryInfo("\\Output");

                    if (!dir.Exists) dir.Create();


                    FileInfo f = new FileInfo(dir.FullName + "/" + ToPascalCase(tableName) + ".cs");

                    if (f.Exists) f.Delete();

                    FileStream fs = f.Create();
                    //fs.Close();


                    TextWriter tw = new StreamWriter(fs);
                    
                    DataSet ds = service.SelectColumnList(tableName);
                    sb.Clear();
                    sb.AppendLine("namespace MD_DataMigration.Service.MDPARK.model");
                    sb.AppendLine("{");
                    sb.AppendLine("\tpublic class " + ToPascalCase(tableName));
                    sb.AppendLine("\t {");

                    string txt = "public {0} {1} {get; set;}";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.AppendLine("\t\t/// <summary>");
                        sb.AppendLine("\t\t/// " + dr["column_comment"].ToString());
                        sb.AppendLine("\t\t/// </summary>");
                        sb.Append(string.Format("\t\tpublic {0} {1}", ConvertDataType(dr["data_type"].ToString()), ToPascalCase(dr["column_name"].ToString())));
                        sb.AppendLine(" {get; set;}");
                        sb.AppendLine();
                        //Logger.Logger.DEBUG(dr["column_name"].ToString());
                    }

                    //txtResult.Text = sb.ToString();
                    sb.AppendLine("\t }");
                    sb.AppendLine("}");
                    tw.Write(sb.ToString());
                    tw.Close();
                    fs.Close();
                }
            }

            MessageBox.Show("생성완료");
        }

        private void btnReadQuery_Click(object sender, EventArgs e)
        {
            //XmlDocument xmlDocument = new XmlDocument();

            //xmlDocument.Load(Application.StartupPath + @"\sql\sql-byeongcom.xml");

            ////doc.Load(Application.StartupPath +  @"\sql\sql-byeongcom.xml");


            //var node = xmlDocument.SelectSingleNode("//*[@id='test.testquery']");

            ////XmlElement el = doc.GetElementById("test.testquery");

            //txtQuery.Text = node.InnerText;
            string fileName = "sql-byeongcom.xml";

            txtQuery.Text = ReadQuery.GetInstance(fileName).GetQueryText("환자정보.환자정보") ;
        }

        private void btnGenConvertCode_Click(object sender, EventArgs e)
        {
            try
            {
                string className = txtTableName.Text;
                StringBuilder sb = new StringBuilder();

                TCmAuth at = new TCmAuth();
                Type t = Type.GetType(string.Format("MD_DataMigration.Service.MDPARK.model.{0}, MD_DataMigration.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", className));

                PropertyInfo[] pi = t.GetProperties();

                foreach (PropertyInfo p in pi)
                {
                    if (p.GetCustomAttribute(typeof(ColunmExceptionAttribute), true) == null)
                    {
                        sb.AppendLine(string.Format("_{0}.{1} = dr[\"\"].ToString();", Char.ToLowerInvariant(className[0]) + className.Substring(1), p.Name));


                    }

                }

                txtResult.Text = sb.ToString();
            }
            catch
            {

            }
        }
    }
}
