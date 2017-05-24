using System.Windows;
using WpfApp_TestDemo.ViewModels;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// Test2.xaml 的交互逻辑
    /// </summary>
    public partial class Test2 : Window
    {
        public Test2()
        {
            InitializeComponent();
            DataContext = new Test1_ViewModel();
        }
    }
}
