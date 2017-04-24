using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// MovingButton.xaml 的交互逻辑
    /// </summary>
    public partial class MovingButton : Window
    {
        public MovingButton()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daX = new DoubleAnimation();
            DoubleAnimation daY = new DoubleAnimation();
            ////指定起点
            //daX.From = 1D;
            //daY.From = 1D;

            //指定起点
            Random r = new Random();
            daX.To = r.NextDouble() * 300;
            daY.To = r.NextDouble() * 300;

            //指定时长
            Duration dura = new Duration(TimeSpan.FromMilliseconds(300));
            daX.Duration = dura;
            daY.Duration = dura;

            //动画的主体是TranslateTransform变型，而非button
            this.tt.BeginAnimation(TranslateTransform.XProperty, daX);
            this.tt.BeginAnimation(TranslateTransform.YProperty, daY);
            Thread.Sleep(100);
        }
    }
}
