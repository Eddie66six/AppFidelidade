using AppFidelidade_App_Adm.Models.Regras;
using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using Prism.Navigation;
using Prism.Services;

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

        public NovaRegraPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SalvarRegraCommand = new Command(SalvarRegra);
            Regra = new Regra(Data.ObterIdFuncionario());
        }

        private async void SalvarRegra()
        {
            AtivarLoad(true);
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.AdicionarRegra(Regra);
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
