using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    internal class CreateEntity : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\domain\\" + GetTableCode(dic) + ".java", by);
        }

        public override string GetJTemplate()
        {
            return "JEntityTemplate.txt";
        }
    }
}
