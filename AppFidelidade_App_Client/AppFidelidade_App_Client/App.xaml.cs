using Prism.Unity;
using AppFidelidade_App_Client.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppFidelidade_App_Client.Helpers;

namespace AppFidelidade_App_Client
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            if (Settings.IsLoggedIn)
            {
                await NavigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
                return;
            }
            else
            {
                await NavigationService.NavigateAsync("LoginPage");
                return;
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
            Container.RegisterTypeForNavigation<CompartilharPage>();
        }
    }
}
