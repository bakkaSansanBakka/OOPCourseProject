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
    class LogInViewModel : ViewModel
    {
        public ICommand NavigateToRegisteryCommand { get; }
        public ICommand NavigateToStoreClientCommand { get; }


        public LogInViewModel(NavigationStore navigationStore)
        {
            NavigateToRegisteryCommand = new NavigateCommand<RegisteryViewModel>(navigationStore, () => new RegisteryViewModel(navigationStore));
            NavigateToStoreClientCommand = new NavigateCommand<StoreClientViewModel>(navigationStore, () => new StoreClientViewModel(navigationStore));
        }
    }
}
