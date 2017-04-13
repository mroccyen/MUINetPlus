using MUINetPlus.Core.UI;
using System;
using System.Windows;

namespace MUINetPlus.Startup
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            RegistAppEvent();
        }

        private void RegistAppEvent()
        {
            Startup += App_Start;
        }

        private void App_Start(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.MainWindow = window;
            window.Show();

            SetResource();
        }

        private void SetResource()
        {
            //设置初始化主题
            ResourceDictionary r = new ResourceDictionary();
            r.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/FirstFloor.ModernUI,Version=1.0.3.0;component/Assets/ModernUI.xaml", UriKind.RelativeOrAbsolute) });
            r.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/FirstFloor.ModernUI,Version=1.0.3.0;component/Assets/ModernUI.Light.xaml", UriKind.RelativeOrAbsolute) });
            Resources = r;
        }
    }
}
