using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class CreateAction
    {
        public CreateAction(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            string template = "";
            if (language != "JAVA")
            {
                //template = "CEntityTemplate.txt";
            }
            else
            {
                template = "JActionTemplate.txt";
            }
            GeneralClass gc = new GeneralClass();
            string content = gc.ReadTemplate(template);
            IDictionary<string, string> dic = gc.GetField(sqlPath);
            string tableDescripe = gc.GetDescripe(sqlPath);
            content = content.
                        Replace("<%tableName%>", GeneralClass.GetTableName(dic)).
                        Replace("<%creater%>", create).
                        Replace("<%tableDescripe%>", gc.GetDescripe(sqlPath)).
                        Replace("<%actionName%>", GeneralClass.GetActionName(dic)).
                        Replace("<%createTime%>", DateTime.Now.ToString());
            byte[] by = Encoding.Default.GetBytes(content);
            if (language != "JAVA")
            {
                //gc.WriteToFile(savePath + "\\action\\" + GetTableCode(dic) + ".cs", by);
            }
            else
            {
                gc.WriteToFile(savePath + "\\action\\" + GeneralClass.GetActionName(dic) + "Action.java", by);
            }
        }
    }
}
