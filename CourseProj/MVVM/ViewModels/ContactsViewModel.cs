using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    class ContactsViewModel : ViewModel
    {
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToExitCommand { get; }

        public ContactsViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, () => new RepairClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }
    }
}
