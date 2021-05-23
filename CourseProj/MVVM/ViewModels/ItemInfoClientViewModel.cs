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
    class ItemInfoClientViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _name;
        private string _description;
        private string _image;
        private float _price;
        public JewelryItem _item;

        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToOrderClientCommand { get; }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public float Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public ItemInfoClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            JewelryItem item)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            _item = item;
            Name = _item.JewelryName;
            Price = _item.Price;
            Description = _item.Description;
            Image = _item.Image;

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

            NavigateToOrderClientCommand = new NavigateCommand<OrderClientViewModel>(navigationStore,
                () => new OrderClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory, _item));
        }
    }
}
