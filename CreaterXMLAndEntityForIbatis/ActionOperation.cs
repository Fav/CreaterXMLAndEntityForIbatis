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

        public void ActionCreate(CInputInfo info)
        {
            List<Creater> lst = new List<Creater>()
            {
                new CreateEntity(),
                new CreateXML(),
                new CreateService(),
                new CreateImp(),
                new CreateDao(),
                new CreateAction(),
                new CreateBean(),
                new CreateStrucs(),
                new CreateSqlMap(),
            };
            foreach (var item in lst)
            {
                item.Run(info);
            }
        }

    }
}
