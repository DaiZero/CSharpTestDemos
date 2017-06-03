

using DevExpress.Mvvm;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
namespace WpfApp_TestDemo.ViewModels
{
    class ImageControlViewModel : ViewModelBase
    {

        public ImageControlViewModel()
        {
            image1 = new BitmapImage();
            image1.BeginInit();
            image1.UriSource = new Uri(Properties.Resources.imghtttpaddress1, UriKind.RelativeOrAbsolute);
            image1.EndInit();
        }

        private DelegateCommand _ImageChange;
        public DelegateCommand ImageChange => _ImageChange ?? (_ImageChange = new DelegateCommand(Change));


        private BitmapImage image1;

        public BitmapImage Img1
        {
            get { return image1; }
            set
            {
               
                SetProperty(ref image1, value, () => Img1);
            }
        }

        private Stream _Logo;

        public Stream Logo
        {
            get { return _Logo; }
            set
            {
                SetProperty(ref _Logo, value, () => Logo);
            }
        }

        private void Change()
        {
            Console.WriteLine("Image Changed");
        }

    }

    public class ImageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Stream)
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = (Stream)value;
                bitmapImage.EndInit();
                return bitmapImage;
            }
            else
                throw new InvalidOperationException("Unexpected value in type converter");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] bt = (byte[])value;
            //MemoryStream ms = new MemoryStream(); ms.Write(bt, 0, (int)ms.Length);
            Stream stream = new MemoryStream(bt);
            return stream;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
