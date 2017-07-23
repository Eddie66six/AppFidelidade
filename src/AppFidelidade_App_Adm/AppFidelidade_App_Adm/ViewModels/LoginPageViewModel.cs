using AppFidelidade_App_Adm.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand LoginCommand { get; }
        private Models.Login _login;

        public Models.Login Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            LoginCommand = new Command(Logar);
            Login = new Models.Login();
        }

        private async void Logar()
        {
            var loginData = await Services.AppFidelidadeService.FuncionarioLogin(Login.Usuario, Login.Senha);
            if (loginData == null)
            {
                await _dialogService.DisplayAlertAsync("Erro", "Usuario Não encontrado", "OK");
                return;
            }
            var storage = new StorageService();
            storage.InserirLogin(new Models.SqLiteLogin { Login = JsonConvert.SerializeObject(Login), LoginData = JsonConvert.SerializeObject(loginData) });
            await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
        }
    }
}
