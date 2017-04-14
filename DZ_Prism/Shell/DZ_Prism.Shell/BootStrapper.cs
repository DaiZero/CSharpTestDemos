using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Logging;
using Prism.Unity;

namespace DZ_Prism.Shell
{
  public  class BootStrapper:UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            // return base.CreateShell();
            return this.Container.TryResolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            if (true)
            {
                App.Current.MainWindow = (Window)Shell;
                App.Current.MainWindow.Show();
            }
            else
            {
                Environment.Exit(0);
            }

        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }
    }
}
