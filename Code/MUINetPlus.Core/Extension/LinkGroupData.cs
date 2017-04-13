using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core
{
    public class LinkGroupData : ExtensionChildData
    {
        public string Assembly
        {
            get; set;
        }

        public string DisplayName
        {
            get; set;
        }

        public string DefaultContentSourceName
        {
            get; set;
        }

        public string IsTitleLink
        {
            get; set;
        }

        private List<LinkData> _links = new List<LinkData>();
        public List<LinkData> Links
        {
            get { return _links; }
        }
    }
}
