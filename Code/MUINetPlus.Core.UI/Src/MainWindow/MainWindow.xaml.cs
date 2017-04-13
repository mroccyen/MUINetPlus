using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;

namespace MUINetPlus.Core.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            XmlManager.SetupPlugin();
            Uri contentSource = null;
            AppSetup.Setup(MenuLinkGroups, ref contentSource);
            ContentSource = contentSource;
        }
    }
}
