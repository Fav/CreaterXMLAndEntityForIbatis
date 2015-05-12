using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    class CreateService : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\service\\" + GeneralClass.GetActionName(dic) + "Service.java", by);
        }

        public override string GetJTemplate()
        {
            return "JServiceTemplate.txt";
        }
    }
}
