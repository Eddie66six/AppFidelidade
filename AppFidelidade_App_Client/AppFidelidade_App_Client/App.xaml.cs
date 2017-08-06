using Prism.Unity;
using AppFidelidade_App_Client.Views;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppFidelidade_App_Client
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
            Container.RegisterTypeForNavigation<SobrePage>();
            Container.RegisterTypeForNavigation<InicialPage>();
            Container.RegisterTypeForNavigation<QrCodePage>();
            Container.RegisterTypeForNavigation<CreditosPage>();
            Container.RegisterTypeForNavigation<CreditosResgatePage>();
        }
        protected async Task<bool> CheckLogin()
        {
            //var storage = new StorageService();
            //var loginData = storage.ObterLogin();
            //if (loginData == null) return false;
            return true;
        }
    }
}
