using AppFidelidadeMobile.ViewModels;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidadeMobileADM.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService { get; set; }
        public ICommand LoginCommad { get; }
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommad = new Command(LoginExecute);
        }

        private async void LoginExecute(object obj)
        {
            PageLoad(true);
            await Task.Delay(2000);
            await _navigationService.NavigateAsync("MenuPage");
            PageLoad(false);
        }
    }
}
