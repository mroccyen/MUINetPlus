using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core
{
    public class ExtensionData
    {
        public ExtensionType Type
        {
            get; set;
        }

        public string Assembly
        {
            get; set;
        }

        private List<ExtensionChildData> _extensionNodes = new List<ExtensionChildData>();
        public List<ExtensionChildData> ExtensionNodes
        {
            get { return _extensionNodes; }
        }

        public static ExtensionData GetCurrentExtensionData(ExtensionType type)
        {
            ExtensionData extension = null;
            foreach (var e in PluginGruop.Singleton.ExtensionDatas)
            {
                if (e.Type == type)
                    extension = e;
            }
            return extension;
        }
    }
}
