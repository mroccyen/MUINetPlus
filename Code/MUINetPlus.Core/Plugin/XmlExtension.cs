using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MUINetPlus.Core
{
    public class XmlExtension
    {
        public void Setup(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() && reader.LocalName.Equals("Extension"))
                {
                    var type = ExtensionTypeManager.GetExtensionType(reader.GetAttribute("Type"));
                    var assembly = reader.GetAttribute("Assembly");
                    if (type == ExtensionType.LinkGroup)
                    {
                        ExtensionData extension = ExtensionData.GetCurrentExtensionData(type);
                        extension.Assembly = assembly;
                        XmlLinkGroup linkGroup = new XmlLinkGroup();
                        linkGroup.Setup(reader, ref extension);
                        extension.Assembly = string.Empty;
                    }
                }
            }
        }

    }
}
