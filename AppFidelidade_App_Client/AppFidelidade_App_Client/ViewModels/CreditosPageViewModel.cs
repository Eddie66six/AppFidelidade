using AppFidelidade_App_Client.Models;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace AppFidelidade_App_Client.ViewModels
{
    public class CreditosPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        private ClienteCredito _clienteCredito;

        public ClienteCredito ClienteCredito
        {
            get { return _clienteCredito; }
            set { SetProperty(ref _clienteCredito, value); }
        }


        public CreditosPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }
        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ObterCreditoBasico(1);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                ClienteCredito = result.Item2;   
            }
            AtivarLoad(false);
        }
    }
}
