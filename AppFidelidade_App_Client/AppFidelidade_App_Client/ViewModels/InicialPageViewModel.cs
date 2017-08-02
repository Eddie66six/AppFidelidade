using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand GerarQrCodeCommand { get; }
        public InicialPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GerarQrCodeCommand = new Command(GerarQrCode);
        }
        private async void GerarQrCode()
        {
            await _navigationService.NavigateAsync("QrCodePage");
        }
    }
}
