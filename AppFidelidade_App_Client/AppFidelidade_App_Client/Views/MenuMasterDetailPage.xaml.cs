using AppFidelidade_App_Client.ViewModels;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.Views
{
    public partial class MenuMasterDetailPage : MasterDetailPage
    {
        private BaseViewModel ViewModel => BindingContext as BaseViewModel;
        public MenuMasterDetailPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel == null) return;
            await ViewModel.LoadAsync();
        }
    }
}