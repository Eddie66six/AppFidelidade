using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand LoginCommand { get; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            LoginCommand = new Command(Logar);
        }

        private async void Logar()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService();
            var result = await api.ClienteBasico(1);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                Data.SalvarCliente(result.Item2);
                await _navigationService.NavigateAsync("MenuMasterDetailPage/MenuNavigationPage/InicialPage");
            }
            AtivarLoad(false);
        }
    }
}
