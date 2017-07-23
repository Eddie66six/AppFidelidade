using AppFidelidade_App_Adm.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Linq;
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
            var loginData = await AppFidelidadeService.FuncionarioLogin(Login.Usuario, Login.Senha);
            if (loginData == null || loginData.Contains("errors"))
            {
                var erros = JsonConvert.DeserializeObject<Models.Errors>(loginData);
                await _dialogService.DisplayAlertAsync("Erro", erros.errors[0].Value, "OK");
                return;
            }
            var storage = new StorageService();
            storage.InserirLogin(new Models.SqLiteLogin { Login = JsonConvert.SerializeObject(Login), LoginData = loginData });
            await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
        }
    }
}
