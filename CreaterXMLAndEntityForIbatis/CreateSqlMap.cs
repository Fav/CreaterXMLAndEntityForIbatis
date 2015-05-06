using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    class CreateSqlMap : Creater
    {
        public override void Run(string create, string savePath, string sqlPath, string language)
        {
            string template = "";
            if (language != "JAVA")
            {
                //template = "CEntityTemplate.txt";
            }
            else
            {
                template = "JSqlMapTemplate.txt";
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string, string> dic = gc.GetField(sqlPath);
            content = content.
                        Replace("<%tableName%>", GeneralClass.GetTableName(dic)).
                        Replace("<%tableDescripe%>", gc.GetDescripe(sqlPath)).
                        Replace("<%creater%>", create).
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
                gc.WriteToFile(savePath + "\\SqlMap.txt", by, true, true);
            }
        }
    }
}
