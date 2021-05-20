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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProj.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PasswordTextBox.xaml
    /// </summary>
    public partial class PasswordTextBox : UserControl
    {
        public static readonly RoutedEvent PasswordChangedEvent =
            EventManager.RegisterRoutedEvent("PasswordChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WatermarkTextBox));

        public string StoredPassword
        {
            get { return (string)GetValue(StoredPasswordProperty); }
            set { SetValue(StoredPasswordProperty, value); }
        }

        public static readonly DependencyProperty StoredPasswordProperty =
            DependencyProperty.Register("StoredPassword", typeof(string), typeof(PasswordTextBox), new PropertyMetadata(""));



        public static readonly RoutedEvent WatermarkChangedEvent =
            EventManager.RegisterRoutedEvent("WatermarkChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WatermarkTextBox));

        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("WatermarkProperty", typeof(string), typeof(PasswordTextBox), new PropertyMetadata(""));


        public PasswordTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StoredPassword = WMTextBox.Text;
            RaiseEvent(new RoutedEventArgs(PasswordChangedEvent, this));
            if (WMTextBox.Text == "")
                WatermarkTextBlock.Text = Watermark;
            else
                WatermarkTextBlock.Text = new string('●', WMTextBox.Text.Length);
        }

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(PasswordChangedEvent, value); }
            remove { RemoveHandler(PasswordChangedEvent, value); }
        }

        private void PasswordTextBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            WatermarkTextBlock.Text = Watermark;
            RaiseEvent(new RoutedEventArgs(WatermarkChangedEvent, this));
        }
    }
}
