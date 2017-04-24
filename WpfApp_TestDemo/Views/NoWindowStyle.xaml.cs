using System.Windows;
using System.Windows.Input;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// NoWindowStyle.xaml 的交互逻辑
    /// </summary>
    public partial class NoWindowStyle : Window
    {
        public NoWindowStyle()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
