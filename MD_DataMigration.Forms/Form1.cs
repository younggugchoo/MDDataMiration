using System;
using System.Windows.Forms;
using MD_DataMigration.Service;
using MD_DataMigration.Service.NIX;

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
            nix.TestConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
