using AppFidelidade_App_Client.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.ViewModels
{
    public class CreditosResgatePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public ICommand NavigateCommand { get; }

        private ClienteCreditosRetirar _clienteCreditosRetirar;
        public ClienteCreditosRetirar ClienteCreditosRetirar
        {
            get { return _clienteCreditosRetirar; }
            set { SetProperty(ref _clienteCreditosRetirar, value); }
        }

        public CreditosResgatePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NavigateCommand = new Command<ClienteCreditosRetirarBasico>(Compartilhar);
        }

        private async void Compartilhar(ClienteCreditosRetirarBasico obj)
        {
            await _navigationService.NavigateAsync($"CompartilharPage?obj={JsonConvert.SerializeObject(obj).Replace("/", "-")}");
        }
        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ObterCreditoResgatarBasico(1);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                ClienteCreditosRetirar = result.Item2;
            }
            AtivarLoad(false);
        }
    }
}
