using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core
{
    public class PluginGruop
    {
        private static PluginGruop _singleton;
        public static PluginGruop Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new PluginGruop();
                    _singleton.ExtensionDatas.Add(new ExtensionData { Type = ExtensionType.LinkGroup });
                    _singleton.ExtensionDatas.Add(new ExtensionData { Type = ExtensionType.LinkPage });
                }
                return _singleton;
            }
        }

        private List<ExtensionData> _extensionDatas = new List<ExtensionData>();
        public List<ExtensionData> ExtensionDatas
        {
            get { return _extensionDatas; }
        }


    }
}
