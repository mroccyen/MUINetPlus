using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FirstFloor.ModernUI.Windows
{
    /// <summary>
    /// Loads XAML files using Application.LoadComponent.
    /// </summary>
    public class DefaultContentLoader
        : IContentLoader
    {
        /// <summary>
        /// Asynchronously loads content from specified uri.
        /// </summary>
        /// <param name="uri">The content uri.</param>
        /// <param name="cancellationToken">The token used to cancel the load content task.</param>
        /// <returns>The loaded content.</returns>
        public Task<object> LoadContentAsync(Uri uri, CancellationToken cancellationToken)
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                throw new InvalidOperationException(Resources.UIThreadRequired);
            }

            // scheduler ensures LoadContent is executed on the current UI thread
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            return Task.Factory.StartNew(() => LoadContent(uri), cancellationToken, TaskCreationOptions.None, scheduler);
        }

        /// <summary>
        /// Loads the content from specified uri.
        /// </summary>
        /// <param name="uri">The content uri</param>
        /// <returns>The loaded content.</returns>
        protected virtual object LoadContent(Uri uri)
        {
            // don't do anything in design mode
            if (ModernUIHelper.IsInDesignMode)
            {
                return null;
            }
            //return Application.LoadComponent(uri);
            string[] strs = uri.OriginalString.Split('+');
            return ActivateObject(strs[0], strs[1]);
        }

        /// <summary>
        /// 反射实例化对象
        /// </summary>
        /// <param name="path"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static object ActivateObject(string path, string typeName)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            var obj = assembly.CreateInstance(typeName);
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj;
        }
    }
}
