using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class GerarCreditoPageViewModel : BaseViewModel
    {
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

        public ICommand LerQrCodeCommand { get; }
        public ICommand GerarCreditoCommand { get; }
        public GerarCreditoPageViewModel()
        {
            LerQrCodeCommand = new Command(LerQrCode);
            GerarCreditoCommand = new Command<string>(GerarCredito);
        }

        private void GerarCredito(string code)
        {
            
        }

        async void LerQrCode()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
 
            if (result != null)
            {
                QrCode = result.Text;
            }
        }
    }
}
