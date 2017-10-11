using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonProcess
{
    public partial class publish : Form
    {
        public publish()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task tk = new Task(()=> {
                syncupdatedata();
            });
            tk.Start();
        }

        private void syncupdatedata()
        {
            this.richTextBox1.Text = "处理中...";
            string path = this.txt_datapath.Text;
            string letterofdisk = path.Split(':')[0] + ":";
            string programname = path.Split('\\').LastOrDefault();
            string programpath = path.Replace(programname, "").TrimEnd('\\');
            Process p = new Process();  // 初始化新的进程
            p.StartInfo.FileName = "CMD.EXE"; //创建CMD.EXE 进程
            p.StartInfo.RedirectStandardInput = true; //重定向输入
            p.StartInfo.RedirectStandardOutput = true;//重定向输出
            p.StartInfo.UseShellExecute = false; // 不调用系统的Shell
            p.StartInfo.RedirectStandardError = true; // 重定向Error
            p.StartInfo.CreateNoWindow = true; //不创建窗口
            p.Start(); // 启动进程
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("echo.");
            sb.AppendLine("echo 开始执行(start exec)！");
            sb.AppendLine(letterofdisk);
            sb.AppendLine(@"cd " + programpath);
            sb.AppendLine("call " + programname + " " + this.txt_param.Text);
            sb.AppendLine("echo.");
            sb.AppendLine("echo MOTO文档修复完毕(document updated sucessful)！");
            sb.AppendLine("echo.");
            sb.AppendLine("echo 程序运行完毕(exec finish)！");

            p.StandardInput.WriteLine(sb.ToString()); // Cmd 命令
            p.StandardInput.WriteLine("exit"); // 退出
            string s = p.StandardOutput.ReadToEnd(); //将输出赋值给 S
            this.richTextBox1.Text = s;
            p.WaitForExit();  // 等待退出
            this.richTextBox1.Text = s + "\r\n 处理完成 时间:" + DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task tk = new Task(() => {
                PublisCssAndJs();
            });
            tk.Start();
           
        }

        private void PublisCssAndJs()
        {
            this.richTextBox1.Text = "处理中...";
            Process p = new Process();  // 初始化新的进程
            p.StartInfo.FileName = "CMD.EXE"; //创建CMD.EXE 进程
            p.StartInfo.RedirectStandardInput = true; //重定向输入
            p.StartInfo.RedirectStandardOutput = true;//重定向输出
            p.StartInfo.UseShellExecute = false; // 不调用系统的Shell
            p.StartInfo.RedirectStandardError = true; // 重定向Error
            p.StartInfo.CreateNoWindow = true; //不创建窗口
            p.Start(); // 启动进程
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"xcopy " + this.txt_jspath.Text + " " + this.txt_pubpath.Text + "  /s /e /y");
            sb.AppendLine("echo 程序发布完毕！");
            p.StandardInput.WriteLine(sb.ToString()); // Cmd 命令
            p.StandardInput.WriteLine("exit"); // 退出
            string s = p.StandardOutput.ReadToEnd(); //将输出赋值给 S
            this.richTextBox1.Text = s;
            p.WaitForExit();  // 等待退出
            this.richTextBox1.Text = s + "\r\n 处理完成 时间:" + DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Task tk = new Task(() => {
                PublisDll();
            });
            tk.Start();
        }

        private void PublisDll()
        {
            this.richTextBox1.Text = "处理中...";
            Process p = new Process();  // 初始化新的进程
            p.StartInfo.FileName = "CMD.EXE"; //创建CMD.EXE 进程
            p.StartInfo.RedirectStandardInput = true; //重定向输入
            p.StartInfo.RedirectStandardOutput = true;//重定向输出
            p.StartInfo.UseShellExecute = false; // 不调用系统的Shell
            p.StartInfo.RedirectStandardError = true; // 重定向Error
            p.StartInfo.CreateNoWindow = true; //不创建窗口
            p.Start(); // 启动进程
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"xcopy " + this.txt_dllpath.Text + " " + this.txt_dllpubpath.Text + " /s /e /y");

            sb.AppendLine("echo 程序发布完毕！");

            p.StandardInput.WriteLine(sb.ToString()); // Cmd 命令
            p.StandardInput.WriteLine("exit"); // 退出
            string s = p.StandardOutput.ReadToEnd(); //将输出赋值给 S
            this.richTextBox1.Text = s;
            p.WaitForExit();  // 等待退出
            this.richTextBox1.Text = s + "\r\n 处理完成 时间:" + DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
