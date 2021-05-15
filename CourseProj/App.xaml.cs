using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CourseProj.Core;
using CourseProj.MVVM.ViewModels;

namespace CourseProj
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new LogInViewModel(navigationStore);

            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
