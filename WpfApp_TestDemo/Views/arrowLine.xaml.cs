using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

            #region 无效方法
            Vector vector2 = VisualTreeHelper.GetOffset(this.canvas2);
            Vector vector3 = VisualTreeHelper.GetOffset(this.canvas3);

            //GeneralTransform form2 = this.canvas2.TransformToVisual(canvas1);
            //Point point2 = form2.Transform(new Point());

            //GeneralTransform form3 = this.canvas3.TransformToVisual(canvas1);
            //Point point3 = form3.Transform(new Point());

            Point point13 = TranslatePoint(new Point(), canvas3);
            //Window window = Window.GetWindow(canvas1);
            //Point point = canvas1.TransformToAncestor(window).Transform(new Point(0, 0));

            //Window window22 = Window.GetWindow(canvas2);
            //Point point22 = canvas2.TransformToAncestor(window22).Transform(new Point(0, 0));
            #endregion

            //方法一
            Dictionary<string, Point> dic = new Dictionary<string, Point>();
            foreach (UIElement fe in canvas1.Children)
            {
                string name = ((Canvas)fe).Name;
                double top = (double)fe.GetValue(Canvas.TopProperty);
                double left = (double)fe.GetValue(Canvas.LeftProperty);
                dic.Add(name, new Point(top, left));
            }
            //方法二
            foreach (FrameworkElement fe in canvas1.Children)
            {
                string name = fe.Name;
                double left = Canvas.GetLeft(fe);
                double top = Canvas.GetTop(fe);
                double right = Canvas.GetRight(fe);
                double bottom = Canvas.GetBottom(fe);
                if (double.IsNaN(left))
                {
                    if (double.IsNaN(right) == false)
                        left = right - fe.ActualWidth;
                    else
                        continue;
                }
                if (double.IsNaN(top))
                {
                    if (double.IsNaN(bottom) == false)
                        top = bottom - fe.ActualHeight;
                    else
                        continue;
                }
                Rect eleRect = new Rect(left, top, fe.ActualWidth, fe.ActualHeight);
            }

            //Line line = new Line();
            //line.Stroke= Brushes.Black;
            //line.StrokeThickness = 4;
            //line.X1 = dic[nameof(canvas2)].X;
            //line.Y1 = dic[nameof(canvas2)].Y;
            //line.X2 = dic[nameof(canvas3)].X;
            //line.Y2 = dic[nameof(canvas3)].Y;
            //this.canvas1.Children.Add(line);
            Shape s= DrawArrowLink(dic[nameof(canvas2)], dic[nameof(canvas3)]);
            this.canvas1.Children.Add(s);

        }

        /// <summary>
        /// 画带箭头的直线
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static Shape DrawArrowLink(Point p1, Point p2)
        {
            //GeometryGroup=>PathGeometry=>PathFigure=>LineSegment


            //GeometryGroup（几何组合）
            GeometryGroup lineGroup = new GeometryGroup();
            double theta = Math.Atan2((p2.Y - p1.Y), (p2.X - p1.X)) * 180 / Math.PI;
            //PathGeometry（几何路径）
            PathGeometry pathGeometry = new PathGeometry();

            //PathFigure表示几何图形的一个子部分、一系列单独连接的二维几何线段
            PathFigure pathFigure = new PathFigure();

            //箭头在线上的位置
            double WzSetValue = 1;//1.35
            Point p = new Point(p1.X + ((p2.X - p1.X) / WzSetValue), p1.Y + ((p2.Y - p1.Y) / WzSetValue));// 
            pathFigure.StartPoint = p;
            
            //箭头宽和长
            Point lpoint = new Point(p.X + 6, p.Y + 15);
            Point rpoint = new Point(p.X - 6, p.Y + 15);
           
            //在 PathFigure 中的两个点之间创建一条直线。
            LineSegment seg1 = new LineSegment();
            seg1.Point = lpoint;
            pathFigure.Segments.Add(seg1);

            LineSegment seg2 = new LineSegment();
            seg2.Point = rpoint;
            pathFigure.Segments.Add(seg2);

            LineSegment seg3 = new LineSegment();
            seg3.Point = p;
            pathFigure.Segments.Add(seg3);

            pathGeometry.Figures.Add(pathFigure);

            //旋转
            RotateTransform transform = new RotateTransform();
            transform.Angle = theta + 90;
            transform.CenterX = p.X;
            transform.CenterY = p.Y;
            pathGeometry.Transform = transform;

            lineGroup.Children.Add(pathGeometry);

            // LineGeometry表示一个线性的几何图形
            // StartPoint 表示线条的开始端点的位置
            // StartPoint 表示线条的开始端点的位置
            LineGeometry connectorGeometry = new LineGeometry();
            connectorGeometry.StartPoint = p1;
            connectorGeometry.EndPoint = p2;
            lineGroup.Children.Add(connectorGeometry);

            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            path.Data = lineGroup;//　Path.Data是Path的一个属性，它表示我们要在该Path里面绘制如何形状的图形
            path.StrokeThickness = 2;
            path.Stroke = path.Fill = Brushes.Black;

            return path;
        }
    }
}
