using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    class CreateImp : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\dao\\sqlmap\\" + GeneralClass.GetActionName(dic) + "DaoImpl.java", by);
        }

        public override string GetJTemplate()
        {
            return "JDaoImplTemplate.txt";
        }
    }
}
