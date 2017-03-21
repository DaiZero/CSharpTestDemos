using System.Windows;
using System.Text;
using System.Windows.Controls;

namespace WpfApp_TestDemo
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string senderName = sender.GetType().FullName;
            string strOSName = e.OriginalSource.GetType().FullName;
            Button btn =(Button)e.OriginalSource;
            string strBtnName = btn.Name;
            string strBtnContent = btn.Content.ToString();
            string strSourceName = e.Source.GetType().FullName;
            StringBuilder strmsg = new StringBuilder();
            strmsg.AppendFormat("senderTypeName:【{0}】 \n", senderName);
            strmsg.AppendFormat("SourceTypeName:【{0}】 \n", strSourceName);
            strmsg.AppendFormat("OriginalSourceTypeName:【{0}】 \n", strOSName);
            strmsg.AppendFormat("ButtonName:【{0}】 \n", strBtnName);
            strmsg.AppendFormat("ButtonContent:【{0}】 \n", strBtnContent);
            
            MessageBox.Show(strmsg.ToString());
        }
    }
}
