using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private IList<RepairOrder> _repairOrdersList;
        private RepairOrder _selectedRepairItem;
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

        public RepairOrder SelectedRepairItem
        {
            get => _selectedRepairItem;
            set => Set(ref _selectedRepairItem, value);
        }

        public IList<JewelryOrder> JewelryOrdersList
        {
            get => _jewelryOrdersList;
            set => Set(ref _jewelryOrdersList, value);
        }

        public IList<RepairOrder> RepairOrdersList
        {
            get => _repairOrdersList;
            set => Set(ref _repairOrdersList, value);
        }

        private void LoadJewelryOrders()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                JewelryOrdersList = unitOfWork.OrderRepository.GetAll().Where(p => p.UserId == User.Id).ToList();
            }
        }

        private void LoadRepairOrders()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                RepairOrdersList = unitOfWork.RepairOrderRepository.GetAll().Where(p => p.UserId == User.Id).ToList();
            }
        }

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToConcreteJewelryOrderCommand { get; }
        public ICommand NavigateToConcreteRepairOrderCommand { get; }

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

            NavigateToConcreteJewelryOrderCommand = new NavigateCommand<ConcreteJewelryOrderClientViewModel>(navigationStore,
                () => new ConcreteJewelryOrderClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory, SelectedItem),
                (parameter) =>
                {
                    if (SelectedItem == null)
                    {
                        MessageBox.Show("Заказ не выбран", "Ошибка");
                        return false;
                    }
                    return SelectedItem != null;
                });

            NavigateToConcreteRepairOrderCommand = new NavigateCommand<ConcreteRepairOrderClientViewModel>(navigationStore,
                () => new ConcreteRepairOrderClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory, SelectedRepairItem),
                (parameter) =>
                {
                    if (SelectedRepairItem == null)
                    {
                        MessageBox.Show("Заказ не выбран", "Ошибка");
                        return false;
                    }
                    return SelectedRepairItem != null;
                });

            LoadJewelryOrders();
            LoadRepairOrders();
        }
    }
}
