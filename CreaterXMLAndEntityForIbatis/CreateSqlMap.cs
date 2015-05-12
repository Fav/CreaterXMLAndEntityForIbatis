using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    class CreateSqlMap : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\SqlMap.txt", by, true, true);
        }

        public override string GetJTemplate()
        {
            return "JSqlMapTemplate.txt";
        }
    }
}
