using AppFidelidade_App_Adm.Models.Funcionarios;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class FuncionariosPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand NovoFuncionarioCommand { get; }
        private int total = 0;
        private List<Funcionario> _funcionarios;

        public List<Funcionario> Funcionarios
        {
            get { return _funcionarios; }
            set { SetProperty(ref _funcionarios, value); }
        }


        public FuncionariosPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NovoFuncionarioCommand = new Command(NovoFuncionario);
        }

        private void NovoFuncionario()
        {
            _navigationService.NavigateAsync("NovaRegraPage");
        }

        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.ObterFuncionarios(Data.ObterIdFuncionario(), Data.ObterIdFilial(), 100, 0);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                var funcionarios = result.Item2;
                total = funcionarios.Total;
                Funcionarios = new List<Funcionario>();
                foreach (var item in funcionarios.Funcionarios)
                    Funcionarios.Add(item);
            }
            AtivarLoad(false);
        }
    }
}
