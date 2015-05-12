using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    class CreateStrucs : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\Strucs.txt", by, true, true);
        }

        public override string GetJTemplate()
        {
            return "JStrucsTemplate.txt";
        }
    }
}
