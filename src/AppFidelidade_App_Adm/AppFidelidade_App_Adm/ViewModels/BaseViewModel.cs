using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }

        private bool _isVisibleOrEnable = true;
        public bool IsVisibleOrEnable
        {
            get { return _isVisibleOrEnable; }
            set { SetProperty(ref _isVisibleOrEnable, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public void AtivarLoad(bool ativar)
        {
            IsBusy = ativar;
            IsVisibleOrEnable = !ativar;
        }
    }
}
