using AppFidelidade_App_Client.Models;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using AppFidelidade_App_Client.Helpers;

namespace AppFidelidade_App_Client.ViewModels
{
    public class CreditosPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public ICommand LoadMoreCommand { get; }

        public ObservableCollection<ClienteCreditoBasico> Creditos { get; set; }

        private int _totalRegistros;
        private decimal _totalCreditoRetirada;

        public decimal TotalCreditoRetirada
        {
            get { return _totalCreditoRetirada; }
            set { SetProperty(ref _totalCreditoRetirada, value); }
        }

        private int page { get; set; }
        private int pageSize { get; set; }

        public CreditosPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            LoadMoreCommand = new Command(LoadMore);
            Creditos = new ObservableCollection<ClienteCreditoBasico>();
            _totalRegistros = 0;
            page = 2;
            pageSize = 5;
        }

        private async void LoadMore(object obj)
        {
            if (Creditos.Count >= _totalRegistros)
                return;
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ObterCreditoBasico(Convert.ToInt32(Settings.IdCliente), ((page - 1) * pageSize), pageSize);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                foreach (var item in result.Item2.Creditos)
                {
                    Creditos.Add(item);
                }
                page += 1;
            }
            AtivarLoad(false);
        }

        public override async Task LoadAsync()
        {
            if (Creditos.Count > 0) return;
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ObterCreditoBasico(Convert.ToInt32(Settings.IdCliente), 0, pageSize);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                TotalCreditoRetirada = result.Item2.TotalCreditosParaRetirada;
                _totalRegistros = result.Item2.TotalRegistros;
                foreach (var item in result.Item2.Creditos)
                {
                    Creditos.Add(item);
                }
                //invertido o valor bool para nao precisar usar converter
                if (Creditos.Count > 0 && Creditos.Count < pageSize)
                    Creditos[Creditos.Count - 1].Visivel = false;
            }
            AtivarLoad(false);
        }
    }
}
