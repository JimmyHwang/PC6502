using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Data;

namespace DNA64.Library {
  public static class Common {
    public static dynamic json_decode(string data) {
      return JValue.Parse(data);
    }

    public static string json_encode(dynamic data) {
      return JsonConvert.SerializeObject (data, Formatting.Indented);
    }

    public static bool isset(dynamic settings, string key) {
      if (settings is ExpandoObject) {
        return ((IDictionary<string, object>)settings).ContainsKey(key);
      } else if (settings is JObject) {
        return settings.ContainsKey(key);
      }
      return settings.GetType().GetProperty(key) != null;
    }

    public static ExpandoObject DeepCopy (ExpandoObject original) {
      var clone = new ExpandoObject ();

      var _original = (IDictionary<string, object>)original;
      var _clone = (IDictionary<string, object>)clone;

      foreach (var kvp in _original)
        _clone.Add (kvp.Key, kvp.Value is ExpandoObject ? DeepCopy ((ExpandoObject)kvp.Value) : kvp.Value);

      return clone;
    }

    public static object CloneObject(object obj) {
      dynamic temp = new ExpandoObject();
      temp.Object = obj;
      string json_data = json_encode(temp);
      temp = json_decode(json_data);
      return temp.Object;
    }

    public static void DeleteAll(string folder) {
      System.IO.DirectoryInfo di = new DirectoryInfo (folder);

      foreach (FileInfo file in di.GetFiles ()) {
        file.Delete ();
      }
      foreach (DirectoryInfo dir in di.GetDirectories ()) {
        dir.Delete (true);
      }
    }

    public static void Empty (this System.IO.DirectoryInfo directory) {
      foreach (System.IO.FileInfo file in directory.GetFiles ()) file.Delete ();
      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories ()) subDirectory.Delete (true);
    }

    public static string MD5(this string str) {
      using (var cryptoMD5 = System.Security.Cryptography.MD5.Create()) {
        var bytes = Encoding.UTF8.GetBytes(str);
        var hash = cryptoMD5.ComputeHash(bytes);
        var md5 = BitConverter.ToString(hash)
          .Replace("-", String.Empty)
          .ToUpper();
        return md5;
      }
    }

    public static double Evaluate(string expression) {
      var loDataTable = new DataTable();
      var loDataColumn = new DataColumn("Eval", typeof(double), expression);
      loDataTable.Columns.Add(loDataColumn);
      loDataTable.Rows.Add(0);
      return (double)(loDataTable.Rows[0]["Eval"]);
    }
  }
}