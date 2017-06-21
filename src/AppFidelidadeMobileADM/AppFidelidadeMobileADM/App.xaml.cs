using Prism.Unity;
using AppFidelidadeMobileADM.Views;
using Xamarin.Forms;

namespace AppFidelidadeMobileADM
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
            Container.RegisterTypeForNavigation<MenuPage>();
            Container.RegisterTypeForNavigation<RegrasPage>();
        }
    }
}
