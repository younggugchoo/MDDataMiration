using MD_DataMigration.Service;
using MD_DataMigration.Service.BYEONGCOM;
using MD_DataMigration.Service.NIX;
using MD_DataMigration.Service.UISARANG;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MD_DataMigration.Forms
{
    public partial class frmConvert : Form
    {
        private int sourceSystem;
        private int curTabPage;

        private string currentWork;
        private decimal targetCount;
        private decimal currentCount;

        private int startYear;
        private int endYear;


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

            tabConfig.Appearance = TabAppearance.FlatButtons;
            tabConfig.ItemSize = new Size(0, 1);
            tabConfig.SizeMode = TabSizeMode.Fixed;

            tabConfig.Visible = false;

            curTabPage = 0;
            btnPrev.Enabled = false;

            SetHeight(lstWorkList, 20);
            SettingLstWorkListInit();

            NixConfigInit();

            UisaranConfigInit();


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
            BaseInfo baseInfo = new BaseInfo();

            baseInfo.StartYear = startYear;
            baseInfo.EndYear = endYear;

            switch (sourceSystem)
            {
                case 1: //병컴
                    convert = new BYEONGCOMService();
                    
                    break;
                case 2: //NIX
                    convert = new NIXService();                    
                    break;

                case 3:
                    convert = new UISARANGService();                   
                    break;

                default:
                    break;
            }

            if (convert != null)
            {
                convert.WorkingInfo += Convert_WorkingInfo;
                convert.Convert_Completed += Convert_Completed;


                baseInfo.HosCd = txtHosCd.Text;

                if (baseInfo.ConvertItems == null) baseInfo.ConvertItems = new System.Collections.Generic.List<string>();

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (ListViewItem item in lstWorkList.Items)
                        {
                            if (item.Checked)
                            {
                                
                                baseInfo.ConvertItems.Add(item.Tag.ToString());
                            }
                        }
                    }));
                }
                
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
                tabConfig.Visible = true;
                switch (rad.Name)
                {
                    case "rad1":
                        sourceSystem = 1;
                        tabConfig.SelectTab(0);
                        break;
                    case "rad2":
                        sourceSystem = 2;
                        tabConfig.SelectTab(1);
                        break;
                    case "rad3":
                        sourceSystem = 3;
                        tabConfig.SelectTab(2);
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

            if (curTabPage == 0 && sourceSystem == 2) //NIX
            {
                if (!NixConfigValidate()) return;
            }

            if (curTabPage == 0 && sourceSystem == 3) //의사랑
            {
                if (!UiSarangConfigValidate()) return;
            }

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


        #region 콘트롤 기본 초기설정
        private void SetHeight(ListView LV, int height)
        {
            // listView 높이 지정
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            LV.SmallImageList = imgList;
        }

        private void SettingLstWorkListInit()
        {
            ListViewItem item = new ListViewItem();

            item.SubItems.Add("환자정보");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TAcPtnt";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("접수");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TMnRcv";
            lstWorkList.Items.Add(item);


            item = new ListViewItem();
            item.SubItems.Add("증상");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TMdSympt";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("진단");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TMdDx";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("처방");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TMdPsb";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("수가");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TCmBsHosSet";
            lstWorkList.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("과거력");
            item.SubItems.Add("");
            item.Checked = false;
            item.Tag = "TAcMemo";
            lstWorkList.Items.Add(item);





        }

        private void NixConfigInit()
        {
            for (int i = 2000; i < DateTime.Now.Year + 1; i++)
            {
                cboNixStartYear.Items.Add(i.ToString());
                cboNixEndYear.Items.Add(i.ToString());
            }

            cboNixStartYear.SelectedIndex = 0;
            cboNixEndYear.SelectedIndex = cboNixEndYear.Items.Count-1;
        }

        private void UisaranConfigInit()
        {
            for (int i = 1995; i < DateTime.Now.Year + 1; i++)
            {
                cboUisarangStartYear.Items.Add(i.ToString());
                cboUisarangEndYear.Items.Add(i.ToString());
            }

            cboUisarangStartYear.SelectedIndex = 0;
            cboUisarangEndYear.SelectedIndex = cboUisarangEndYear.Items.Count-1;
        }
        #endregion

        #region 유효성 체크

        private bool NixConfigValidate()
        {
            bool ret = true;


            if (Convert.ToInt32(cboNixStartYear.SelectedItem) > Convert.ToInt32(cboNixEndYear.SelectedItem))
            {
                MessageBox.Show("끝년도가 시작년도보다 이전입니다.");
                return false;
            }

            return ret;
        }


        private bool UiSarangConfigValidate()
        {
            bool ret = true;


            if (Convert.ToInt32(cboUisarangStartYear.SelectedItem) > Convert.ToInt32(cboUisarangEndYear.SelectedItem))
            {
                MessageBox.Show("끝년도가 시작년도보다 이전입니다.");
                return false;
            }

            return ret;
        }



        #endregion

        private void cboNixStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            startYear = Convert.ToInt32(cboNixStartYear.SelectedItem);
        }

        private void cboNixEndYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            endYear = Convert.ToInt32(cboNixEndYear.SelectedItem);
        }

        private void cboUisarangStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            startYear = Convert.ToInt32(cboUisarangStartYear.SelectedItem);
        }

        private void cboUisarangEndYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            endYear = Convert.ToInt32(cboUisarangEndYear.SelectedItem);
        }
    }
}
