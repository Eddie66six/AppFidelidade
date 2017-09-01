using AppFidelidade_App_Client.Models;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;
using System;
using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Services;

namespace AppFidelidade_App_Client.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        AzureServices azureService;
        AppFidelidadeService appFidelidadeService;

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand GerarQrCodeCommand { get; }
        private ClienteBasico _clienteBasico;

        public ClienteBasico ClienteBasico
        {
            get { return _clienteBasico; }
            set { SetProperty(ref _clienteBasico, value); }
        }

        public InicialPageViewModel(IPageDialogService dialogService, INavigationService navigationService)
        {
            azureService = Xamarin.Forms.DependencyService.Get<AzureServices>();
            appFidelidadeService = Xamarin.Forms.DependencyService.Get<AppFidelidadeService>();
            _navigationService = navigationService;
            _dialogService = dialogService;
            GerarQrCodeCommand = new Command(GerarQrCode);
            ClienteBasico = new ClienteBasico();
        }
        private async void GerarQrCode()
        {
            await _navigationService.NavigateAsync("QrCodePage");
        }
        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            //cria o cliente
            var result = await appFidelidadeService.AdicionarAtualizar(Settings.Nome, Settings.UserId);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
                return;
            }
            ClienteBasico = result.Item2;
            Settings.UsuarioTokenId = ClienteBasico.TokenId;
            Settings.IdCliente = ClienteBasico.IdCliente.ToString();
            AtivarLoad(false);
        }
    }
}
