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
      string start_elac = @"C:\Windows\system32\SnippingTool.exe";
      usedoscmd(start_elac);
    }
  }
}
