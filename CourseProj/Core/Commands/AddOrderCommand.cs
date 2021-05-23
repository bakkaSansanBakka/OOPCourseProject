using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels;
using CourseProj.Repositories;

namespace CourseProj.Core.Commands
{
    class AddOrderCommand : Command
    {
        private readonly OrderClientViewModel _orderClientViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private readonly AuthenticationStore _authentificationStore;
        private User _user;



        public AddOrderCommand(OrderClientViewModel orderClientViewModel, UnitOfWorkFactory unitOfWorkFactory, AuthenticationStore authenticationStore)
        {
            _orderClientViewModel = orderClientViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
            _authentificationStore = authenticationStore;
            //_user = _orderClientViewModel.User;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_orderClientViewModel.ClientFIO) && !string.IsNullOrEmpty(_orderClientViewModel.Phone) &&
                !string.IsNullOrEmpty(_orderClientViewModel.Address) && _orderClientViewModel.CardNum != 0 &&
                !string.IsNullOrEmpty(_orderClientViewModel.CardMonth) && !string.IsNullOrEmpty(_orderClientViewModel.CardYear);
        }

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _user = unitOfWork.UserRepository.GetUser(_orderClientViewModel.User.Id);
                JewelryOrder newOrder = new JewelryOrder()
                {
                    Status = OrderStatus.Accepted,
                    ClientFIO = _orderClientViewModel.ClientFIO,
                    Phone = _orderClientViewModel.Phone,
                    Address = _orderClientViewModel.Address,
                    TotalPrice = _orderClientViewModel.TotalPrice,
                    Material = _orderClientViewModel.Material,
                    Delivery = _orderClientViewModel.Delivery,
                    CardNum = _orderClientViewModel.CardNum,
                    CardMonth = _orderClientViewModel.CardMonth,
                    CardYear = _orderClientViewModel.CardYear,
                    JewelryItem = unitOfWork.JewelryItemRepository.Get(_orderClientViewModel.Item.Id),
                    User = _user
                };

                unitOfWork.OrderRepository.Create(newOrder);
                await unitOfWork.SaveAsync();
            }
            _orderClientViewModel.NavigateToOrdersClientCommand.Execute(null);
        }
    }
}
