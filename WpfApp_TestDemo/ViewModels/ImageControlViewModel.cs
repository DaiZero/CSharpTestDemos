

using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using WpfApp_TestDemo.Command;

namespace WpfApp_TestDemo.ViewModels
{
    class ImageControlViewModel : NotificationObject
    {
        public DelegateCommand ImageChange { get; set; }

        public ImageControlViewModel()
        {
            image1 = new BitmapImage();
            image1.BeginInit();
            image1.UriSource = new Uri(Properties.Resources.imghtttpaddress1, UriKind.RelativeOrAbsolute);
            image1.EndInit();
        }


        private BitmapImage image1;

        public BitmapImage Img1
        {
            get { return image1; }
            set
            {
                image1 = value;
                this.RaisePropertyChange("Img1");
            }
        }

    }
}
