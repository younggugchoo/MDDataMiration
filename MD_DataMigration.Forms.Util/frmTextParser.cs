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

namespace MD_DataMigration.Forms.Util
{
    public partial class frmTextParser : Form
    {
        public delegate void ParsingEvent(string FileName, List<string> parsingData);
        public event ParsingEvent Parsing_Completed;
        public event ParsingEvent Parsing_Error;
        

        Thread th;
        public frmTextParser()
        {
            InitializeComponent();
        }

        private void frmTextParser_Load(object sender, EventArgs e)
        {
            this.Parsing_Completed += FrmTextParser_Parsing_Completed;
            this.Parsing_Error += FrmTextParser_Parsing_Error;
            textBox1.Text = "2012,'2825','026315','doctor',2018-02-05,2,1,2,0,1,'','80748836094','이진호',0,'진료실3','12',10:48:04,2018-02-05,,0,1,0,,0,0,0,0,0,0,0,0,1,0,0,0,0,0,'시력,안압,안저/포도막염 -2일전부터 타병원 진단, \x0d\x0a\x0d\x0aR)Clear\x0d\x0aL)A/C : deep & cell 4+, flare -\x0d\x0aB)Fundus: Fundus : flat retina;OU\x0d\x0aPF q2h -> qid\x0d\x0a수요일 \x0d\x0a',0,0,,,,,'doctor2',0,,10:18:16,10:57:12,1,1,1,,0,,,,0,0,,,1,0,'','00',,,,,,'0',,0,2018-02-05 10:48:04.000000,,0,'$$$$$||||||                |||||||','0000000000000','{\\rtf1\\ansi\\ansicpg949\\deff0\\deflang1033\\deflangfe1042{\\fonttbl{\\f0\\fnil\\fcharset129 \\''b1\\''bc\\''b8\\''b2;}}\x0d\x0a\\viewkind4\\uc1\\pard\\sl-216\\slmult0\\lang1042\\f0\\fs18\\''bd\\''c3\\''b7\\''c2,\\''be\\''c8\\''be\\''d0,\\''be\\''c8\\''c0\\''fa/\\''c6\\''f7\\''b5\\''b5\\''b8\\''b7\\''bf\\''b0 -2\\''c0\\''cf\\''c0\\''fc\\''ba\\''ce\\''c5\\''cd \\''c5\\''b8\\''ba\\''b4\\''bf\\''f8 \\''c1\\''f8\\''b4\\''dc, \x0d\x0a\\par \x0d\x0a\\par R)Clear\x0d\x0a\\par L)A/C : deep & cell 4+, flare -\x0d\x0a\\par B)Fundus: Fundus : flat retina;OU\x0d\x0a\\par PF q2h -> qid\x0d\x0a\\par \\''bc\\''f6\\''bf\\''e4\\''c0\\''cf \x0d\x0a\\par }\x0d\x0a'";
            
        }

        private void FrmTextParser_Parsing_Error(string FileName, List<string> parsingData)
        {

            this.Invoke(new MethodInvoker(
            delegate ()
            {

                try
                {
                    int line = 1;
                    //foreach (string item in parsingData)
                    //{
                    //    textBox2.AppendText(string.Format("{1}----->{0}\r\n", item, line));

                    //    line++;
                    //}

                    textBox3.AppendText(FileName + "\r\n");
                }
                catch
                {

                }
                //label1.Text = string.Format("FileName = {0}\r\nColumn Count:{1}", FileName,  parsingData.Count.ToString());
            }));
        }

        private void FrmTextParser_Parsing_Completed(string FileName, List<string> parsingData)
        {
            this.Invoke(new MethodInvoker(
            delegate ()
            {
                int line = 1;
                //foreach (string item in parsingData)
                //{
                //    textBox2.AppendText(string.Format("{1}----->{0}\r\n", item, line));

                //    line++;
                //}

                textBox2.AppendText(FileName + "\r\n");
                //label1.Text = string.Format("FileName = {0}\r\nColumn Count:{1}", FileName,  parsingData.Count.ToString());
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            th = new Thread(ReadTextData);
            th.IsBackground = true;
            th.Start();
            
        }

        

        private void ReadTextData()
        {
            string sDir = @"d:\MDPark\의사랑\의사랑_텍스트데이터";


            List<string> fileList = DirSearch(sDir);

            foreach(string file in fileList)
            {
                FileInfo f = new FileInfo(file);

                if (f.Length > 0)
                ReadFile(file);
            }

            MessageBox.Show("Parsing Completed...");
        }

        private List<string> DirSearch(string sDir)
        {

            List<string> files = new List<string>();

            try
            {
                //foreach (string d in Directory.GetDirectories(sDir))
                //{
                    foreach (string f in Directory.GetFiles(sDir, "*.CTT"))
                    {
                        files.Add(f);
                    }
                //    DirSearch(d);
                //}
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }

        /// <summary>
        /// 파일을 한줄씩 읽기.
        /// </summary>
        private void ReadFile(string filePath)
        {

            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            try
            {

                // Read the file and display it line by line.  
                
                while ((line = file.ReadLine()) != null)
                {
                    List<string> result = TextParsing(line);


                    counter++;
                }
                Parsing_Completed?.Invoke(Path.GetFileName(filePath), null);
            }
            catch(Exception ex)
            {
                Parsing_Error?.Invoke(Path.GetFileName(filePath), null);
                this.Invoke(new MethodInvoker(
                delegate ()
                {
                    textBox4.AppendText(string.Format("{0}=================================================\r\n", filePath));
                    textBox4.AppendText(string.Format("{0}\r\n", ex.Message.ToString()));
                    textBox4.AppendText(string.Format("{0}\r\n", ex.Source.ToString()));
                    textBox4.AppendText(string.Format("{0}\r\n", ex.StackTrace.ToString()));
                }));

                
               

  

            }

            file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            //System.Console.ReadLine();
        }

        /// <summary>
        /// 구분자 기준으로 column parsing
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private List<string> TextParsing(string source)
        {

            List<string> resultList = new List<string>();

            try
            {
                string[] parse = source.Split(',');

                StringBuilder sbTemp = new StringBuilder();

                for (int i = 0; i < parse.Length; i++)
                {

                    if (parse[i].Length > 0)
                    {
                        if (parse[i].Substring(0, 1).Equals("'") && parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // 'data'
                        {
                            resultList.Add(parse[i]);

                        }
                        else if (parse[i].Substring(0, 1).Equals("'") && !parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // 'data
                        {
                            for (int j = i; i < parse.Length; j++)
                            {

                                if (parse[j].Length > 0)
                                {
                                    if (parse[j].Substring(parse[j].Length - 1, 1).Equals("'"))
                                    {
                                        sbTemp.Append(parse[j]);
                                        i = j;
                                        resultList.Add(sbTemp.ToString());
                                        sbTemp.Clear();
                                        break;
                                    }

                                    sbTemp.Append(parse[j]);
                                    sbTemp.Append(",");
                                }
                                
                            }
                        }

                        else if (!parse[i].Substring(0, 1).Equals("'") && !parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // data (숫자)
                        {
                            resultList.Add(parse[i]);
                        }
                    }
                    else
                    {
                        resultList.Add(parse[i]);
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return resultList;
        }

        private void frmTextParser_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (th != null && th.IsAlive)
            {
                th.Suspend();
                Thread.Sleep(5000);
            }
        }
    }
}
