using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class ResgatarCreditoPageViewModel : BaseViewModel
    {
        private string _qrCode;

        public string QrCode
        {
            get { return _qrCode; }
            set { SetProperty(ref _qrCode, value); }
        }
        public ICommand LerQrCodeCommand { get; }
        public ICommand ResgatarCreditoCommand { get; }
        public ResgatarCreditoPageViewModel()
        {
            LerQrCodeCommand = new Command(LerQrCode);
            ResgatarCreditoCommand = new Command(ResgatarCredito);
        }

        private void ResgatarCredito()
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
