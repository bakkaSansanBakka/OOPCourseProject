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
    /// Логика взаимодействия для RegisteryView.xaml
    /// </summary>
    public partial class RegisteryView : UserControl
    {
        public RegisteryView()
        {
            InitializeComponent();
        }

        private void PasswordTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PasswordTextBox.Password != null)
                {
                    if (PasswordTextBox.Password.Length < 5)
                    {
                        MessageBox.Show("Слишком короткий пароль", "Предупреждение");
                        PasswordTextBox.Password = "";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void MailTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(MailTextBox.Text))
            {
                MessageBox.Show("Неверный формат электронной почты", "Предупреждение");
                MailTextBox.Text = "";
            }
            //return regex.IsMatch(s);
        }
    }
}
