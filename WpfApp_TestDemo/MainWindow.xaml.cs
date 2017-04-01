using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp_TestDemo.Views;

namespace WpfApp_TestDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Activated += WindowThd_Activated;

            this.Closing += WindowThd_Closing;

            this.ContentRendered += WindowThd_ContentRendered;

            this.Deactivated += WindowThd_Deactivated;

            this.Loaded += WindowThd_Loaded;

            this.Closed += WindowThd_Closed;

            this.Unloaded += WindowThd_Unloaded;

            this.SourceInitialized += WindowThd_SourceInitialized;

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DisplayCanvas();
        }

        private void btnThd_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ModifyUI);

            thread.Start();

        }

        private void btnAppBeginInvoke_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>

            {

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        this.lblHello.Content = "欢迎你光临WPF的世界,Dispatche 异步方法！！" + DateTime.Now.ToString();
                    }));

            }).Start();
        }

        private void ModifyUI()

        {
            // 模拟一些工作正在进行
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //方式一：（会报错）System.InvalidOperationException："调用线程无法访问此对象，因为另一个线程拥有该对象。"
            //lblHello.Content = "欢迎你光临WPF的世界,Dispatcher";
            //方式二：Dispatcher的作用是用于管理线程工作项队列； Invoke 是同步操作，而 BeginInvoke 是异步操作
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                lblHello.Content = "欢迎你光临WPF的世界,Dispatche  同步方法 ！！";

            });
        }

        public void DisplayCanvas()

        {

            Canvas canv = new Canvas();

            //把canv添加为窗体的子控件

            this.Content = canv;

            canv.Margin = new Thickness(0, 0, 0, 0);

            canv.Background = new SolidColorBrush(Colors.White);



            //Rectangle

            Rectangle r = new Rectangle();

            r.Fill = new SolidColorBrush(Colors.Red);

            r.Stroke = new SolidColorBrush(Colors.Red);

            r.Width = 200;

            r.Height = 140;

            r.SetValue(Canvas.LeftProperty, (double)200);

            r.SetValue(Canvas.TopProperty, (double)120);

            canv.Children.Add(r);

            //Ellipse

            Ellipse el = new Ellipse();

            el.Fill = new SolidColorBrush(Colors.Blue);

            el.Stroke = new SolidColorBrush(Colors.Blue);

            el.Width = 240;

            el.Height = 80;

            el.SetValue(Canvas.ZIndexProperty, 1);

            el.SetValue(Canvas.LeftProperty, (double)100);

            el.SetValue(Canvas.TopProperty, (double)80);

            canv.Children.Add(el);



        }

        private void btnAddByCode_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel wp = new WrapPanel();
            //把wp添加为窗体的子控件
            this.Content = wp;
            wp.Margin = new Thickness(0, 0, 0, 0);
            wp.Background = new SolidColorBrush(Colors.White);
            //遍历增加TextBlock
            TextBlock block;
            for (int i = 0; i <= 10; i++)
            {
                block = new TextBlock();
                block.Text = "后台代码添加控件：" + i.ToString();
                block.Margin = new Thickness(10, 10, 10, 10);
                block.Width = 160;
                block.Height = 30;
                wp.Children.Add(block);
            }
        }

        private void StackPanels()
        {
            StackPanel sp = new StackPanel();
            //把sp添加为窗体的子控件
            this.Content = sp;
            sp.Margin = new Thickness(0, 0, 0, 0);
            sp.Background = new SolidColorBrush(Colors.White);
            sp.Orientation = Orientation.Vertical;
            //Button1
            Button b1 = new Button();
            b1.Content = "后台代码，第一个";
            sp.Children.Add(b1);
            //Button2
            Button b2 = new Button();
            b2.Content = "后台代码，第二个";
            sp.Children.Add(b2);
            //Button3
            Button b3 = new Button();
            b3.Content = "后台代码，第三个,修改按钮排列方式";
            b3.Click += (sender, e) =>
            {
                if (sp.Orientation == Orientation.Vertical)
                {
                    sp.Orientation = Orientation.Horizontal;
                }
                else
                {
                    sp.Orientation = Orientation.Vertical;
                }
            };
            sp.Children.Add(b3);
        }

        void WindowThd_SourceInitialized(object sender, EventArgs e)

        {

            Console.WriteLine("1---SourceInitialized！");

        }



        void WindowThd_Unloaded(object sender, RoutedEventArgs e)

        {
            Console.WriteLine("Unloaded！");
            //Console.WriteLine("");

        }



        void WindowThd_Closed(object sender, EventArgs e)

        {

            Console.WriteLine("_Closed！");

        }



        void WindowThd_Loaded(object sender, RoutedEventArgs e)

        {

            Console.WriteLine("3---Loaded！");

        }



        void WindowThd_Deactivated(object sender, EventArgs e)

        {

            Console.WriteLine("Deactivated！");

        }



        void WindowThd_ContentRendered(object sender, EventArgs e)

        {

            Console.WriteLine("ContentRendered！");

        }



        void WindowThd_Closing(object sender, System.ComponentModel.CancelEventArgs e)

        {
            Console.WriteLine("---Closing！");
        }



        void WindowThd_Activated(object sender, EventArgs e)

        {

            Console.WriteLine("2---Activated！");

        }

        private void btnAddbtnByCode_Click(object sender, RoutedEventArgs e)
        {
            StackPanels();
        }


        private void btnPage1_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Page1.xaml", UriKind.Relative));

            // NavigationService.GetNavigationService(this).GoForward();//向后转

            //NavigationService.GetNavigationService(this).GoBack();　 //向前转

            //方法3：另打开
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("Page1.xaml", UriKind.Relative);
            //window.Show();

            //方法3：页面替换
            this.Content = new Page1();

        }

        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            Test1 ts1 = new Test1();
            ts1.Show();
        }

        private void Test2_Click(object sender, RoutedEventArgs e)
        {
            Test2 ts = new Test2();
            ts.Show();
        }
    }
}
