using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core
{
    public enum ExtensionType
    {
        LinkPage,
        LinkGroup
    }

    public class ExtensionTypeManager
    {
        public static ExtensionType GetExtensionType(string typeString)
        {
            ExtensionType type = ExtensionType.LinkGroup;
            if (typeString.Equals("LinkGroup"))
                type = ExtensionType.LinkGroup;
            else if (typeString.Equals("LinkPage"))
                type = ExtensionType.LinkPage;
            return type;
        }
    }
}
