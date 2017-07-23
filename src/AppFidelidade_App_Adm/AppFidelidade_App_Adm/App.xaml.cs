using Prism.Unity;
using AppFidelidade_App_Adm.Views;
using Xamarin.Forms;
using AppFidelidade_App_Adm.Services;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            if (await CheckLogin())
            {
                await NavigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
            }
            else
            {
                await NavigationService.NavigateAsync("LoginPage");
            }
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<MenuMasterDetailPage>();
            Container.RegisterTypeForNavigation<MenuNavigationPage>();
            Container.RegisterTypeForNavigation<InicialPage>();
            Container.RegisterTypeForNavigation<GerarCreditoPage>();
            Container.RegisterTypeForNavigation<ResgatarCreditoPage>();
            Container.RegisterTypeForNavigation<RegrasPage>();
            Container.RegisterTypeForNavigation<FuncionariosPage>();
            Container.RegisterTypeForNavigation<SobrePage>();
            Container.RegisterTypeForNavigation<NovaRegraPage>();
        }

        protected async Task<bool> CheckLogin()
        {
            var storage = new StorageService();
            var loginData = storage.ObterLogin();
            if (loginData == null) return false;

            var data = JsonConvert.DeserializeObject<Models.FuncionarioLogin>(loginData.LoginData);
            if (data.LoginData.ExpiresIn < DateTime.UtcNow.AddHours(5))
            {
                var login = JsonConvert.DeserializeObject<Models.Login>(loginData.LoginData);
                if (login == null)
                {
                    return false;
                }
                var novoLogin = await AppFidelidadeService.FuncionarioLogin(login.Usuario, login.Senha);
                if (novoLogin == null || novoLogin.Contains("errors")) return false;
                var sqlLogin = new Models.SqLiteLogin(login, JsonConvert.DeserializeObject<Models.FuncionarioLogin>(novoLogin));
                storage.InserirLogin(sqlLogin);
            }
            return true;
        }
    }
}
