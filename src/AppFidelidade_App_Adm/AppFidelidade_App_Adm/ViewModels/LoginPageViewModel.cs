using AppFidelidade_App_Adm.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

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
            AtivarLoad(true);
            if(string.IsNullOrEmpty(Login.Usuario) || string.IsNullOrEmpty(Login.Senha))
            {
                AtivarLoad(false);
                await _dialogService.DisplayAlertAsync("Erro", "Usuario e senha obrigatorios", "OK");
                return;
            }
            var api = new AppFidelidadeService();
            var result = await api.FuncionarioLogin(Login.Usuario, Login.Senha);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro" , "OK");
                AtivarLoad(false);
                return;
            }else
            {
                var storage = new StorageService();
                storage.InserirLogin(new Models.SqLiteLogin { Login = JsonConvert.SerializeObject(Login), LoginData = JsonConvert.SerializeObject(result.Item2) });
                Data.SalvarLogin(result.Item2);
                AtivarLoad(false);
                await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
            }
        }
    }
}
