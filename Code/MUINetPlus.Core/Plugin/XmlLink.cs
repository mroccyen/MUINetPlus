using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MUINetPlus.Core
{
    public class XmlLink
    {
        public void Setup(XmlReader reader, ref LinkGroupData linkGroup)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName.Equals("LinkGroup"))
                {
                    break;
                }
                if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() && reader.LocalName.Equals("Link"))
                {
                    LinkData link = new LinkData();
                    link.Index = Convert.ToInt32(reader.GetAttribute("Index"));
                    link.Source = reader.GetAttribute("Source");
                    link.DisplayName = reader.GetAttribute("DisplayName");
                    link.Name = reader.GetAttribute("Name");

                    linkGroup.Links.Add(link);

                    linkGroup.Links.Sort((a, b) => a.Index.CompareTo(b.Index));
                }
            }
        }
    }
}
