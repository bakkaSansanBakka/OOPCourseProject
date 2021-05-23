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
    class ConcreteRepairOrderClientViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _clientFIO;
        private string _image;
        private string _description;
        private OrderStatus _status;
        private RepairOrder _order;

        public ICommand NavigateBackCommand { get; }

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

        public OrderStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public ConcreteRepairOrderClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            RepairOrder order)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            _order = order;
            ClientFIO = _order.ClientFIO;
            Image = _order.Image;
            Description = _order.Description;
            Status = _order.Status;

            NavigateBackCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore,
                () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }
    }
}
