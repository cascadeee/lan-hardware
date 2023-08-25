using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
            textBox2.Enabled = checkBox2.Checked;
            textBox3.Enabled = checkBox3.Checked;
            textBox4.Enabled = checkBox4.Checked;
            thrad = new Thread(delegate () {
                doSmth();
            });
        }

        private void check(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked) textBox1.Text = "";
            textBox2.Enabled = checkBox2.Checked;
            if (!checkBox2.Checked) textBox2.Text = "";
            textBox3.Enabled = checkBox3.Checked;
            if (!checkBox3.Checked) textBox3.Text = "";
            textBox4.Enabled = checkBox4.Checked;
            if (!checkBox4.Checked) textBox4.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, System.Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                //throw ae.InnerExceptions[0];
                return false;
            }
        }
        private string RemoveFirstWord(string line)
        {
            string[] t = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string res = "";
            for (int i = 1; i < t.Length; i++)
                res += t[i] + " ";
            return res;
        }
        private void doSmth()
        {

            int flag;
            if (!int.TryParse(textBox1.Text, out flag) && checkBox1.Checked) return;
            if (!int.TryParse(textBox2.Text, out flag) && checkBox2.Checked) return;
            if (!int.TryParse(textBox3.Text, out flag) && checkBox3.Checked) return;
            if (!int.TryParse(textBox4.Text, out flag) && checkBox4.Checked) return;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string[] res = new string[7];
            string[] argus = { "", "/NODE:%s computersystem get username","/NODE:%s computersystem get name", "/NODE:%s baseboard get product" , "/NODE:%s cpu get name",
                "/NODE:%s path win32_videocontroller get Caption", "/NODE:%s MEMORYCHIP get partnumber" };
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic.exe",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                }
            };
            for (int i1 = 0; i1 < 255; i1++)
            {
                if (checkBox1.Checked) i1 = int.Parse(textBox1.Text);
                for (int i2 = 0; i2 < 255; i2++)
                {
                    if (checkBox2.Checked) i2 = int.Parse(textBox2.Text);
                    for (int i3 = 0; i3 < 255; i3++)
                    {
                        if (checkBox3.Checked) i3 = int.Parse(textBox3.Text);
                        for (int i4 = 0; i4 < 255; i4++)
                        {
                            if (checkBox4.Checked) i4 = int.Parse(textBox4.Text);
                            res[0] = $"{i1}.{i2}.{i3}.{i4}";
                            label1.Text = res[0];
                            for (int i = 1; i < 7; i++)
                            {
                                string line = "";
                                proc.StartInfo.Arguments = argus[i].Replace("%s", res[0]);
                                bool Completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(500), () =>
                                {
                                    proc.Start();
                                    proc.WaitForExit();
                                });
                                if (Completed)
                                {
                                    while (!proc.StandardOutput.EndOfStream)
                                    {
                                        line += proc.StandardOutput.ReadLine();
                                    }
                                    res[i] = RemoveFirstWord(line);
                                }

                            }
                            if (res[3] != "" && res[3] != null)
                                this.dataGridView1.Rows.Add(res);
                            for (int i = 0; i < res.Length; i++)
                            {
                                res[i] = null;
                            }
                            if (checkBox4.Checked) break;
                        }
                        if (checkBox3.Checked) break;
                    }
                    if (checkBox2.Checked) break;
                }
                if (checkBox1.Checked) break;
            }
            button1.Enabled = true;
            try
            {
                thrad.Abort();
            }
            catch (Exception)
            {
            }
            
        }
        bool isSearching = false;
        Thread thrad;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            thrad.Start();
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = DateTime.Now + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                copyAlltoClipboard();
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();
                xlexcel.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
                Clipboard.Clear();
                dataGridView1.ClearSelection();
            }
        }
    }
}