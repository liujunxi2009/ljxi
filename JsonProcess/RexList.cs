using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonProcess
{
  public partial class RexList : Form
  {
    public RexList()
    {
      InitializeComponent();
    }

    private void listBox1_MouseClick(object sender, MouseEventArgs e)
    {
      Clipboard.SetDataObject(this.listBox1.SelectedItem.ToString());
    }
  }
}
