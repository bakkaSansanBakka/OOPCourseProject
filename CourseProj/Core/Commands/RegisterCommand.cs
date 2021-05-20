using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels;

namespace CourseProj.Core.Commands
{
    public class RegisterCommand : Command
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly RegisteryViewModel _registeryViewModel;
        //private readonly ICommand _navigateToUsers;

        public RegisterCommand(AuthenticationStore authenticationStore, RegisteryViewModel registeryViewModel/*, ICommand navigateToUsers*/)
        {
            _authenticationStore = authenticationStore;
            _registeryViewModel = registeryViewModel;
            //_navigateToUsers = navigateToUsers;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_registeryViewModel.UserName)
                   && !string.IsNullOrEmpty(_registeryViewModel.Password)
                   && !string.IsNullOrEmpty(_registeryViewModel.Email)
                   && !string.IsNullOrEmpty(_registeryViewModel.ConfirmPassword);
        }

        public override async void Execute(object parameter)
        {
            RegistrationResult result = await _authenticationStore.Register(_registeryViewModel.UserName, _registeryViewModel.Password, _registeryViewModel.ConfirmPassword,
                  _registeryViewModel.Email, UserType.Client);
            if (result == RegistrationResult.Success)
                _registeryViewModel.NavigateBackCommand.Execute(null);
            else
            {
                MessageBox.Show($"{result.GetDisplayName()}", "Ошибка");
            }
        }
    }
}
