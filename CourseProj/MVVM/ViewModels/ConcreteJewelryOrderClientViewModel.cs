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
    class ConcreteJewelryOrderClientViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _name;
        private JewelryItemMaterial _material;
        private DeliveryType _delivery;
        private string _clientFIO;
        private string _phone;
        private string _address;
        private float _price;
        private OrderStatus _status;
        private JewelryOrder _order;

        public ICommand NavigateBackCommand { get; }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public JewelryItemMaterial Material
        {
            get => _material;
            set => Set(ref _material, value);
        }

        public DeliveryType Delivery
        {
            get => _delivery;
            set => Set(ref _delivery, value);
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

        public float Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public OrderStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ConcreteJewelryOrderClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            JewelryOrder order)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            _order = order;
            Name = _order.JewelryItem.JewelryName;
            Material = _order.Material;
            Delivery = _order.Delivery;
            ClientFIO = _order.ClientFIO;
            Phone = _order.Phone;
            Address = _order.Address;
            Price = _order.TotalPrice;
            Status = _order.Status;

            NavigateBackCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore,
                () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }
    }
}
