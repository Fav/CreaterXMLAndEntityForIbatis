using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    internal class CreateEntity : ICreater
    {
        public CreateEntity(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            string template = "";
            if (language != "JAVA")
            {
                template = "CEntityTemplate.txt";
            }
            else
            {
                template = "JEntityTemplate.txt";
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string, string> dic = gc.GetField(sqlPath);
            IDictionary<string, string> list = gc.GetFieldType(sqlPath, language);
            content = content.
                        Replace("<%tableName%>", ReplaceTableName(dic)).
                        Replace("<%creater%>", create).
                        Replace("<%createTime%>", DateTime.Now.ToString()).
                        Replace("<%className%>", ReplaceClassName(dic)).
                        Replace("<%allField%>", ReplaceAllField(list, language,dic)).
                        Replace("<%classContent%>", ReplaceClassContent(list, language));
            byte[] by = Encoding.Default.GetBytes(content);
            if (language != "JAVA")
            {
                gc.WriteToFile(savePath + "\\" + ReplaceTableCode(dic) + ".cs", by);
            }
            else
            {
                gc.WriteToFile(savePath + "\\" + ReplaceTableCode(dic) + ".java", by);
            }
        }


        /// <summary>
        /// 替换<%tableName%>
        /// </summary>
        /// <returns></returns>
        private string ReplaceTableName(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length == 7)
                {
                    retStr = item.Value;
                    break;
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%className%>
        /// </summary>
        /// <returns></returns>
        private string ReplaceClassName(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length == 7)
                {
                    retStr = item.Key;
                    break;
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%classContent%>
        /// </summary>
        /// <returns></returns>
        private string ReplaceClassContent(IDictionary<string, string> list, string language)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr += "\r\n" +
                                   "         public " + item.Value + " get" + item.Key + "() { \r\n" +
                                   "            return " + item.Key + ";\r\n" +
                                   "         }\r\n" +
                                   "         public void set" + item.Key + "(" + item.Value + " " + item.Key.Replace('Y', 'y') + ") {\r\n" +
                                   "            " + item.Key + " = " + item.Key.Replace('Y', 'y') + ";\r\n" +
                                   "         }";
                    }
                    else
                    {
                        retStr += "\r\n" +
                                   "         public " + item.Value + " _" + item.Key + " \r\n" +
                                   "        { \r\n" +
                                   "           get { return _" + item.Key + "; }\r\n" +
                                   "           set { _" + item.Key + " = value; }\r\n" +
                                   "         }";
                    }
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%allField%>
        /// </summary>
        /// <returns></returns>
        private string ReplaceAllField(IDictionary<string, string> list, 
                         string language,IDictionary<string, string> dic)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr += "\r\n" +
                                   "       private " + item.Value + " " + item.Key + ";     //" + dic[item.Key];
                    }
                    else
                    {
                        retStr += "\r\n" +
                                   "       private " + item.Value + " _" + item.Key + ";     //" + dic[item.Key];
                    }
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%tableCode%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string ReplaceTableCode(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length == 7)
                {
                    retStr = item.Key;
                    break;
                }
            }
            return retStr;
        }

    }
}
