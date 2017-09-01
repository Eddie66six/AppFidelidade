using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System;
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

        private int Click { get; set; }

        public CreditosResgatePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NavigateCommand = new Command<ClienteCreditosRetirarBasico>(Compartilhar);
            Click = 0;
        }

        private void Compartilhar(ClienteCreditosRetirarBasico obj)
        {
            Click++;
            if(Click == 1)
                _navigationService.NavigateAsync($"CompartilharPage?obj={JsonConvert.SerializeObject(obj).Replace("/", "-")}");
        }
        public override async Task LoadAsync()
        {
            Click = 0;
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ObterCreditoResgatarBasico(Convert.ToInt32(Settings.IdCliente));
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
