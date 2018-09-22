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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Collections;

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
                        sb.AppendLine("\t\t/// " + dr["column_comment"].ToString().Replace("\n", "").Replace("\r",""));
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

                //TCmAuth at = new TCmAuth();
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


        object missing = Type.Missing;

        /// <summary>
        /// 의사랑 테이블 정의서 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {


            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook= null;
            Excel._Worksheet ExcelWorkSheet = null;

            string tempStr="";


            try
            {

                UISARANGService uISARANGService = new UISARANGService();
                DataSet dsTable = uISARANGService.RetrieveTables();



                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }



                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;


                xlWorkBook = xlApp.Workbooks.Add(misValue);


                xlWorkBook.Worksheets.Add();

                ExcelWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets[1];
                ExcelWorkSheet.Name = "테이블 목록";


                ExcelWorkSheet.Cells[1, 1] = "테이블명";
                ExcelWorkSheet.Cells[1, 2] = "년단위생성";
                ExcelWorkSheet.Cells[1, 3] = "레코드 수(평균)";
                ExcelWorkSheet.Cells[1, 4] = "설명";


                for (int i = 0; i < dsTable.Tables[0].Rows.Count; i++)
                {
                    

                    ExcelWorkSheet.Cells[i + 2, 1] = dsTable.Tables[0].Rows[i]["TABLE_NAME"].ToString();
                    ExcelWorkSheet.Cells[i + 2, 2] = dsTable.Tables[0].Rows[i]["IS_YEARLY"].ToString();
                    ExcelWorkSheet.Cells[i + 2, 3] = dsTable.Tables[0].Rows[i]["AVG_CNT"].ToString();
                    

                }


                for (int i = 1; i < dsTable.Tables[0].Rows.Count; i++)
                {
                    xlWorkBook.Worksheets.Add(); //Adding New sheet in Excel Workbook
                }
                

                for (int i = 0; i < dsTable.Tables[0].Rows.Count; i++)
                {
                    int r = 1; // Initialize Excel Row Start Position  = 1
                    

                    ExcelWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets[i + 2];

                    tempStr = dsTable.Tables[0].Rows[i]["TABLE_NAME"].ToString();

                    ExcelWorkSheet.Name = dsTable.Tables[0].Rows[i]["TABLE_NAME"].ToString();

                    DataSet dsCol = uISARANGService.RetrieveColumns(dsTable.Tables[0].Rows[i]["TABLE_ID"].ToString());


                    ExcelWorkSheet.Cells[1, 1] = "컬럼명";
                    ExcelWorkSheet.Cells[1, 2] = "설명";

                    for (int j = 0; j < dsCol.Tables[0].Rows.Count; j++)
                    {

                        

                        ExcelWorkSheet.Cells[j + 2, 1] = dsCol.Tables[0].Rows[j]["COLUMN_NAME"].ToString();
                        ExcelWorkSheet.Cells[j + 2, 2] = dsCol.Tables[0].Rows[j]["DESCRIPTION"].ToString();
                    }

                }


                xlWorkBook.SaveAs("d:\\csharp-Excel.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");

                xlApp.Visible=true;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace.ToString());
                MessageBox.Show(ExcelWorkSheet.Name);
                MessageBox.Show(tempStr);
            }
            finally
            {
                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

            }

            
        }

        /// <summary>
        /// 병컴 테이블 정의서 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = null;
            Excel._Worksheet ExcelWorkSheet = null;

            string tempStr = "";


            try
            {

                BYEONGCOMService bYEONGCOMService = new BYEONGCOMService();

                List<TableList> tables = ByengcomTables();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }



                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;


                xlWorkBook = xlApp.Workbooks.Add(misValue);


                xlWorkBook.Worksheets.Add();

                ExcelWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets[1];
                ExcelWorkSheet.Name = "테이블 목록";


                ExcelWorkSheet.Cells[1, 1] = "DB 파일명";
                ExcelWorkSheet.Cells[1, 2] = "테이블명";
                ExcelWorkSheet.Cells[1, 3] = "설명";
               


                for (int i = 0; i < tables.Count; i++)
                {


                    ExcelWorkSheet.Cells[i + 2, 1] = tables[i].DbName;
                    ExcelWorkSheet.Cells[i + 2, 2] = tables[i].TableName;

                }


                for (int i = 1; i < tables.Count; i++)
                {
                    xlWorkBook.Worksheets.Add(); //Adding New sheet in Excel Workbook
                }


                for (int i = 0; i < tables.Count; i++)
                {
                    int r = 1; // Initialize Excel Row Start Position  = 1


                    ExcelWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets[i + 2];

                    tempStr = tables[i].DbName + "_" + tables[i].TableName;

                    ExcelWorkSheet.Name = tempStr;

                    ArrayList cols = bYEONGCOMService.RetrieveTableColumnList(tables[i].DbName, tables[i].TableName);


                    ExcelWorkSheet.Cells[1, 1] = "컬럼명";
                    ExcelWorkSheet.Cells[1, 2] = "설명";

                    for (int j = 0; j < cols.Count; j++)
                    {



                        ExcelWorkSheet.Cells[j + 2, 1] = cols[j];
                        ExcelWorkSheet.Cells[j + 2, 2] = "";
                    }

                }


                xlWorkBook.SaveAs("d:\\csharp-Excel_병컴.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel_병컴.xls");

                xlApp.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace.ToString());
                MessageBox.Show(ExcelWorkSheet.Name);
                MessageBox.Show(tempStr);
            }
            finally
            {
                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

            }
        }

        private List<TableList> ByengcomTables()
        {
            List<TableList> tables = new List<TableList>();

            tables.Add(new TableList("약제정보", "약제정보"));

            tables.Add(new TableList("참고자료", "과거력"));
            tables.Add(new TableList("참고자료", "묶음처방"));
            tables.Add(new TableList("참고자료", "묶음처방내용"));
            tables.Add(new TableList("참고자료", "용법"));
            tables.Add(new TableList("참고자료", "증상"));
            tables.Add(new TableList("참고자료", "진단명"));
            tables.Add(new TableList("참고자료", "처방"));

            tables.Add(new TableList("처방자료", "가격"));
            tables.Add(new TableList("처방자료", "처방자료"));

            tables.Add(new TableList("과거력", "과거력"));

            tables.Add(new TableList("백신접종", "백신목록"));
            tables.Add(new TableList("백신접종", "백신접종"));
            tables.Add(new TableList("백신접종", "백신접종표"));

            tables.Add(new TableList("심전도검사", "심전도"));

            tables.Add(new TableList("일반검사", "접수검사"));
            tables.Add(new TableList("일반검사", "진료검사"));
            tables.Add(new TableList("일반검사", "체크검사"));

            tables.Add(new TableList("입원정보", "입원정보"));

            tables.Add(new TableList("진단서", "건강진단서"));
            tables.Add(new TableList("진단서", "방사선판독서"));
            tables.Add(new TableList("진단서", "범용진단서"));
            tables.Add(new TableList("진단서", "사망진단서"));
            tables.Add(new TableList("진단서", "사산증명서"));
            tables.Add(new TableList("진단서", "상해진단서"));
            tables.Add(new TableList("진단서", "일반진단서"));
            tables.Add(new TableList("진단서", "직장진단서"));
            tables.Add(new TableList("진단서", "진단서환경"));
            tables.Add(new TableList("진단서", "진료의뢰서"));
            tables.Add(new TableList("진단서", "진료확인서"));
            tables.Add(new TableList("진단서", "출생증명서"));

            tables.Add(new TableList("진료색인", "진료색인"));

            tables.Add(new TableList("진료요약", "진료소견"));

            tables.Add(new TableList("환자정보", "보험정보"));
            tables.Add(new TableList("환자정보", "산재정보"));
            tables.Add(new TableList("환자정보", "자보정보"));
            tables.Add(new TableList("환자정보", "환자정보"));

            tables.Add(new TableList("챠트1612", "진단명"));
            tables.Add(new TableList("챠트1612", "처방"));
            tables.Add(new TableList("챠트1612", "처방메모"));
            tables.Add(new TableList("챠트1612", "특정내역"));

            tables.Add(new TableList("처방전1612", "원내주사"));
            tables.Add(new TableList("처방전1612", "처방"));
            tables.Add(new TableList("처방전1612", "특정내역"));

            return tables;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmTextParser f = new frmTextParser();
            f.Show();

        }
    }
}
