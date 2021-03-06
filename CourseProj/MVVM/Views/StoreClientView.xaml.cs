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

namespace CourseProj.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для StoreClientView.xaml
    /// </summary>
    public partial class StoreClientView : UserControl
    {
        public StoreClientView()
        {
            InitializeComponent();
        }

        private void VerticalScrollBar_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll =
                (sender as ListView).Parent as ScrollViewer;

            if (e.Delta < 0)
                scroll.LineDown();
            else
                scroll.LineUp();
        }

        private void ItemsList_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ItemsList.SelectedItem = null;
        }
    }
}
