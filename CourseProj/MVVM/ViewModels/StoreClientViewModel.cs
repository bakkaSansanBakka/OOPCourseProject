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
    class StoreClientViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<JewelryItem> _jewelryItemsList;
        private IList<JewelryItem> _defaultList;

        private JewelryItem _selectedItem;

        private string _searchExpression;

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToItemInfoCommand { get; }

        public JewelryItem SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public IList<JewelryItem> JewelryItemsList
        {
            get => _jewelryItemsList;
            set => Set(ref _jewelryItemsList, value);
        }

        public IList<JewelryItem> DefaultList
        {
            get => _defaultList;
            set => Set(ref _defaultList, value);
        }

        public string SearchExpression
        {
            get => _searchExpression;
            set
            {
                Set(ref _searchExpression, value);
                SearchExpressionChanged();
            }
        }

        private void SearchExpressionChanged()
        {
            if (SearchExpression == string.Empty)
                JewelryItemsList = DefaultList;
            else
            {
                JewelryItemsList = DefaultList.Where(p => p.JewelryName.ToLower().Contains(SearchExpression)).ToList();
            }
        }

        private void LoadGoods()
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                JewelryItemsList = DefaultList = unitOfWork.JewelryItemRepository.GetAll().ToList();
            }
        }

        public StoreClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;


            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, 
                () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, 
                () => new RepairClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, 
                () => new ContactsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, 
                () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToItemInfoCommand = new NavigateCommand<ItemInfoClientViewModel>(navigationStore, 
                () => new ItemInfoClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory, SelectedItem),
                (parameter) =>
                {
                    if (SelectedItem == null)
                    {
                        MessageBox.Show("Товар не выбран", "Ошибка");
                        return false;
                    }
                    return SelectedItem != null;
                });

            LoadGoods();
        }
    }
}
