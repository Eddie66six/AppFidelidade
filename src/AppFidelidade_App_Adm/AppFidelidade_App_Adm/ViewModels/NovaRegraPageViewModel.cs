using Prism.Mvvm;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class NovaRegraPageViewModel : BaseViewModel
    {
        private decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { SetProperty(ref _valor, value); }
        }
        private decimal _porcentagem;

        public decimal Porcentagem
        {
            get { return _porcentagem; }
            set { SetProperty(ref _porcentagem, value); }
        }
        public NovaRegraPageViewModel()
        {

        }
    }
}
