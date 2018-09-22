using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MD_DataMigration.Service;
using MD_DataMigration.Service.BYEONGCOM;
using System.Runtime.InteropServices;


namespace MD_DataMigration.Forms
{
    public partial class frmConvert : Form
    {
        private int sourceSystem;
        private int curTabPage;

        private string currentWork;
        private decimal targetCount;
        private decimal currentCount;

        Thread th;

        #region FormInit
        public frmConvert()
        {
            InitializeComponent();
           
        }
        private void frmConvert_Load(object sender, EventArgs e)
        {

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            curTabPage = 0;
            btnPrev.Enabled = false;

            SetHeight(lstWorkList, 20);
            SettingLstWorkList();
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
        #endregion


        #region Methods
        private void StartConvert()
        {
            MD_DataMigration.Service.IConvert convert = null;

            switch (sourceSystem)
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
                convert.Convert_Completed += Convert_Completed;
                BaseInfo baseInfo = new BaseInfo();

                baseInfo.HosCd = txtHosCd.Text;

                convert.StartConvert(baseInfo);
            }


            
        }

        /// <summary>
        /// 오류결과 엑셀저장
        /// </summary>
        private void ExportExcelFailResult()
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                    xla.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;


                   
                    //ws.Cells[1,1]

                    int i = 2;
                    foreach(ListViewItem item in lstFailList.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;

                        i++;
                    }

                    wb.SaveAs(sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing);
                    xla.Quit();

                    MessageBox.Show("내보내기 성공", "메시지",  MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }


        private void ExportFileFailResult()
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (string item in lstFailList.Items)
                        {
                            sw.WriteLine("{0}", item);
                        }

                        MessageBox.Show("저장되었습니다.", "메시지", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        #region Event callback
        private void Convert_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            this.Invoke(new MethodInvoker(
            delegate ()
            {
                switch (workResult)
                {
                    case CommonStatic.WORK_RESULT.NONE:
                    case CommonStatic.WORK_RESULT.SUCCESS:
                        lstWorkInfo.Items.Add(message);
                        break;
                    case CommonStatic.WORK_RESULT.FAIL:
                        lstFailList.Items.Add(message);
                        break;

                    case CommonStatic.WORK_RESULT.CURRENT_WORK:
                        currentWork = message;
                        break;
                    case CommonStatic.WORK_RESULT.TARGET_COUNT:
                        targetCount = Convert.ToInt32(message);
                        break;
                    case CommonStatic.WORK_RESULT.CURRENT_COUNT:
                        currentCount = Convert.ToInt32(message);
                        RefreshProgressRatio();


                        break;

                    
                }
                
            }));
        }

        private void RefreshProgressRatio()
        {
            this.Invoke(new MethodInvoker(
           delegate ()
           {
               
               foreach(ListViewItem item in lstWorkList.Items)
               {
                   if (item.Tag.ToString().Equals(currentWork))
                   {
                       
                       item.SubItems[2].Text = string.Format("{0}%",Convert.ToInt32((currentCount / targetCount) * 100));
                       break;
                   }
               }
               
                
           }));
        }

        private void Convert_Completed(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(
            delegate ()
            {
                btnClose.Enabled = true;
                MessageBox.Show("데이터 변환이 완료되었습니다.오류목록을 확인하시기 바랍니다.");
            }));

            
        }

        #endregion


        #region Buttons Event
        private void btnConvert_Click(object sender, EventArgs e)
        {

            btnConvert.Enabled = false;
            btnClose.Enabled = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;


            if (MessageBox.Show("데이터 변환을 시작합니다. 계속 진행하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                th = new Thread(new ThreadStart(StartConvert));
                th.Start();

                //Thread.Sleep(1000);
                //while (!th.IsAlive) ;



                //th.Join();

            }
            else
            {
                btnConvert.Enabled = true;
                btnClose.Enabled = true;
                btnPrev.Enabled = true;
                btnNext.Enabled = false;
            }


            //StartConvert();
        }

        private void radioSourceCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            if (rad.Checked)
            {
                switch (rad.Name)
                {
                    case "rad1":
                        sourceSystem = 1;
                        break;
                    default:
                        sourceSystem = 0;
                        break;
                }
            }
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrev.Enabled = true;

            curTabPage++;
            tabControl1.SelectTab(curTabPage);

            if (curTabPage == 2)
            {
                btnNext.Enabled = false;
                btnConvert.Enabled = true;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            curTabPage--;
            tabControl1.SelectTab(curTabPage);

            btnConvert.Enabled = false;
            if (curTabPage == 0)
            {
                btnPrev.Enabled = false;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
                
        }

        private void btnConvert_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFailSaveExcel_Click(object sender, EventArgs e)
        {
            //ExportExcelFailResult();
            ExportFileFailResult();
        }


        #endregion

        private void SetHeight(ListView LV, int height)
        {
            // listView 높이 지정
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            LV.SmallImageList = imgList;
        }

        private void SettingLstWorkList()
        {
            ListViewItem item = new ListViewItem();

            item.SubItems.Add("환자정보");
            item.SubItems.Add("");
            item.Checked = true;
            item.Tag = "TAcPtnt";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("접수");
            item.SubItems.Add("");
            item.Checked = true;
            item.Tag = "TMnRcv";
            lstWorkList.Items.Add(item);


            item = new ListViewItem();
            item.SubItems.Add("증상");
            item.SubItems.Add("");
            item.Checked = true;
            item.Tag = "TMdSympt";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("진단");
            item.SubItems.Add("");
            item.Checked = true;
            item.Tag = "TMdDx";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("처방");
            item.SubItems.Add("");
            item.Checked = true;
            item.Tag = "TMdPsb";
            lstWorkList.Items.Add(item);

            
        }

        
    }
}
