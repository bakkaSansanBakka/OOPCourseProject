using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CourseProj.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для JewelryItemView.xaml
    /// </summary>
    public partial class JewelryItemView : UserControl
    {
        public static readonly DependencyProperty ImageProperty =
           DependencyProperty.Register("ImagePath", typeof(string), typeof(JewelryItemView),
               new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly RoutedEvent ImageDownloadEvent = EventManager.RegisterRoutedEvent("ImageDownloaded", RoutingStrategy.Direct,
        typeof(RoutedEventHandler), typeof(JewelryItemView));

        public string ImagePath
        {
            get => (string)GetValue(ImageProperty);
            set
            {
                SetValue(ImageProperty, value);
                ImagePathChanged();
            }
        }

        private void ImagePathChanged()
        {
            Img.Source = new BitmapImage(new Uri(@$"{ImagePath}"));
        }

        public event RoutedEventHandler ImageDownloaded
        {
            add => AddHandler(ImageDownloadEvent, value);
            remove => RemoveHandler(ImageDownloadEvent, value);
        }

        public JewelryItemView()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(ImagePath))
                Img.Source = new BitmapImage(new Uri(@$"{ImagePath}"));
        }

        private void ImageDownloadButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory;
            if (dialog.ShowDialog() != null && (bool)dialog.ShowDialog())
            {
                ImagePath = dialog.FileName;
                Img.Source = new BitmapImage(new Uri(@$"{dialog.FileName}"));
                RaiseEvent(new RoutedEventArgs(ImageDownloadEvent, this));
            }
        }

        private void PriceValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
