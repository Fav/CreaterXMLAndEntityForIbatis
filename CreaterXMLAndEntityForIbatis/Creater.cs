using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    public abstract class Creater
    {
        public abstract void Run(string create,
             string savePath,
             string sqlPath,
             string language);
    }
}
