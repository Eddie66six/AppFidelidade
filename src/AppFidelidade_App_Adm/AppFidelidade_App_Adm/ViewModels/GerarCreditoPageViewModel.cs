using AppFidelidade_App_Adm.Models.Clientes;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class GerarCreditoPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand LerQrCodeCommand { get; }
        public ICommand GerarCreditoCommand { get; }

        private string _qrCode;

        public string QrCode
        {
            get { return _qrCode; }
            set { SetProperty(ref _qrCode, value); }
        }
        private decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { SetProperty(ref _valor, value); }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
        }


        public GerarCreditoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            LerQrCodeCommand = new Command(LerQrCode);
            GerarCreditoCommand = new Command(GerarCredito);
        }

        private async void GerarCredito()
        {
            AtivarLoad(true);
            if (Valor <= 0)
            {
                await _dialogService.DisplayAlertAsync("Erro", "A compra deve ter valor", "OK");
                AtivarLoad(false);
                return;
            }
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.LancarCompra(new Models.Compras.LancarCompra(Valor, Data.ObterIdFuncionario(), Cliente.IdCliente, null));
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                var compra = result.Item2;
                Cliente = new Cliente();
                QrCode = null;
                Valor = 0;
            }
            AtivarLoad(false);
        }

        public async void LerQrCode()
        {
            if (string.IsNullOrEmpty(QrCode))
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                {
                    QrCode = result.Text;
                }
            }
            BuscarCliente();
        }

        private async void BuscarCliente()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.ObterCliente(QrCode, Data.ObterIdFilial());
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                Cliente = result.Item2;
            }
            AtivarLoad(false);
        }
    }
}
