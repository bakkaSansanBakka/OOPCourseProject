using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    class OrdersClientViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<JewelryOrder> _jewelryOrdersList;
        private JewelryOrder _selectedItem;
        private User _user;

        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public JewelryOrder SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<JewelryOrder> JewelryOrdersList
        {
            get => _jewelryOrdersList;
            set => Set(ref _jewelryOrdersList, value);
        }

        private void LoadJewelryOrders()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                //JewelryItemsList = unitOfWork.OrderRepository.GetAll().Where(p => p.UserId == (unitOfWork.UserRepository.GetUser(User.Id)).Id).ToList();
                JewelryOrdersList = unitOfWork.OrderRepository.GetAll().Where(p => p.UserId == User.Id).ToList();
            }
        }

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }

        public OrdersClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User = unitOfWork.UserRepository.GetUserByName(_authenticationStore.CurrentProfile.UserName);
            }

                NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, 
                () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, 
                () => new ContactsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, 
                () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, 
                () => new RepairClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            LoadJewelryOrders();
        }
    }
}
