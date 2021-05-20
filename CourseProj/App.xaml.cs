using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CourseProj.Context;
using CourseProj.Core;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels;
using CourseProj.Repositories;

namespace CourseProj
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (MessageBox.Show((args.ExceptionObject as Exception).Message) == MessageBoxResult.OK)
                    App.Current.Shutdown();
            };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            UnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            AuthenticationStore authenticationStore = new AuthenticationStore(new AuthenticationService(unitOfWorkFactory));
            NavigationStore navigationStore = new NavigationStore();

            using (var context = new MyContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                authenticationStore.Register("admin", "admin", "admin", "jewelryStore@mail.ru", UserType.Admin);

                context.SaveChanges();
            }

            navigationStore.CurrentViewModel = new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory);
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
