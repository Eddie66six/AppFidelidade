using Prism.Unity;
using AppFidelidade_App_Adm.Views;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoginPage");
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
        }
    }
}
