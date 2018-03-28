using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MD_DataMigration.Service;
using MD_DataMigration.Service.BYEONGCOM;

namespace MD_DataMigration.Forms
{
    public partial class frmConvert : Form
    {
        private int sourceRad;

        public frmConvert()
        {
            InitializeComponent();
           
        }

        private void frmConvert_Load(object sender, EventArgs e)
        {
           // Logger.TextBoxAppender.ConfigureTextBoxAppender(txtLog);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            Thread th = new Thread(new ThreadStart(StartConvert));
            th.Start();

            //StartConvert();
        }

        private void StartConvert()
        {
            MD_DataMigration.Service.IConvert convert = null;

            switch (sourceRad)
            {
                case 1:
                    convert = new BYEONGCOMService();
                    
                    break;
                default:
                    break;
            }

            if (convert != null)
            {
                convert.WorkingInfo += Convert_WorkingInfo;
                BaseInfo baseInfo = new BaseInfo();

                baseInfo.HosCd = txtHosCd.Text;

                convert.StartConvert(baseInfo);
            }
            
        }

        private void Convert_WorkingInfo(string message)
        {

            this.Invoke(new MethodInvoker(
            delegate ()
            {
                lstWorkInfo.Items.Add(message);
            }));

            
        }

        private void radioSourceCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            if (rad.Checked)
            {
                switch (rad.Name)
                {
                    case "rad1":
                        sourceRad = 1;
                        break;
                    default:
                        sourceRad = 0;
                        break;
                }
            }
        }


    }
}
