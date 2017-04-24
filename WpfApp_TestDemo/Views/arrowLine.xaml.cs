using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// arrowLine.xaml 的交互逻辑
    /// </summary>
    public partial class arrowLine : Window
    {
        public arrowLine()
        {
            InitializeComponent();
            DrawingLine();
        }

        public void DrawingLine()
        {
            Vector vector2 = VisualTreeHelper.GetOffset(this.canvas2);
            Vector vector3 = VisualTreeHelper.GetOffset(this.canvas3);

            GeneralTransform form2 = this.canvas2.TransformToVisual(canvas1);
            Point point2 = form2.Transform(new Point());

            GeneralTransform form3 = this.canvas3.TransformToVisual(canvas1);
            Point point3 = form3.Transform(new Point());

            //Window window = Window.GetWindow(canvas1);
            //Point point = canvas1.TransformToAncestor(window).Transform(new Point(0, 0));

            //Window window22 = Window.GetWindow(canvas2);
            //Point point22 = canvas2.TransformToAncestor(window22).Transform(new Point(0, 0));

            Line line = new Line();
            line.Stroke= Brushes.White;
            line.X1 = vector2.X;
            line.Y1 = vector2.Y;
            line.X2 = 100;
            line.Y2 = 100;
            this.canvas1.Children.Add(line);        }
    }
}
