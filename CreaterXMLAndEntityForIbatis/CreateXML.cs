using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    internal class CreateXML : ICreater
    {
        public CreateXML(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            string template = "";
            if (language != "JAVA")
            {
                template = "CreaterXMLAndEntityForIbatis.CXMLTemplate.txt";
            }
            else
            {
                template = "CreaterXMLAndEntityForIbatis.JXMLTemplate.txt";
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string,string> list = gc.GetField(sqlPath);
            if (list != null && list.Count > 0)
            {
                content = content.
                          Replace("<%tableCode%>", ReplaceTableCode(list)).
                          Replace("<%className%>", ReplaceTableCode(list)+"Class").
                          Replace("<%resultMap%>", ReplaceResultMap(list, language)).
                          Replace("<%allColumn%>",ReplaceAllColumn(list)).
                          Replace("<%create%>", ReplaceCreate(list)).
                          Replace("<%update%>", ReplaceUpdate(list, language)).
                          Replace("<%primarykey%>", ReplacePrimarykey(list)).
                          Replace("<%dynamicWhere%>",ReplaceDynamicWhere(list)).
                          Replace("<%dynamicScope%>",ReplaceDynamicScope(list));
                byte[] by = Encoding.Default.GetBytes(content);
                gc.WriteToFile(savePath + "\\" + ReplaceTableCode(list) + ".xml", by);
            }
        }

        /// <summary>
        /// 替换<%resultMap%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string ReplaceResultMap(IDictionary<string, string> list, string language)
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

        
       /// <summary>
        /// 替换<%allColumn%>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string ReplaceAllColumn(IDictionary<string, string> list)
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
        private string ReplaceCreate(IDictionary<string, string> list)
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
        private string ReplaceUpdate(IDictionary<string, string> list, string language)
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
        private string ReplacePrimarykey(IDictionary<string, string> list)
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
        private string ReplaceDynamicWhere(IDictionary<string, string> list)
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
        private string ReplaceDynamicScope(IDictionary<string, string> list)
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
