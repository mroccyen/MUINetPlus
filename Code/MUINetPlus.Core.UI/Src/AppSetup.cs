using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUINetPlus.Core.UI
{
    public class AppSetup
    {
        private static int flag = 0;

        public static void Setup(LinkGroupCollection menuLinkGroups, LinkCollection titleLinks, ref Uri contentSource)
        {
            foreach (var extensionData in PluginGruop.Singleton.ExtensionDatas)
            {
                foreach (var extensionNode in extensionData.ExtensionNodes)
                {
                    if (extensionData.Type == ExtensionType.LinkGroup)
                    {
                        var linkGroupData = extensionNode as LinkGroupData;
                        SetupLinkGroup(menuLinkGroups, titleLinks, linkGroupData,ref contentSource);
                    }
                }
            }
        }

        private static void SetupLinkGroup(LinkGroupCollection menuLinkGroups, LinkCollection titleLinks, LinkGroupData linkGroupData, ref Uri contentSource)
        {
            Uri firstUri = null;
            var linkGroup = new LinkGroup { DisplayName = linkGroupData.DisplayName, GroupKey = linkGroupData.GroupKey };
            foreach (var link in linkGroupData.Links)
            {
                var assemblyPath = AssemblyToolkit.GetDll(linkGroupData.Assembly);
                var settingsLink = new Link { DisplayName = link.DisplayName, Source = new Uri(assemblyPath + "+" + link.Source, UriKind.RelativeOrAbsolute) };
                linkGroup.Links.Add(settingsLink);
                firstUri = new Uri(assemblyPath + "+" + link.Source, UriKind.RelativeOrAbsolute);
                if (flag++ == 0)
                    contentSource = new Uri(assemblyPath + "+" + link.Source, UriKind.RelativeOrAbsolute);
            }
            if (linkGroupData.IsTitleLink)
            {
                titleLinks.Add(new Link { DisplayName = linkGroupData.DisplayName, Source = firstUri });
            }
            menuLinkGroups.Add(linkGroup);
        }
    }
}
