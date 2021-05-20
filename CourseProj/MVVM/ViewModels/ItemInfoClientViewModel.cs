﻿using System;
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
    class ItemInfoClientViewModel : ViewModel
    {
        public ICommand NavigateToExitCommand { get; }
        public ICommand NavigateToContactsCommand { get; }
        public ICommand NavigateToOrdersClientCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateToRepairCommand { get; }
        public ICommand NavigateToOrderClientCommand { get; }

        public ItemInfoClientViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory)
        {
            NavigateToExitCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToOrdersClientCommand = new NavigateCommand<OrdersClientViewModel>(navigationStore, () => new OrdersClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToRepairCommand = new NavigateCommand<RepairClientViewModel>(navigationStore, () => new RepairClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
            NavigateToOrderClientCommand = new NavigateCommand<OrderClientViewModel>(navigationStore, () => new OrderClientViewModel(navigationStore, authenticationStore, unitOfWorkFactory));
        }
    }
}
