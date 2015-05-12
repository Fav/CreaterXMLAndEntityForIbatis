using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class CreateDao : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\dao\\" + GeneralClass.GetActionName(dic) + "Dao.java", by);
        }

        public override string GetJTemplate()
        {
            return "JDaoTemplate.txt";
        }
    }
}
