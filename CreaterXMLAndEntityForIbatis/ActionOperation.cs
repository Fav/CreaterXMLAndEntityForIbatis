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
           // ActionCreateEntity(create, savePath, sqlPath, language);
           // ActionCreateXML(create, savePath, sqlPath, language);
            ActionCreateAction(create, savePath, sqlPath, language);
            ActionCreateDao(create, savePath, sqlPath, language);
            ActionCreateImp(create, savePath, sqlPath, language);
            ActionCreateService(create, savePath, sqlPath, language);

        }

        private void ActionCreateService(string create, string savePath, string sqlPath, string language)
        {
            CreateService c = new CreateService(create, savePath, sqlPath, language);
        }

        private void ActionCreateImp(string create, string savePath, string sqlPath, string language)
        {
            CreateImp c = new CreateImp(create, savePath, sqlPath, language);
        }

        private void ActionCreateDao(string create, string savePath, string sqlPath, string language)
        {
            CreateDao c = new CreateDao(create, savePath, sqlPath, language);
        }

        private void ActionCreateAction(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            CreateAction c = new CreateAction(create, savePath, sqlPath, language);
        }

        private void ActionCreateEntity(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            CreateEntity c = new CreateEntity(create, savePath, sqlPath, language);
        }

        private void ActionCreateXML(string create,
            string savePath,
            string sqlPath,
            string language)
        {
            CreateXML c = new CreateXML(create, savePath, sqlPath, language);
        }
    }
}
