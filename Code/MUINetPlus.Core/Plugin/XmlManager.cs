using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MUINetPlus.Core
{
    public class XmlManager
    {
        public static void SetupPlugin()
        {
            DirectoryInfo[] directories = CommonToolkit.GetPluginsDirectorys();
            foreach (var dir in directories)
            {
                string[] files = CommonToolkit.GetConfigFiles(dir.FullName);
                foreach (var file in files)
                {
                    SetupPlugin(file);
                }
            }
        }

        private static void SetupPlugin(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                XmlExtension extension = new XmlExtension();
                extension.Setup(reader);
            }
        }
    }
}
