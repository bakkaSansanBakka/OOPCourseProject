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
    class OrderClientViewModel : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthenticationStore _authenticationStore;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _clientFIO;
        private string _phone;
        private string _address;
        private long _cardNum;
        private string _cardMonth;
        private string _cardYear;
        private float _totalPrice;
        private JewelryItem _item;
        private JewelryItemMaterial _material;
        private float _materialPrice;
        private DeliveryType _delivery;
        private float _deliveryPrice;
        private User _user;

        //public EnumViewModel<OrderStatus> StatusViewModel { get; }
        public EnumViewModel<JewelryItemMaterial> MaterialViewModel { get; }
        public EnumViewModel<DeliveryType> DeliveryViewModel { get; }


        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToItemInfoClientCommand { get; }
        public ICommand AddOrderCommand { get; }

        public AuthenticationStore AuthenticationStore => _authenticationStore;

        public DeliveryType Delivery
        {
            get => _delivery;
            set => Set(ref _delivery, value);
        }

        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public JewelryItemMaterial Material
        {
            get => _material;
            set => Set(ref _material, value);
        }

        public float MaterialPrice
        {
            get => _materialPrice;
            set => Set(ref _materialPrice, value);
        }

        public float DeliveryPrice
        {
            get => _deliveryPrice;
            set => Set(ref _deliveryPrice, value);
        }

        public string ClientFIO
        {
            get => _clientFIO;
            set => Set(ref _clientFIO, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        public long CardNum
        {
            get => _cardNum;
            set => Set(ref _cardNum, value);
        }

        public string CardMonth
        {
            get => _cardMonth;
            set => Set(ref _cardMonth, value);
        }

        public string CardYear
        {
            get => _cardYear;
            set => Set(ref _cardYear, value);
        }

        public float TotalPrice
        {
            get => _totalPrice;
            set => Set(ref _totalPrice, value);
        }

        public JewelryItem Item
        {
            get => _item;
            set => Set(ref _item, value);
        }

        public OrderClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            JewelryItem item, string clientFIO = "", string phone = "", string address = "", long cardNum = 0, string cardMonth = "01", 
            string cardYear = "2021")
        {
            _navigationStore = navigationStore;
            _authenticationStore = authenticationStore;
            _unitOfWorkFactory = unitOfWorkFactory;

            _item = item;
            ClientFIO = clientFIO;
            Phone = phone;
            Address = address;
            CardNum = cardNum;
            CardMonth = cardMonth;
            CardYear = cardYear;
            TotalPrice = _item.Price;
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User = unitOfWork.UserRepository.GetUserByName(_authenticationStore.CurrentProfile.UserName);
            }

            MaterialViewModel = new EnumViewModel<JewelryItemMaterial>();
            MaterialViewModel.SelectedItem = JewelryItemMaterial.Silver;
            _material = MaterialViewModel.SelectedItem;
            MaterialPrice = 1;
            MaterialViewModel.OnSelectionChanged += MaterialViewModelOnSelectionChanged;

            DeliveryViewModel = new EnumViewModel<DeliveryType>();
            DeliveryViewModel.SelectedItem = DeliveryType.Pickup;
            _delivery = DeliveryViewModel.SelectedItem;
            DeliveryViewModel.OnSelectionChanged += DeliveryViewModelOnSelectionChanged;

            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, 
                () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, 
                () => new ContactsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, 
                () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, 
                () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, 
                () => new RepairClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            NavigateToItemInfoClientCommand = new NavigateCommand<ItemInfoClientViewModel>(navigationStore,
            () => new ItemInfoClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory, _item));

            AddOrderCommand = new AddOrderCommand(this, _unitOfWorkFactory, _authenticationStore);
        }

        private void MaterialViewModelOnSelectionChanged()
        {
            Material = MaterialViewModel.SelectedItem;
            if (Material == JewelryItemMaterial.Gold)
            {
                MaterialPrice = 1.86f;
            }
            else
                MaterialPrice = 1;

            TotalPrice = _item.Price * MaterialPrice + DeliveryPrice;
        }

        private void DeliveryViewModelOnSelectionChanged()
        {
            Delivery = DeliveryViewModel.SelectedItem;
            if (Delivery == DeliveryType.Mail)
            {
                DeliveryPrice = 15;
            }
            else
                DeliveryPrice = 0;

            TotalPrice = _item.Price * MaterialPrice + DeliveryPrice;
        }
    }
}
