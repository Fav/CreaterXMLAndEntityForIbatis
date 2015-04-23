using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    internal class CreateXML
    {
        public CreateXML(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            string template = "";
            if (language != "JAVA")
            {
                template = "CXMLTemplate.txt";
            }
            else
            {
                template = "JXMLTemplate.txt";
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string,string> list = gc.GetField(sqlPath);
            if (list != null && list.Count > 0)
            {
                content = content.
                          Replace("<%tableCode%>", GetTableCode(list)).
                          Replace("<%className%>", GetTableCode(list)+"Class").
                          Replace("<%resultMap%>", CreateResultMap(list, language)).
                          Replace("<%allColumn%>",CreateAllColumn(list)).
                          Replace("<%create%>", CreateCreateCode(list)).
                          Replace("<%update%>", CreateUpdate(list, language)).
                          Replace("<%primarykey%>", CreatePrimarykey(list)).
                          Replace("<%dynamicWhere%>",CreateDynamicWhere(list)).
                          Replace("<%dynamicScope%>",CreateDynamicScope(list));
                byte[] by = Encoding.Default.GetBytes(content);
                gc.WriteToFile(savePath + "\\dao\\sqlmap\\" + GetTableCode(list) + ".xml", by);
            }
        }

        /// <summary>
        /// 替换<%resultMap%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateResultMap(IDictionary<string, string> list, string language)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr += "\r\n" +
                                  "           <result property=\"" + item.Key + "\" column=\"" + item.Key + "\" />";
                    }
                    else
                    {
                        retStr += "\r\n" +
                                  "           <result property=\"_" + item.Key + "\" column=\"" + item.Key + "\" />";
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
            return GeneralClass.GetTableCode(list);
        }

        
       /// <summary>
        /// 替换<%allColumn%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateAllColumn(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    retStr += item.Key + ",";
                }
            }
            return retStr.TrimEnd(',');
        }

        /// <summary>
        /// 替换<%create%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateCreateCode(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    retStr += "#" + item.Key + "#,";
                }
            }
            return retStr.TrimEnd(',');
        }

        /// <summary>
        /// 替换<%update%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateUpdate(IDictionary<string, string> list, string language)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr += "\r\n" +
                                  "         <isNotNull prepend=\",\" property=\"" + item.Key + "\"> " +
                                  "" + item.Key + " = #" + item.Key + "#</isNotNull>";
                    }
                    else
                    {
                        retStr += "\r\n"+
                                  "         <isNotNull prepend=\",\" property=\"_" + item.Key + "\"> " +
                                  "" + item.Key + " = #_" + item.Key + "#</isNotNull>";
                    }
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%primarykey%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreatePrimarykey(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    retStr = item.Key + " = #" + item.Key + "#";
                    break;
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%dynamicWhere%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateDynamicWhere(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    retStr += "\r\n"+
                              "          <isNotNull prepend=\"and\" property=\"" + item.Key + "\">" +
                              "" + item.Key + " like '%$" + item.Key + "$%'</isNotNull>";
                }
            }
            return retStr;
        }

        /// <summary>
        /// 替换<%dynamicScope%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateDynamicScope(IDictionary<string, string> list)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    retStr += "\r\n" +
                              "          <isNotNull prepend=\"and\" property=\"scope." + item.Key + "\"> " +
                              "" + item.Key + " = '$scope." + item.Key + "$'" +
                              "</isNotNull>";
                }
            }
            return retStr;
        }
       
    }
}
