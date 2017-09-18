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
  public partial class DocumentMerge : Form
  {
    public DocumentMerge()
    {
      InitializeComponent();
    }

    private void btn_merge_Click(object sender, EventArgs e)
    {
      string left_content = this.richTextBox1.Text.Replace("\r", "");
      string right_content = this.richTextBox2.Text.Replace("\r", "");



      string mergerule = this.txt_merge.Text.replacebrackets("|{", "}|");
      string[] left_str = left_content.Split('\n');
      string[] right_str = right_content.Split('\n');
      int index = left_str.Length > right_str.Length ? left_str.Length : right_str.Length;
      string mergecontent = "";
      for (int i = 0; i < index; i++)
      {
        string[] objparam = new string[2];
        objparam[0] = i < left_str.Length ? left_str[i] : "";
        objparam[1] = i < right_str.Length ? right_str[i] : "";
        mergecontent += string.Format(mergerule, objparam)+"\n";
      }
      this.richTextBox3.Text = mergecontent.oppreplacebrackets("{", "}");
    }

    private void btn_comparison_Click(object sender, EventArgs e)
    {
      string left_content = this.richTextBox1.Text.Replace("\r", "");
      string right_content = this.richTextBox2.Text.Replace("\r", "");
      List<string> left_list = left_content.Split('\n').ToList();
      List<string> right_list = right_content.Split('\n').ToList();
      List<string> left_unnecessary = new List<string>();
      List<string> right_unnecessary = new List<string>();
      left_unnecessary = left_list.Except(right_list).ToList();
      right_unnecessary = right_list.Except(left_list).ToList();
      var union_list = left_list.Intersect(right_list).ToList();

      string result = "左则多出：\n";
      for (int i = 0; i < left_unnecessary.Count(); i++)
      {
        result += left_unnecessary[i] + "\n";
      }

      result += "\r\n右则多出：\n";
      for (int i = 0; i < right_unnecessary.Count(); i++)
      {
        result += right_unnecessary[i] + "\n";
      }

      result += "\r\n交集输出：\n";
      for (int i = 0; i < union_list.Count(); i++)
      {
        result += union_list[i] + "\n";
      }

      this.richTextBox3.Text = result;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string left_content = this.richTextBox1.Text.Replace("\r", "");
      string right_content = this.richTextBox2.Text.Replace("\r", "");
      List<string> left_list = left_content.Split('\n').ToList();
      List<string> right_list = right_content.Split('\n').ToList();
      List<string[]> lstr1 = new List<string[]>();
      List<string[]> rstr1 = new List<string[]>();
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < left_list.Count; i++)
      {
        string[] tlstr = left_list[i].Split('|');
        lstr1.Add(tlstr);
      }
      for (int i = 0; i < right_list.Count; i++)
      {
        string[] trstr = right_list[i].Split('|');
        rstr1.Add(trstr);
      }
      var lenumlist = from v in lstr1.AsEnumerable() select new { n1 = v[0], n2 = v[1] };
      var renumlist = from v in rstr1.AsEnumerable() select new { n1 = v[0], n2 = v[1] };

      var lrenum = (from v in lenumlist join p in renumlist on v.n1 equals p.n1 select new {
        n1 = v.n1,
        n2 = v.n2,
        n3 = p.n2
      });
    foreach (dynamic item in lrenum)
    {
        sb.Append("{\""+item.n2 + "\",\"" + item.n3 + "\",\"" + item.n1 + "\"},\r\n");
    }

      this.richTextBox3.Text = sb.ToString();
    }

    private void btn_count_Click(object sender, EventArgs e)
    {
      string left_content = this.richTextBox1.Text.Replace("\r", "");
      string right_content = this.richTextBox2.Text.Replace("\r", "");
      string merge_content = this.richTextBox2.Text.Replace("\r", "");
      string[] left_count = left_content.Replace("\t", "").Replace("\v", "").Replace("\f", "").Replace(" ","").Trim().Split('\n');
      string[] right_count = right_content.Replace("\t", "").Replace("\v", "").Replace("\f", "").Replace(" ", "").Trim().Split('\n');
      string[] merge_count = merge_content.Replace("\t", "").Replace("\v", "").Replace("\f", "").Replace(" ", "").Trim().Split('\n');
      string outstr = "";
      if (left_count.Length>0)
      {
        outstr += "左侧总计行数:"+left_count.Where(x=>!string.IsNullOrEmpty(x)).Count()+"\r\n";
      }
      if (right_count.Length > 0)
      {
        outstr += "右侧总计行数:" + right_count.Where(x => !string.IsNullOrEmpty(x)).Count() + "\r\n";
      }
      if (merge_count.Length > 0)
      {
        outstr += "下侧总计行数:" + merge_count.Where(x => !string.IsNullOrEmpty(x)).Count() + "\r\n";
      }
      if (string.IsNullOrEmpty(outstr))
      {
        outstr = "当前所有行数为0";
      }
      MessageBox.Show(outstr);
    }
  }
}
