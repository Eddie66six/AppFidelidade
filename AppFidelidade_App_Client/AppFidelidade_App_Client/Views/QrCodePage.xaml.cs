using AppFidelidade_App_Client.Helpers;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppFidelidade_App_Client.Views
{
    public partial class QrCodePage : BasePage
    {
        public ZXingBarcodeImageView barcode;
        public QrCodePage()
        {
            InitializeComponent();
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 500;
            barcode.BarcodeOptions.Height = 500;
            barcode.BarcodeOptions.Margin = 5;
            barcode.BarcodeValue = Settings.UsuarioTokenId;
            Content = barcode;
        }
    }
}
