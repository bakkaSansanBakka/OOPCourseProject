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
    class OrdersAdminViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<JewelryOrder> _jewelryOrdersList;
        private JewelryOrder _selectedItem;
        private IList<RepairOrder> _repairOrdersList;
        private RepairOrder _selectedRepairItem;

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToStoreAdminCommand { get; }
        public ICommand NavigateToConcreteJewelryOrderCommand { get; }
        public ICommand NavigateToConcreteRepairOrderCommand { get; }

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
                JewelryOrdersList = unitOfWork.OrderRepository.GetAll().ToList();
            }
        }

        private void LoadRepairOrders()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                RepairOrdersList = unitOfWork.RepairOrderRepository.GetAll().ToList();
            }
        }

        public OrdersAdminViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, 
                () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToStoreAdminCommand = new NavigateCommand<StoreAdminViewModel>(navigationStore, 
                () => new StoreAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToConcreteJewelryOrderCommand = new NavigateCommand<ConcreteJewelryOrderAdminViewModel>(navigationStore,
                () => new ConcreteJewelryOrderAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory, SelectedItem),
                (parameter) =>
                {
                    if (SelectedItem == null)
                    {
                        MessageBox.Show("Заказ не выбран", "Ошибка");
                        return false;
                    }
                    return SelectedItem != null;
                });

            NavigateToConcreteRepairOrderCommand = new NavigateCommand<ConcreteRepairOrderAdminViewModel>(navigationStore,
                () => new ConcreteRepairOrderAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory, SelectedRepairItem),
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
