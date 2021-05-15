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
    class OrdersClientViewModel : ViewModel
    {
        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }

        public OrdersClientViewModel(NavigationStore navigationStore)
        {
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore));
            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(navigationStore));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore));
            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, () => new RepairClientViewModel(navigationStore));
        }
    }
}
