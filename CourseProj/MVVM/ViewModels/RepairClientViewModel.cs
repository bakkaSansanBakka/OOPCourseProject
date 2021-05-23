using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.Core.Commands;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    class RepairClientViewModel : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _clientFIO;
        private string _image;
        private string _description;
        private User _user;

        public AuthenticationStore AuthenticationStore => _authenticationStore;

        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public string ClientFIO
        {
            get => _clientFIO;
            set => Set(ref _clientFIO, value);
        }

        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand AddRepairOrderCommand { get; }

        public RepairClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            string clientFIO = "", string image = @"E:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images/placeholder.png",
            string description = "")
        {
            _navigationStore = navigationStore;
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            ClientFIO = clientFIO;
            Image = image;
            Description = description;
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User = unitOfWork.UserRepository.GetUserByName(_authenticationStore.CurrentProfile.UserName);
            }

            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, 
                () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, 
                () => new ContactsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, 
                () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, 
                () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            AddRepairOrderCommand = new AddRepairOrderCommand(this, _unitOfWorkFactory, _authenticationStore);

        }
    }
}
