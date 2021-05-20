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
    public enum ItemOperationType
    {
        Add,
        Edit
    }

    class StoreAdminViewModel : ViewModel
    {
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private IList<JewelryItem> _jewelryItemsList;
        private IList<JewelryItem> _defaultList;

        private JewelryItem _selectedItem;

        private string _searchExpression;

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToOrdersAdminCommand { get; }
        public ICommand DelteSelectedItemCommand { get; }
        public ICommand NavigateToEditItemCommand { get; }
        public ICommand NavigateToAddItemCommand { get; }

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

        private bool DeleteSelectedItemCanExecute(object arg)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано", "Ошибка");
                return false;
            }
            return SelectedItem != null && MessageBox.Show("Вы уверены?\nЭто повлечет за собой удаление связанных с этим товаром заказов", 
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }   

        private async void DeleteSelectedItemExecute(object obj)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.JewelryItemRepository.Delete(SelectedItem.Id);
                await unitOfWork.SaveAsync();
                JewelryItemsList = unitOfWork.JewelryItemRepository.GetAll().ToList();
            }
        }

        public StoreAdminViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            DelteSelectedItemCommand = new RelayCommand(DeleteSelectedItemExecute, DeleteSelectedItemCanExecute);   

            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToOrdersAdminCommand = new NavigateCommand<OrdersAdminViewModel>(navigationStore, () => new OrdersAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToAddItemCommand = new NavigateCommand<JewelryItemViewModel>(navigationStore,
                () => new JewelryItemViewModel(navigationStore, authenticationStore, unitOfWorkFactory, ItemOperationType.Add));

            NavigateToEditItemCommand = new NavigateCommand<JewelryItemViewModel>(navigationStore,
                () => new JewelryItemViewModel(navigationStore, authenticationStore, unitOfWorkFactory, ItemOperationType.Edit, SelectedItem),
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
