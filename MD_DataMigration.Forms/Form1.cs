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

namespace MD_DataMigration.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            using(MDPARKService service = new MDPARKService("MariaDbMDPark"))
            {
                StringBuilder sb = new StringBuilder();

                DataSet ds = service.CreateModelClass(txtTableName.Text);

                string txt = "public {0} {1} {get; set;}";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.AppendLine("//" + dr["column_comment"].ToString());
                    sb.Append(string.Format("public {0} {1}",   convertDataType(dr["data_type"].ToString()), ToPascalCase(dr["column_name"].ToString())));
                    sb.AppendLine(" {get; set;}");
                    sb.AppendLine();
                    //Logger.Logger.DEBUG(dr["column_name"].ToString());
                }

                txtResult.Text = sb.ToString();

            }
        }

        private string convertDataType(string type)
        {
            switch (type)
            {
                case "varchar":
                case "char":
                case "datetime":
                    return "string";
                    
                case "decimal":
                case "int":
                    return "int";
                default:
                    return "";
            }
        }

        private string ToPascalCase(string value)
        {
            string ret = "";

            const string pattern = @"(-|_)\w{1}|^\w";
            return Regex.Replace(value, pattern, match => match.Value.Replace("-", string.Empty).Replace("_", string.Empty).ToUpper());
        }
    }
}
