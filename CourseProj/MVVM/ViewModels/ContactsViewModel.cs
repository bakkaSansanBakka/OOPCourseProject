using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.MVVM.ViewModels.Base;

namespace CourseProj.MVVM.ViewModels
{
    class ContactsViewModel : ViewModel
    {
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToExitCommand { get; }

        public ContactsViewModel(NavigationStore navigationStore)
        {
            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, () => new RepairClientViewModel(navigationStore));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore));
            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, () => new OrdersClientViewModel(navigationStore));
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore));
        }
    }
}
