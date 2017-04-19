using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// webdemo.xaml 的交互逻辑
    /// </summary>
    public partial class webdemo : Window
    {
        public webdemo()
        {
            InitializeComponent();
            frame1.Source= new Uri("http://www.baidu.com");
            WebBrowser wb = (WebBrowser)frame1.Content;
        }
    }
}
