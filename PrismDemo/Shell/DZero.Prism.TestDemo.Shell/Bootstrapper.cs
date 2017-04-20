using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Unity;
using Microsoft.Practices.Unity;
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
            Application.Current.MainWindow.Show();
        }
    }
}
