using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Editors;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp_TestDemo.ViewModels;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// ImageControl.xaml 的交互逻辑
    /// </summary>
    public partial class ImageControl : Window
    {
        public ImageControl()
        {
            InitializeComponent();
            DataContext = new ImageControlViewModel();
        }

        private void imageEdit1_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            ImageEdit editor = (ImageEdit)sender;
            
            if (editor.Source != null && editor.Source is BitmapImage)
            {
                BitmapImage bi = (BitmapImage)editor.Source;
                Stream stream = bi.StreamSource as Stream;
                if (stream is FileStream)
                {
                    System.Windows.MessageBox.Show(((FileStream)stream).Name);
                }
                //if (stream != null)
                //    System.Windows.MessageBox.Show(stream.Name);
            }
        }

    }

    public class MyImageEdit : ImageEdit
    {
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(MyImageEdit), null);
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        protected override void LoadCore()
        {
            if (Image == null)
                return;
            ImageSource image = LoadImage();

            if (image != null)
                EditStrategy.SetImage(image);

        }

        ImageSource LoadImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = EditorLocalizer.GetString(EditorStringId.ImageEdit_OpenFileFilter);
            if (dlg.ShowDialog() == true)
            {
                using (Stream stream = dlg.OpenFile())
                {
                    if (stream is FileStream)
                        ImagePath = ((FileStream)stream).Name;
                    MemoryStream ms = new MemoryStream(stream.GetDataFromStream());
                    return ImageHelper.CreateImageFromStream(ms);
                }
            }
            return null;
        }
    }

}
