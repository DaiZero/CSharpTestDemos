using DZero.Prism.TestDemo.Infrastructure.Client;
using DZero.Prism.TestDemo.Infrastructure.Client.Constants;
using DZero.Prism.TestDemo.Infrastructure.Client.Logs;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace DZero.Prism.TestDemo.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// 创建Shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            //从容器中解析Shell
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// 初始化Shell
        /// </summary>
        protected override void InitializeShell()
        {
            GlobalApplication.CurrentApplication = App.Current;

            base.RegisterTypeIfMissing(typeof(IPageType), typeof(PageType), true);

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Height = WindowSizeConstant.LoginViewHeight;
            App.Current.MainWindow.Width = WindowSizeConstant.LoginViewWidth;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// 创建模块目录
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        /// <summary>
        ///创建日志记录器
        /// </summary>
        /// <returns></returns>
        protected override ILoggerFacade CreateLogger()
        {
            return new LoggerFacade();
        }
    }
}
