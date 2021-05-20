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
    class LogInViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private string _userName;
        private string _password;

        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand NavigateToRegisteryCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToStoreAdminCommand { get; }
        public ICommand LoginCommand { get; }


        public LogInViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToRegisteryCommand = new NavigateCommand<RegisteryViewModel>(navigationStore, () => new RegisteryViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToStoreAdminCommand = new NavigateCommand<StoreAdminViewModel>(navigationStore, () => new StoreAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            LoginCommand = new LogInCommand(_authenticationStore, this);
        }
    }
}
