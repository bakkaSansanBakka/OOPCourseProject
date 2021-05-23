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
    class AddRepairOrderCommand : Command
    {
        private readonly RepairClientViewModel _repairClientViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private readonly AuthenticationStore _authentificationStore;
        private User _user;

        public AddRepairOrderCommand(RepairClientViewModel repairClientViewModel, UnitOfWorkFactory unitOfWorkFactory, AuthenticationStore authenticationStore)
        {
            _repairClientViewModel = repairClientViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
            _authentificationStore = authenticationStore;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_repairClientViewModel.ClientFIO) && !string.IsNullOrEmpty(_repairClientViewModel.Description);
        }

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _user = unitOfWork.UserRepository.GetUser(_repairClientViewModel.User.Id);
                RepairOrder newOrder = new RepairOrder()
                {
                    Status = OrderStatus.Accepted,
                    ClientFIO = _repairClientViewModel.ClientFIO,
                    Image = _repairClientViewModel.Image,
                    Description = _repairClientViewModel.Description,
                    User = _user
                };

                unitOfWork.RepairOrderRepository.Create(newOrder);
                await unitOfWork.SaveAsync();
            }
            _repairClientViewModel.NavigateToOrdersClientCommand.Execute(null);
        }
    }
}
