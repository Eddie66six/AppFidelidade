using Prism.Mvvm;
using System.Threading.Tasks;

namespace AppFidelidadeMobile.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }

        private bool _isEnable = true;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public void PageLoad(bool onActivate)
        {
            IsBusy = onActivate;
            IsEnable = !onActivate;
        }
    }
}
