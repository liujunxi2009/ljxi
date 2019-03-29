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
    public partial class TransFrom : Form
    {
        public TransFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceTarget = this.richTextBox1.Text;
                String sourceItem = this.textBox1.Text.Trim();
                byte[] sourceBytes = Encoding.GetEncoding(sourceItem).GetBytes(sourceTarget);
                String targetString = this.textBox2.Text.Trim();
                String targetValue = Encoding.GetEncoding(targetString).GetString(sourceBytes);
                this.richTextBox2.Text = targetValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("transform error:"+ ex.Message);
            }

        }
    }
}
