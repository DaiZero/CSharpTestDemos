using System.Windows;
using WpfApp_TestDemo.ViewModels;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// Test1.xaml 的交互逻辑
    /// </summary>
    public partial class Test1 : Window
    {
        public Test1()
        {
            InitializeComponent();
            DataContext = new Test1_ViewModel();
        }
    }
}
