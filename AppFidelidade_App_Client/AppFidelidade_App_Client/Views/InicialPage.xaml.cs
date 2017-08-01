using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppFidelidade_App_Client.Views
{
    public partial class InicialPage : BasePage
    {
        ZXingBarcodeImageView barcode;
        public InicialPage()
        {
            InitializeComponent();
            var barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 180;
            barcode.BarcodeOptions.Height = 180;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = Data.ObterQrCode();
            qrResult.Content = barcode;
        }
    }
}
