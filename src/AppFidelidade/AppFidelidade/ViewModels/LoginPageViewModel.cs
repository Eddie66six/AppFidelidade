using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
        }

        private void Login()
        {
            
        }
    }
}
