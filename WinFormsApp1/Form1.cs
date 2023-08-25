using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Thread scannerThread = new Thread(delegate () { });
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
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

        private void HandleMyThread()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string[] argus = { "", "/NODE:%s computersystem get username","/NODE:%s computersystem get name", "/NODE:%s baseboard get product" , "/NODE:%s cpu get name",
                "/NODE:%s path win32_videocontroller get Caption", "/NODE:%s MEMORYCHIP get partnumber" };
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic.exe",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            var list = new IPRange(textBox1.Text).GetAllIP();

            foreach (var item in list)
            {
                string[] res = new string[7];
                res[0] = item.ToString();
                label1.Text = res[0];
                bool Completed = false;
                string errors = "";
                for (int i = 1; i < 7; i++)
                { 
                    proc.StartInfo.Arguments = argus[i].Replace("%s", res[0]);
                    Completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(1000), () =>
                    {
                        proc.Start();
                        proc.WaitForExit();
                    });
                    if (Completed)
                    {
                        string line = "";
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            line += proc.StandardOutput.ReadToEnd();
                            errors += proc.StandardError.ReadToEnd();
                        }

                        if (errors.Length > 0)
                        {
                            Console.WriteLine(errors);
                            break;
                        }
                        res[i] = RemoveFirstWord(line).Replace("\r\n", string.Empty);
                    } else
                    {
                        errors = $"Узел: {item.ToString()}\nОШИБКА.\nОписание: Превышено время ожидания ответа";
                        Console.WriteLine(errors);
                        break;
                    }

                }
                if (Completed && errors.Length == 0)
                    this.dataGridView1.Rows.Add(res);         
            }
            button1.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            if (!scannerThread.IsAlive)
            {
                scannerThread = new Thread(HandleMyThread);
                scannerThread.IsBackground = true;
                scannerThread.Start();
            }
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
                try
                {
                    xlexcel.DisplayAlerts = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Файл уже используется");
                }
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
                Clipboard.Clear();
                dataGridView1.ClearSelection();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}