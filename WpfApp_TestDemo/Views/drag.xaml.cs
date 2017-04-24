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
    /// drag.xaml 的交互逻辑
    /// </summary>
    public partial class drag : Window
    {
        Point oldPoint = new Point();
        bool isMove = false;
        public drag()
        {
            InitializeComponent();
        }

        private void canvas2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMove = false;
            canvas2.Background = Brushes.Yellow;
        }

        private void canvas2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                canvas2.Background = Brushes.White;

                FrameworkElement currEle = sender as FrameworkElement;
                double xPos = e.GetPosition(null).X - oldPoint.X + (double)currEle.GetValue(Canvas.LeftProperty);
                double yPos = e.GetPosition(null).Y - oldPoint.Y + (double)currEle.GetValue(Canvas.TopProperty);
                currEle.SetValue(Canvas.LeftProperty, xPos);
                currEle.SetValue(Canvas.TopProperty, yPos);

                oldPoint = e.GetPosition(null);
            }
        }

        private void canvas2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMove = true;
            oldPoint = e.GetPosition(null);
        }


    }
}
