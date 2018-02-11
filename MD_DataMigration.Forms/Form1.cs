using System;
using System.Data.OleDb;
using System.Windows.Forms;
using MD_DataMigration.Service;
using MD_DataMigration.Service.BYEONGCOM;
using MD_DataMigration.Service.NIX;
using MD_DataMigration.Service.UISARANG;

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
            bYEONGCOMService.TestConnection();


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
    }
}
