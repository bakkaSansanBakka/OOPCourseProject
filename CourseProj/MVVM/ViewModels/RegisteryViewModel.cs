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
    class RegisteryViewModel : ViewModel
    {
        public ICommand NavigateToStoreClientCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public RegisteryViewModel(NavigationStore navigationStore)
        {
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore));
            NavigateBackCommand = new NavigateCommand<LogInViewModel>(navigationStore, () => new LogInViewModel(navigationStore));
        }
    }
}
