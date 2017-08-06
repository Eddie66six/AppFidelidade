using AppFidelidade_App_Adm.Interfaces;
using AppFidelidade_App_Adm.ViewModels;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.Views
{
    public partial class MenuMasterDetailPage : MasterDetailPage//, IMasterDetailPageOptions
    {
        private BaseViewModel ViewModel => BindingContext as BaseViewModel;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel == null) return;
            await ViewModel.LoadAsync();
        }
    }
}