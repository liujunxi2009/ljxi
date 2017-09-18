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
  public partial class ShrotCutWindow : Form
  {
    public ShrotCutWindow()
    {
      InitializeComponent();
    }

    private void start_elac_Click(object sender, EventArgs e)
    {
      string start_elac = @"C:\Windows\system32\calc.exe";
      usedoscmd(start_elac);
    }

    protected void usedoscmd(string cmd)
    {
      System.Diagnostics.Process.Start(cmd);

    }

    private void button1_Click(object sender, EventArgs e)
    {
      string start_elac = @"C:\Windows\system32\mspaint.exe";
      usedoscmd(start_elac);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string start_elac = @"C:\Windows\system32\cmd.exe";
      usedoscmd(start_elac);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      string start_elac = @"C:\Windows\system32\mstsc.exe";
      usedoscmd(start_elac);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      Process p = new Process();  // 初始化新的进程
      p.StartInfo.FileName = "CMD.EXE"; //创建CMD.EXE 进程
      p.StartInfo.RedirectStandardInput = true; //重定向输入
      p.StartInfo.RedirectStandardOutput = true;//重定向输出
      p.StartInfo.UseShellExecute = false; // 不调用系统的Shell
      p.StartInfo.RedirectStandardError = true; // 重定向Error
      p.StartInfo.CreateNoWindow = true; //不创建窗口
      p.Start(); // 启动进程
      p.StandardInput.WriteLine("call C:\\Windows\\system32\\mspaint.exe"); // Cmd 命令
      p.StandardInput.WriteLine("exit"); // 退出
      string s = p.StandardOutput.ReadToEnd(); //将输出赋值给 S
      p.WaitForExit();  // 等待退出





      //string start_elac = @"C:\Windows\system32\SnippingTool.exe";
      //usedoscmd(start_elac);
    }
  }
}
