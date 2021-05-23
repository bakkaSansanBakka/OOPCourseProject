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

namespace CourseProj.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderClientView.xaml
    /// </summary>
    public partial class OrderClientView : UserControl
    {
        public OrderClientView()
        {
            InitializeComponent();
        }

        private void CardNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{0,16}$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }

        private void CardMonthValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[0-1]?[1-9]?");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }

        private void CardYearValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d\d\d\d$");
            e.Handled = !regex.IsMatch(((TextBox)sender).Text + e.Text);
        }
    }
}
