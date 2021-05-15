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
    class StoreAdminViewModel : ViewModel
    {
        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToOrdersAdminCommand { get; }

        public StoreAdminViewModel(NavigationStore navigationStore)
        {
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore));
            NavigateToOrdersAdminCommand = new NavigateCommand<OrdersAdminViewModel>(navigationStore, () => new OrdersAdminViewModel(navigationStore));
        }
    }
}
