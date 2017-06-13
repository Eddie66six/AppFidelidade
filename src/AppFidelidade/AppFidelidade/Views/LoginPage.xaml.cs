using Xamarin.Forms;

namespace AppFidelidade.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.LoginPageViewModel();
        }
    }
}
