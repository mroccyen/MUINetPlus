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

        public static void Setup(LinkGroupCollection menuLinkGroups, ref Uri contentSource)
        {
            foreach (var extensionData in PluginGruop.Singleton.ExtensionDatas)
            {
                foreach (var extensionNode in extensionData.ExtensionNodes)
                {
                    if (extensionData.Type == ExtensionType.LinkGroup)
                    {
                        var linkGroupData = extensionNode as LinkGroupData;
                        var settingsLinkGroup = new LinkGroup { DisplayName = linkGroupData.DisplayName, GroupKey = "", };
                        foreach (var link in linkGroupData.Links)
                        {
                            var assemblyPath = AssemblyToolkit.GetDll(linkGroupData.Assembly);
                            var settingsLink = new Link { DisplayName = link.DisplayName, Source = new Uri(assemblyPath + "+" + link.Source, UriKind.RelativeOrAbsolute) };
                            settingsLinkGroup.Links.Add(settingsLink);
                            if (flag++ == 0)
                                contentSource = new Uri(assemblyPath + "+" + link.Source, UriKind.RelativeOrAbsolute);
                        }
                        menuLinkGroups.Add(settingsLinkGroup);
                    }
                }
            }
        }
    }
}
