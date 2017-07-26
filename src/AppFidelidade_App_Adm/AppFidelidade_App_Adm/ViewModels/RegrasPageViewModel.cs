using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;
using AppFidelidade_App_Adm.Models.Regras;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class RegrasPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand NovaRegraCommand { get; }
        private int total = 0;
        private List<Regra> _regras;

        public List<Regra> Regras
        {
            get { return _regras; }
            set { SetProperty(ref _regras, value); }
        }


        public RegrasPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NovaRegraCommand = new Command(NovaRegra);
        }

        private void NovaRegra()
        {
            _navigationService.NavigateAsync("NovaRegraPage");
        }

        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.ObterRegras(Data.ObterIdFilial(), 100, 0);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
            }
            else
            {
                var regras = result.Item2;
                total = regras.Total;
                Regras = new List<Regra>();
                foreach (var item in regras.Regras)
                    Regras.Add(item);
            }
            AtivarLoad(false);
        }
    }
}
