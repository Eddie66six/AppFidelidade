using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Services;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        AzureServices azureService;
        AppFidelidadeService appFidelidadeService;

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand LoginCommand { get; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            azureService = Xamarin.Forms.DependencyService.Get<AzureServices>();
            appFidelidadeService = Xamarin.Forms.DependencyService.Get<AppFidelidadeService>();
            _navigationService = navigationService;
            _dialogService = dialogService;
            LoginCommand = new Command(Logar);
        }

        private async void Logar()
        {
            AtivarLoad(true);
            var loginFacebook = await azureService.LoginAsync();
            if(loginFacebook)
            {
                //cria o cliente
                var result = await appFidelidadeService.AdicionarAtualizar(Settings.Nome, Settings.UserId);
                if (result == null || result.Item1 != null)
                {
                    await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                    AtivarLoad(false);
                    return;
                }
                Settings.TokenId = result.Item2.TokenId;
                await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
            }
            AtivarLoad(false);
        }
    }
}
