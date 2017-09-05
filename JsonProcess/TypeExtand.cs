using System;



namespace JsonProcess
{
  public static class TypeExtand
  {
    private static string replace1 = Guid.NewGuid().ToString();
    private static string replace2 = Guid.NewGuid().ToString();
    public static string replacebrackets(this string arg1,string arg2="",string arg3="")
    {
      string result = "";
      if (!string.IsNullOrEmpty(arg2))
      {
        arg1 = arg1.Replace(arg2, replace1);
      }
      if (!string.IsNullOrEmpty(arg3))
      {
        arg1 = arg1.Replace(arg3, replace2);
      }
      result = arg1;
      return result;
    }

    public static string oppreplacebrackets(this string arg1, string arg2 = "", string arg3 = "")
    {
      string result = "";
      if (!string.IsNullOrEmpty(arg2))
      {
        arg1 = arg1.Replace(replace1, arg2);
      }
      if (!string.IsNullOrEmpty(arg3))
      {
        arg1 = arg1.Replace(replace2,arg3);
      }
      result = arg1;
      return result;
    }
  }
}
