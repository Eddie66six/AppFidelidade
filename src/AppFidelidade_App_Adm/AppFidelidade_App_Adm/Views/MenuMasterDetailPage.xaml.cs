using AppFidelidade_App_Adm.Interfaces;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.Views
{
    public partial class MenuMasterDetailPage : MasterDetailPage//, IMasterDetailPageOptions
    {
        public MenuMasterDetailPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
            var page = (NavigationPage)Detail;
            var current = page.CurrentPage.GetType();
            if (current.Name == "InicialPage")
                if (Device.OS == TargetPlatform.Android)
                    DependencyService.Get<IAndroidMethods>().CloseApp();
            return base.OnBackButtonPressed();
        }
    }
}