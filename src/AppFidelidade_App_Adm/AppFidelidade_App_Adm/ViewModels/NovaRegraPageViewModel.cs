using AppFidelidade_App_Adm.Models.Regras;
using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Services;
using Newtonsoft.Json;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class NovaRegraPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand SalvarRegraCommand { get; }
        private Regra _regra;

        public Regra Regra
        {
            get { return _regra; }
            set { SetProperty(ref _regra, value); }
        }

        private bool _novo;

        public bool Novo
        {
            get { return _novo; }
            set { SetProperty(ref _novo, value); }
        }


        public NovaRegraPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SalvarRegraCommand = new Command(SalvarRegra);
            Regra = new Regra(Data.ObterIdFuncionario());
            Novo = true;
        }

        private async void SalvarRegra()
        {
            AtivarLoad(true);
            Novo = this.IsVisibleOrEnable;
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await (Regra.IdRegra == 0? api.AdicionarRegra(Regra) : api.AtualizarRegra(Regra));
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
                Novo = this.IsVisibleOrEnable;
                return;
            }
            else
            {
                await _navigationService.GoBackAsync();
            }
            AtivarLoad(false);
            Novo = this.IsVisibleOrEnable;
        }
        public override void MyOnNavigatedTo(NavigationParameters parameters)
        {
            AtivarLoad(true);
            Novo = this.IsVisibleOrEnable;
            if (!parameters.ContainsKey("obj"))
            {
                AtivarLoad(false);
                Novo = this.IsVisibleOrEnable;
                return;
            }
            var json = (string)parameters["obj"];
            if (string.IsNullOrEmpty(json)) return;
            Regra = JsonConvert.DeserializeObject<Regra>(json);
            Novo = false;
            AtivarLoad(false);
            Novo = this.IsVisibleOrEnable;
        }
    }
}
