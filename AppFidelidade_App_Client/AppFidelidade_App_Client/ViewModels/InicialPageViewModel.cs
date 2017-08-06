using AppFidelidade_App_Client.Models;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;

namespace AppFidelidade_App_Client.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
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
            _navigationService = navigationService;
            _dialogService = dialogService;
            GerarQrCodeCommand = new Command(GerarQrCode);
            ClienteBasico = Data.ObterDadosCliente();
        }
        private async void GerarQrCode()
        {
            await _navigationService.NavigateAsync("QrCodePage");
        }
        public override async Task LoadAsync()
        {
            var api = new Services.AppFidelidadeService();
            var result = await api.ClienteBasico(1);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                Data.SalvarCliente(result.Item2);
            }
        }
    }
}
