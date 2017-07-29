using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class NovoFuncionarioPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand SalvarFuncionarioCommand { get; }
        private Models.Funcionarios.Funcionario _funcionario;

        public Models.Funcionarios.Funcionario Funcionario
        {
            get { return _funcionario; }
            set { SetProperty(ref _funcionario, value); }
        }

        public NovoFuncionarioPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SalvarFuncionarioCommand = new Command(SalvarFuncionario);
            Funcionario = new Models.Funcionarios.Funcionario(Data.ObterIdFuncionario());
        }

        private async void SalvarFuncionario()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.AdicionarFuncionario(Funcionario);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
            AtivarLoad(false);
        }
    }
}
