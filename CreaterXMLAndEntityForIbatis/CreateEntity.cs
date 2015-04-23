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
                        Replace("<%tableName%>", GetTableName(dic)).
                        Replace("<%creater%>", create).
                        Replace("<%createTime%>", DateTime.Now.ToString()).
                        Replace("<%className%>", GetClassName(dic)).
                        Replace("<%allField%>", CreateAllField(list, language,dic)).
                        Replace("<%classContent%>", CreateClassContent(list, language));
            byte[] by = Encoding.Default.GetBytes(content);
            if (language != "JAVA")
            {
                gc.WriteToFile(savePath + "\\" + GetTableCode(dic) + ".cs", by);
            }
            else
            {
                gc.WriteToFile(savePath + "\\" + GetTableCode(dic) + ".java", by);
            }
        }


        /// <summary>
        /// 替换<%tableName%>
        /// </summary>
        /// <returns></returns>
        private string GetTableName(IDictionary<string, string> list)
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
        private string GetClassName(IDictionary<string, string> list)
        {
            return GetTableName(list);
        }

        /// <summary>
        /// 替换<%classContent%>
        /// </summary>
        /// <returns></returns>
        private string CreateClassContent(IDictionary<string, string> list, string language)
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
        private string CreateAllField(IDictionary<string, string> list, 
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
        private string GetTableCode(IDictionary<string, string> list)
        {
            return GetTableName(list);
        }

    }
}
