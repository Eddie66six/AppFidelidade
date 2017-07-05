using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand LoginCommand { get; }
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new Command(Login);
        }

        private async void Login()
        {
            await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
        }
    }
}
