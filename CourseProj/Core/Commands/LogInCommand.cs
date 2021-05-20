using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels;

namespace CourseProj.Core.Commands
{
    class LogInCommand : Command
    {
        private AuthenticationStore _authenticationStore;
        private LogInViewModel _logInViewModel;
        public LogInCommand(AuthenticationStore authenticationStore, LogInViewModel logInViewModel)
        {
            _authenticationStore = authenticationStore;
            _logInViewModel = logInViewModel;
        }
        public override bool CanExecute(object par)
        {
            return (_logInViewModel.UserName != null && _logInViewModel.Password != null);
        }

        public override async void Execute(object par)
        {
            Profile profile = await _authenticationStore.Login(_logInViewModel.UserName, _logInViewModel.Password);
            if (profile != null)
            {
                _authenticationStore.CurrentProfile = profile;
                if(profile.UserType == UserType.Admin)
                {
                    _logInViewModel.NavigateToStoreAdminCommand.Execute(null);
                }
                else if(profile.UserType == UserType.Client)
                {
                    _logInViewModel.NavigateToStoreClientCommand.Execute(null);
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка");
            }
        }
    }
}
