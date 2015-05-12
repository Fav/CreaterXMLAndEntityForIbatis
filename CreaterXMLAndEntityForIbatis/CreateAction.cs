using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class CreateAction:Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\action\\" + GeneralClass.GetActionName(dic) + "Action.java", by);
        }

        public override string GetJTemplate()
        {
            return "JActionTemplate.txt";
        }
    }
}
