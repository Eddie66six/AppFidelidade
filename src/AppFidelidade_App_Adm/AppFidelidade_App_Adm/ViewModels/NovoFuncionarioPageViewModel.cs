using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class NovoFuncionarioPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand SalvarFuncionarioCommand { get; }
        public ICommand ExcluirFuncionarioCommand { get; }
        private Models.Funcionarios.Funcionario _funcionario;

        public Models.Funcionarios.Funcionario Funcionario
        {
            get { return _funcionario; }
            set { SetProperty(ref _funcionario, value); }
        }

        private bool _editar;

        public bool Editar
        {
            get { return _editar; }
            set { SetProperty(ref _editar, value); }
        }


        public NovoFuncionarioPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SalvarFuncionarioCommand = new Command(SalvarFuncionario);
            ExcluirFuncionarioCommand = new Command(ExcluirFuncionario);
            Funcionario = new Models.Funcionarios.Funcionario(Data.ObterIdFuncionario());
            Editar = false;
        }

        private async void ExcluirFuncionario()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.ExcluirFuncionario(Funcionario.IdFuncionario,Data.ObterIdFuncionario());
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
                return;
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
            AtivarLoad(false);
        }

        private async void SalvarFuncionario()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await (Funcionario.IdFuncionario == 0 ? api.AdicionarFuncionario(Funcionario) : api.AtualizarFuncionario(Funcionario));
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
        public override void MyOnNavigatedTo(NavigationParameters parameters)
        {
            AtivarLoad(true);
            if (!parameters.ContainsKey("obj"))
            {
                AtivarLoad(false);
                return;
            }
            var json = (string)parameters["obj"];
            if (string.IsNullOrEmpty(json)) return;
            Funcionario = JsonConvert.DeserializeObject<Models.Funcionarios.Funcionario>(json);
            Editar = true;
            AtivarLoad(false);
        }
    }
}
