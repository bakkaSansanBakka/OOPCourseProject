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
    class OrdersAdminViewModel : ViewModel
    {
        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToStoreAdminCommand { get; }

        public OrdersAdminViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToStoreAdminCommand = new NavigateCommand<StoreAdminViewModel>(navigationStore, () => new StoreAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }
    }
}
