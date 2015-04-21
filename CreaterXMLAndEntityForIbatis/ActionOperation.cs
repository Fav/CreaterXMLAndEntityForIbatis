using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterXMLAndEntityForIbatis
{
    /// <summary>
    /// 组装类
    /// </summary>
    public class ActionOperation
    {
        private static ActionOperation _instance = null;
        private static readonly object obj = new object();
        public static ActionOperation Instance
        {
            get
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new ActionOperation();
                    }
                    return _instance;
                }
            }
        }

        public void ActionCreate(string create, 
            string savePath, 
            string sqlPath, 
            string language)
        {
            ActionCreateEntity(create, savePath, sqlPath, language);
            ActionCreateXML(create, savePath, sqlPath, language);
        }

        private void ActionCreateEntity(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            ICreater creater = new CreateEntity(create, savePath, sqlPath, language);
        }

        private void ActionCreateXML(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            ICreater creater = new CreateXML(create, savePath, sqlPath, language);
        }
    }
}
