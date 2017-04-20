using DZero.Prism.TestDemo.Infrastructure.Client;
using DZero.Prism.TestDemo.Infrastructure.Client.Constants;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;

namespace DZero.Prism.TestDemo.Shell
{
    public  class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            //Application.Current.MainWindow.Show();
            GlobalApplication.CurrentApplication = App.Current;

            base.RegisterTypeIfMissing(typeof(IPageType), typeof(PageType), true);

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Height = WindowSizeConstant.LoginViewHeight;
            App.Current.MainWindow.Width = WindowSizeConstant.LoginViewWidth;
            App.Current.MainWindow.Show();
        }
    }
}
