using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public class CreateBean : Creater
    {
        public override void OutJFile(IDictionary<string, string> dic, byte[] by)
        {
            GeneralClass.WriteToFile(savePath + "\\bean.txt", by, true, true);
        }

        public override string GetJTemplate()
        {
            return "JBeanTemplate.txt";
        }
    }
}
