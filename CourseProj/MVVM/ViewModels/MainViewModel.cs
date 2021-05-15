using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.Core;
using CourseProj.MVVM.ViewModels.Base;

namespace CourseProj.MVVM.ViewModels
{
    class MainViewModel : ViewModel
    {
        private readonly NavigationStore navigationStore;

        public MainViewModel(NavigationStore _navigationStore)
        {
            navigationStore = _navigationStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        public ViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
