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
    class OrderClientViewModel : ViewModel
    {
        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToItemInfoClientCommand { get; }

        public OrderClientViewModel(NavigationStore navigationStore)
        {
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore));
            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(navigationStore));
            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, () => new OrdersClientViewModel(navigationStore));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore));
            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, () => new RepairClientViewModel(navigationStore));
            NavigateToItemInfoClientCommand = new NavigateCommand<ItemInfoClientViewModel>(navigationStore, () => new ItemInfoClientViewModel(navigationStore));
        }
    }
}
