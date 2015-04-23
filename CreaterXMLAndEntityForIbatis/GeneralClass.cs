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
            using (FileStream fs =
                new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                fs.Write(by, 0, by.Length);
                fs.Close();
            }
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
                case "NUMB":
                case "SMAL":
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
                        ret = "double";
                    }
                    else
                    {
                        ret = "double?";
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
    }
}
