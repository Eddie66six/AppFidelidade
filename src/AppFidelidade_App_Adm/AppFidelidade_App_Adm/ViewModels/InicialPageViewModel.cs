using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;
using AppFidelidade_App_Adm.Models.Contratos;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand ResgatarCreditoCommand { get; }
        public ICommand GerarCreditoCommand { get; }
        private ResumoRegraFuncionario _resumoRegraFuncionario;

        public ResumoRegraFuncionario ResumoRegraFuncionario
        {
            get { return _resumoRegraFuncionario; }
            set { SetProperty(ref _resumoRegraFuncionario ,value); }
        }

        private bool _adm;

        public bool Adm
        {
            get { return _adm; }
            set { SetProperty(ref _adm, value); }
        }

        public InicialPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            ResgatarCreditoCommand = new Command(ResgatarCredito);
            GerarCreditoCommand = new Command(GerarCredito);
            Adm = false;
        }

        private async void GerarCredito()
        {
            await _navigationService.NavigateAsync("GerarCreditoPage");
        }

        private async void ResgatarCredito()
        {
            await _navigationService.NavigateAsync("ResgatarCreditoPage");
        }

        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            if (Data.ObterTipoFuncionario() == 1)
            {
                Adm = true;
                var api = new Services.AppFidelidadeService(Data.ObterToken());
                var result = await api.ObterResumoRegraFuncionario(Data.ObterIdFuncionario(), Data.ObterIdFilial());
                if (result == null || result.Item1 != null)
                {
                    await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                    AtivarLoad(false);
                }
                else
                {
                    ResumoRegraFuncionario = result.Item2;
                }
            }
            AtivarLoad(false);
        }
    }
}
