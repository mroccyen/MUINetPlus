using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core
{
    public class ExtensionCheck
    {
        public static T LinkGroupExistValue<T>(ExtensionData extensionData, string checkName) where T : ExtensionChildData
        {
            T result = null; ;
            var existNodes = extensionData.ExtensionNodes.Where(node => node.Name.Equals(checkName));
            if (existNodes.Count() > 0)
            {
                foreach (var data in existNodes)
                {
                    result = data as T;
                    break;
                }
            }
            return result;
        }
    }
}
