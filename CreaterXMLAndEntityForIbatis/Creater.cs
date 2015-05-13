using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class Creater
    {
        private string JTemplate = "";

        protected string create = "";
        protected string savePath = "";
        protected string sqlPath = "";
        protected string language = "";
        protected string packageName = "";

        public void GetInfo(CInputInfo info)
        {
            create = info.create;
            savePath = info.savePath;
            sqlPath = info.sqlPath;
            language = info.language;
            packageName = info.packageName;
        }
        public virtual void Run(CInputInfo info)
        {
            GetInfo(info);
            string template = "";
            if (language != "JAVA")
            {
                //template = "CEntityTemplate.txt";
            }
            else
            {
                template = GetJTemplate(); 
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string, string> dic = gc.GetField(sqlPath);
            IDictionary<string, string> list = gc.GetFieldType(sqlPath, language);
            string tableDescripe = gc.GetDescripe(sqlPath);

            content = content.
                        Replace("<%className%>", GetClassName(dic)).
                        Replace("<%allField%>", CreateAllField(list, language, dic)).
                        Replace("<%classContent%>", CreateClassContent(list, language)).
                        Replace("<%packageName%>", packageName).
                        Replace("<%tableName%>", GeneralClass.GetTableName(dic)).
                        Replace("<%tableVarName%>", GeneralClass.GetTableName(dic).ToLower()).
                        Replace("<%creater%>", create).
                        Replace("<%tableDescripe%>", gc.GetDescripe(sqlPath)).
                        Replace("<%actionName%>", GeneralClass.GetActionName(dic)).
                        Replace("<%actionVarName%>", GeneralClass.GetActionVarName(dic)).
                        Replace("<%createTime%>", DateTime.Now.ToString());
            byte[] by = Encoding.Default.GetBytes(content);
            if (language != "JAVA")
            {
                //gc.WriteToFile(savePath + "\\action\\" + GetTableCode(dic) + ".cs", by);
            }
            else
            {
                OutJFile(dic,by); 
            }
        }


        public virtual void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
        }

        public virtual string GetJTemplate()
        {
            return "";
        }

        /// <summary>
        /// 替换<%tableName%>
        /// </summary>
        /// <returns></returns>
        protected string GetTableName(IDictionary<string, string> dic)
        {
            return GeneralClass.GetTableCode(dic);
        }

        /// <summary>
        /// 替换<%className%>
        /// </summary>
        /// <returns></returns>
        protected string GetClassName(IDictionary<string, string> list)
        {
            return GetTableName(list);
        }

        /// <summary>
        /// 替换<%classContent%>
        /// </summary>
        /// <returns></returns>
        protected string CreateClassContent(IDictionary<string, string> list, string language)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr +=
                                   "    public " + item.Value + " get" + item.Key + "() { \r\n" +
                                   "        return " + item.Key + ";\r\n" +
                                   "    }\r\n\r\n" +
                                   "    public void set" + item.Key + "(" + item.Value + " " + GetVarName(item.Key) + ") {\r\n" +
                                   "        " + item.Key + " = " + GetVarName(item.Key) + ";\r\n" +
                                   "    }\r\n";
                    }
                    else
                    {
                        retStr += "\r\n" +
                                   "    public " + item.Value + " _" + item.Key + " \r\n" +
                                   "    { \r\n" +
                                   "        get { return _" + item.Key + "; }\r\n" +
                                   "        set { _" + item.Key + " = value; }\r\n" +
                                   "    }\r\n";
                    }
                }
            }
            return retStr;
        }

        private string GetVarName(string p)
        {
            return p[0].ToString().ToLower() + p.Substring(1);
        }

        /// <summary>
        /// 替换<%allField%>
        /// </summary>
        /// <returns></returns>
        protected string CreateAllField(IDictionary<string, string> list,
                         string language, IDictionary<string, string> dic)
        {
            string retStr = "";
            foreach (KeyValuePair<string, string> item in list)
            {
                if (item.Key.Length > 7)
                {
                    if (language == "JAVA")
                    {
                        retStr += "    /*\r\n" +
                                  "     * " + dic[item.Key].Trim('\'') + "\r\n" +
                                  "     */\r\n" +
                                   "    private " + item.Value + " " + item.Key + ";" + "\r\n";
                    }
                    else
                    {
                        retStr +=
                                   "    private " + item.Value + " _" + item.Key + ";     //" + dic[item.Key];
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
        protected string GetTableCode(IDictionary<string, string> list)
        {
            return GetTableName(list);
        }
    }
    public class CInputInfo
    {
        public string create { get; set; }
        public string savePath { get; set; }
        public string sqlPath { get; set; }
        public string language { get; set; }
        public string packageName { get; set; }
    }
}
