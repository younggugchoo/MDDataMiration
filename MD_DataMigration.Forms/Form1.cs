using System;
using System.Windows.Forms;
using MD_DataMigration.Service;
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
    }
}
