using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class GeneralClass
    {
        public string ReadTemplate(string template)
        {
            string by = File.ReadAllText(template, Encoding.UTF8);
            
            if (by != null && by.Length > 0)
            {
                return by;
            }
            return "";
        }

        public IDictionary<string,string> GetField(string path)
        {
            IDictionary<string, string> retlist = null;
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path, Encoding.UTF8);
                string[] needStr = content.Split(';');
                if (needStr != null && needStr.Length > 0)
                {
                    retlist = new Dictionary<string, string>();
                    for (int i = 1; i < needStr.Length - 1; i++)
                    {
                        string[] split = needStr[i].Split('.');
                        if (split != null && split.Length > 1)
                        {
                            string[] ret = split[1].Split('i', 's');
                            retlist.Add(ret[0].Trim(), ret[2].Trim());
                        }
                        else
                        {
                            string[] ret = split[0].Split('t', 'a', 'b', 'l', 'e', 'i', 's');
                            retlist.Add(ret[ret.Length - 3].Trim(), ret[ret.Length - 1].Trim());
                        }
                    }
                }
            }
            return retlist;
        }

        public void WriteToFile(string filePath, byte[] by)
        {
            string dicPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dicPath))
            {
                Directory.CreateDirectory(dicPath);
            }
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            string str = System.Text.Encoding.Default.GetString(by);
            sw.Write(str);
            sw.Close();
        }

        public IDictionary<string, string> GetFieldType(string path, string language)
        {
            IDictionary<string, string> dic = null;
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path, Encoding.UTF8);
                string[] needStr = content.Split(';');
                if (needStr != null && needStr.Length > 0)
                {
                    string typeStr = needStr[0];
                    int start = typeStr.IndexOf("(");
                    string retStr = typeStr.Substring(start + 1).TrimEnd(')');
                    string[] str = retStr.Split( new char[]{'\r','\n'},
                        StringSplitOptions.RemoveEmptyEntries);
                    if (str != null && str.Length > 0)
                    {
                        dic = new Dictionary<string, string>();
                        for (int i = 0; i < str.Length-1; i++)
                        {
                            string[] line = str[i].Split(new char[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries);
                            dic.Add(line[0], FilterType(line[1], language));
                        }
                    }
                }
            }
            return dic;
        }

        private string FilterType(string val, string language)
        {
            string flag = "";
            if (val.TrimEnd(',').IndexOf(',') != -1)
            {
                flag = val.Substring(0, 5);
            }
            else
            {
                flag = val.Substring(0, 4);
            }
            string ret = "";
            switch (flag.ToUpper())
            {
                case "VARC":
                case "CHAR":
                    if (language == "JAVA")
                    {
                        ret = "String";
                    }
                    else
                    {
                        ret = "string";
                    }
                    break;
                case "DATE":
                    if (language == "JAVA")
                    {
                        ret = "Date";
                    }
                    else
                    {
                        ret = "DateTime";
                    }
                    break;
                case "SMAL":
                case "INT,":
                case "INTE":
                    if (language == "JAVA")
                    {
                        ret = "int";
                    }
                    else
                    {
                        ret = "int?";
                    }
                    break;
                case "DOUB":
                case "NUMBE":
                    if (language == "JAVA")
                    {
                        ret = "double";
                    }
                    else
                    {
                        ret = "double?";
                    }
                    break;
                case "CLOB":
                    if (language == "JAVA")
                    {
                        ret = "String";
                    }
                    else
                    {
                        ret = "string?";
                    }
                    break;
                case "BOOL":
                    if (language == "JAVA")
                    {
                        ret = "boolean";
                    }
                    else
                    {
                        ret = "bool";
                    }
                    break;
                default:

                    break;
            }
            return ret;
        }

        internal static string GetTableCode(IDictionary<string, string> dic)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in dic)
            {
                if (item.Key.Length == 7)
                {
                    retStr = item.Key;
                    break;
                }
            }
            return retStr;
        }

        internal static string GetActionName(IDictionary<string, string> dic)
        {
            string tablename = GetTableCode(dic);
            if (!DicTableAction.ContainsKey(tablename))
            {
                OutLog(tablename+"无action描述");
                return tablename;
            }
            return DicTableAction[tablename];
        }

        private static void OutLog(string p)
        {
            System.Windows.Forms.MessageBox.Show(p);
        }
        internal static Dictionary<string, string> DicTableAction = new Dictionary<string, string>()
        {
            //{"YPCA01A","EmergencyAgency"},
            //{"YPCA02A","EmergencyStaff"},
            //{"YDAA02C","EmergencyProficient"},
            {"YPDA08A","EmergencyCases"},
            {"YPDA02A","DisposalMethod"},
        };

        internal static string GetTableName(IDictionary<string, string> dic)
        {
           return GetTableCode(dic);
        }

        internal static string GetActionVarName(IDictionary<string, string> dic)
        {
            string actionName = GetActionName(dic);
            return actionName[0].ToString().ToLower() + actionName.Substring(1);
        }

        internal string GetDescripe(string sqlPath)
        {
            string[] str = File.ReadAllLines(sqlPath, Encoding.UTF8);
            return str[0].Trim('-');
        }
    }
}
