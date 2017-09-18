using JsonProcess;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace JsonProcess
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }


    public LocationItem _Locations { get; set; }

    private void button1_Click(object sender, EventArgs e)
    {
      string str11 = "https://download.lenovo.com/motorola/content/images/online_support.png.png,https://mobilesupport.lenovo.com/uk/ek/chat";
      string str22 = "https://download.lenovo.com/motorola/content/images/online_support.png.png";
      int len11 = str11.Split(',').Length;
      int len22 = str22.Split(',').Length;
      string searchvalue = "Campo Grande";
      string country = "Brazil";
      string distance = "500KM";
      string actionType = "XML";
      string DistanceUnit = Regex.Replace(distance, "[0-9]", "", RegexOptions.IgnoreCase);
      string Distance = distance.Replace(DistanceUnit, "");
      string str = GetBRorMXResponse(searchvalue, country, Distance, DistanceUnit, actionType);
    }


    private string GetBRorMXResponse(string searchvalue = "", string country = "", string distance = "20", string distanceunit = "KM", string actionType = "XML")
    {

      string result = "";

      StringBuilder soap = new StringBuilder();
      soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
      soap.Append("<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ser=\"servicecentral.com\">");
      soap.Append("<soap:Header>");
      soap.Append("<ser:AuthenticationHeader>");
      soap.Append("<ser:SortExpression>0</ser:SortExpression>");
      soap.Append("<ser:FirstRow>0</ser:FirstRow>");
      soap.Append("<ser:MaxRow>0</ser:MaxRow>");
      soap.Append("</ser:AuthenticationHeader>");
      soap.Append("</soap:Header>");
      soap.Append("<soap:Body>");


      if (actionType == "XML")
      {
        soap.Append("<ser:Search>");
      }
      else
      {
        soap.Append("<ser:SearchJson>");
      }

      soap.Append("<ser:searchRequest>");
      soap.Append("<ser:FreeFormText>" + searchvalue + "</ser:FreeFormText>");
      soap.Append("<ser:Distance>" + distance + "</ser:Distance>");
      soap.Append("<ser:DistanceUnit>" + distanceunit + "</ser:DistanceUnit>");
      soap.Append("<ser:Services>");
      soap.Append("<ser:string xsi:nil=\"true\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>");
      soap.Append("</ser:Services>");
      soap.Append("</ser:searchRequest>");

      if (actionType == "XML")
      {
        soap.Append("</ser:Search>");

      }
      else
      {
        soap.Append("</ser:SearchJson>");
      }


      soap.Append("</soap:Body>");
      soap.Append("</soap:Envelope>");

      string IndiaUrl = "http://moto.servicecentral.com/Locator/Search.asmx";
      Uri uri = new Uri(IndiaUrl);
      WebRequest webRequest = WebRequest.Create(uri);
      webRequest.ContentType = "text/xml; charset=utf-8";
      webRequest.Method = "POST";
      using (Stream requestStream = webRequest.GetRequestStream())
      {
        byte[] paramBytes = Encoding.UTF8.GetBytes(soap.ToString());
        requestStream.Write(paramBytes, 0, paramBytes.Length);
      }

      //响应
      WebResponse webResponse = webRequest.GetResponse();
      using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
      {
        var str = myStreamReader.ReadToEnd();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(str);
        XmlElement root = doc.DocumentElement;   //获取根节点  

        var temp = root.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].OuterXml.ToString().Replace(" xmlns=\"servicecentral.com\"", "");


        XmlDocument doc1 = new XmlDocument();
        doc1.LoadXml(temp);



        var Locationtemp = JsonConvert.SerializeXmlNode(doc1);
      

        var tlocations = (JObject)JsonConvert.DeserializeObject(Locationtemp);

        result = Locationtemp.ToString();
      }

      return result;
    }

    private void btn_remove_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text;
      if (this.checkBox1.Checked == true)
      {
        str = str.Replace("\n", "").Replace("\r", "");
      }
      if (this.checkBox2.Checked == true)
      {
        str = str.Replace("\t", "").Replace("\v", "").Replace("\f", "");
      }
      if (this.textBox1.Text != "")

      if (this.textBox1.Text!="")

      {
        string[] str2 = this.textBox1.Text.Split('|');
        for (int i = 0; i < str2.Length; i++)
        {
          str = str.Replace(str2[i], "");
        }
      }
      this.richTextBox2.Text = str;

    }

    private void button2_Click(object sender, EventArgs e)
    {
      string source = this.textBox2.Text;
      string target = this.textBox3.Text;
      string str = this.richTextBox1.Text;
      str = str.Replace(source, target);
      this.richTextBox2.Text = str;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        string guid = this.textBox4.Text;
        string language = this.textBox5.Text;
        StringBuilder sb = new StringBuilder();
        string str = this.richTextBox1.Text;
        var Json = (JObject)JsonConvert.DeserializeObject(str);
        for (int i = 0; i < Json["Responses"].Count(); i++)
        {
          string keys = guid + "|" + language + "|" + Json["Responses"][i]["Type"] + "|" + Json["Responses"][i]["Value"];
          if (Json["Responses"][i]["Type"].ToString()=="8")
          {
            keys = guid + "|" + language + "|" + Json["Responses"][i]["Type"] + "|" + Json["Responses"][i]["Text"];
          }
          string value = Json["Responses"][i]["Image"].ToString();
          sb.Append("{\""+keys+"\",\""+value+"\"},\n");
        }
        this.richTextBox2.Text = sb.ToString();
      }
      catch (Exception ex)
      {

      }

    }

    private void button4_Click(object sender, EventArgs e)
    {
      StringBuilder str = new StringBuilder();
      var pattern = this.rex_text.Text;
      //pattern = @"(?<url>http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)";

      string content = this.richTextBox1.Text;
      Regex re = new Regex(@""+ pattern + "");
      MatchCollection mats = re.Matches(content);

      foreach (Match mat in mats)
      {
        str.Append(mat.Value+"\r\n");
      }
      this.richTextBox2.Text = str.ToString();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      StringBuilder str = new StringBuilder();
      var pattern = this.rex_text.Text;
 

      string content = this.richTextBox1.Text;
      Regex re = new Regex(@"" + pattern + "");
      MatchCollection mats = re.Matches(content);

      foreach (Match mat in mats)
      {
        str.Append(string.Format(this.txt_format.Text.replacebrackets("|{","}|"), mat.Value) + "\r\n");
      }
      this.richTextBox2.Text = str.ToString().oppreplacebrackets("{","}");
    }

    private void btn_removeexits_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox2.Text.Replace("\r","");
      string[] list_str = str.Split('\n');
      var removerepeatstr = (from v in list_str.AsEnumerable() select v).Distinct().ToList();
      str = "";
      for (int i = 0; i < removerepeatstr.Count(); i++)
      {
        str += removerepeatstr[i] + "\n";
      }
      this.richTextBox2.Text = str;
    }

    private void button6_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox2.Text.Replace("\r", "");
      string[] list_str = str.Split('\n');
      var removerepeatstr = (from v in list_str.AsEnumerable() where v.Contains(this.txt_resultfilter.Text) select v).Distinct().ToList();
      str = "";
      for (int i = 0; i < removerepeatstr.Count(); i++)
      {
        str += removerepeatstr[i] + "\n";
      }
      this.richTextBox2.Text = str;
    }

    private void button7_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text.Replace("\r", "");
      string pattern = this.rex_text.Text;
      string newstr = this.txt_format.Text;
      str = Regex.Replace(str, @""+ pattern + "", newstr);
      this.richTextBox2.Text = str;
    }

    private void button8_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text.Replace("\r", "");
      string[] list_str = str.Split('\n');
      string replace = this.txt_single.Text.replacebrackets("|{", "}|");
      string str2 = "";
      for (int i = 0; i < list_str.Count(); i++)
      {
        str2 += string.Format(replace, list_str[i]) +"\n";
      }
      this.richTextBox2.Text = str2.oppreplacebrackets("{", "}");
    }

    private void button9_Click(object sender, EventArgs e)
    {
      DocumentMerge DocMerge = new DocumentMerge();
      DocMerge.Show();
    }

    private void btn_repeatdata_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text.Replace("\r", "");
      string[] list_str = str.Split('\n');
      var t = from v in list_str group v by v into g select new { k = g.Key, c =g.Count() };
      string str1 = "";
      var t1 = (from v in t.AsEnumerable() where v.c > 1 select v.k).ToList();
      for (int i = 0; i < t1.Count(); i++)
      {
        str1 += t1[i]+"\n";
      }
      this.richTextBox2.Text = str1;
    }

    private void btn_rowrex_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text.Replace("\r", "");
      string[] list_str = str.Split('\n');
      var pattern = this.rex_text.Text;
      Regex re = new Regex(@"" + pattern + "");
      StringBuilder str1 = new StringBuilder();
      for (int i = 0; i < list_str.Length; i++)
      {
        MatchCollection mats = re.Matches(list_str[i].Trim());

        foreach (Match mat in mats)
        {
          str1.Append(mat.Value + "\r\n");
        }
      }
      this.richTextBox2.Text = str1.ToString();
    }

    private void btn_rexpopup_Click(object sender, EventArgs e)
    {
      RexList rexlist = new RexList();
      rexlist.Show();
    }

    private void btn_shortcuttool_Click(object sender, EventArgs e)
    {
      ShrotCutWindow scwindow = new ShrotCutWindow();
      scwindow.Show();
    }

    private void button10_Click(object sender, EventArgs e)
    {
      string str = this.richTextBox1.Text.Replace(" ","").Replace("\r","");
      string prefix = this.txt_prefix.Text;
      string[] strs = str.Split('\n');
      StringBuilder sbr = new StringBuilder();
      for (int i = 0; i < strs.Length; i++)
      {
        if (strs[i]!=null)
        {
          string tempstr = ToGuid(prefix + strs[i]);
          sbr.Append(tempstr+"\r\n");
        }
      }
      this.richTextBox2.Text = sbr.ToString();
    }


    public  string ToGuid(string pString)
    {
      byte[] bString = Encoding.UTF8.GetBytes(pString.ToUpper());
      byte[] bHash = new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(bString);
      Array.Resize(ref bHash, 16);
      return new Guid(bHash).ToString().ToUpper();
    }
  }



  public class OperatingHoursItem
{
  public string day { get; set; }
  public string startTime { get; set; }
  public string endTime { get; set; }
}

public class OperatingHours
{
  public List<OperatingHoursItem> _OperatingHours { get; set; }
}

public class Services
{
  public string _string { get; set; }
}

public class LocationItem
{
  /// <summary>
  /// 
  /// </summary>
  public string Id { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Name { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Address1 { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Address2 { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Address3 { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Address4 { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string City { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string State { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string ZipCode { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Country { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Phone { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Distance { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Latitude { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public string Longitude { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public OperatingHours OperatingHours { get; set; }
  /// <summary>
  /// 
  /// </summary>
  public Services Services { get; set; }
}








public static class DocumentExtensions
{
  public static XmlDocument ToXmlDocument(this XDocument xDocument)
  {
    var xmlDocument = new XmlDocument();
    using (var xmlReader = xDocument.CreateReader())
    {
      xmlDocument.Load(xmlReader);
    }
    return xmlDocument;
  }

  public static XDocument ToXDocument(this XmlDocument xmlDocument)
  {
    using (var nodeReader = new XmlNodeReader(xmlDocument))
    {
      nodeReader.MoveToContent();
      return XDocument.Load(nodeReader);
    }
  }

}



}
