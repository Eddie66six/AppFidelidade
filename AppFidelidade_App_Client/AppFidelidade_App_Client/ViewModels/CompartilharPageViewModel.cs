using AppFidelidade_App_Client.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using AppFidelidade_App_Client.Helpers;

namespace AppFidelidade_App_Client.ViewModels
{
    public class CompartilharPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public ICommand CompartilharCommand { get; }

        private ClienteCreditosRetirarBasico _clienteCreditosRetirarBasico;

        public ClienteCreditosRetirarBasico ClienteCreditosRetirarBasico
        {
            get { return _clienteCreditosRetirarBasico; }
            set { SetProperty(ref _clienteCreditosRetirarBasico, value); }
        }

        public CompartilharPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            CompartilharCommand = new Command(Compartilhar);
        }

        private async void Compartilhar()
        {
            //TODO compratilhou
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.CreditarCompra(Convert.ToInt32(Settings.IdCliente), ClienteCreditosRetirarBasico.IdCompra);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
            AtivarLoad(false);
        }

        public override void MyOnNavigatedTo(NavigationParameters parameters)
        {
            AtivarLoad(true);
            if (!parameters.ContainsKey("obj"))
            {
                AtivarLoad(false);
                return;
            }
            var json = (string)parameters["obj"];
            if (string.IsNullOrEmpty(json)) return;
            ClienteCreditosRetirarBasico = JsonConvert.DeserializeObject<ClienteCreditosRetirarBasico>(json);
            AtivarLoad(false);
        }
    }
}
