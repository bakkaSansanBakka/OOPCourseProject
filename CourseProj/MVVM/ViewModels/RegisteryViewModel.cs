using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.Core.Commands;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    public class RegisteryViewModel : ViewModel
    {
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand RegisterUserCommand { get; }

        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _userName;
        private string _email;
        private string _password;
        private string _confirmPassword;

        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => Set(ref _confirmPassword, value);
        }

        public RegisteryViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateBackCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            RegisterUserCommand = new RegisterCommand(authenticationStore, this);
        }
    }
}
