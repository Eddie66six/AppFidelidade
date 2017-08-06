using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Services;
using AppFidelidade_App_Adm.Models.Regras;
using AppFidelidade_App_Adm.Models.Contratos;
using System;
using Newtonsoft.Json;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class RegrasPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand NovaRegraCommand { get; }
        public ICommand NavigateCommand { get; }
        private int total = 0;
        private List<Regra> _regras;

        public List<Regra> Regras
        {
            get { return _regras; }
            set { SetProperty(ref _regras, value); }
        }
        private ResumoRegraFuncionario _resumoRegraFuncionario;

        public ResumoRegraFuncionario ResumoRegraFuncionario
        {
            get { return _resumoRegraFuncionario; }
            set { SetProperty(ref _resumoRegraFuncionario, value); }
        }

        private bool _permiteCadastrar;

        public bool PermiteCadastrar
        {
            get { return _permiteCadastrar; }
            set { SetProperty(ref _permiteCadastrar, value); }
        }


        public RegrasPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NovaRegraCommand = new Command(NovaRegra);
            NavigateCommand = new Command<Regra>(EditarRegar);
            PermiteCadastrar = Data.ObterTipoFuncionario() == 1;
        }

        private async void EditarRegar(Regra obj)
        {
            obj.IdFuncionarioLogado = Data.ObterIdFuncionario();
            await _navigationService.NavigateAsync($"NovaRegraPage?obj={JsonConvert.SerializeObject(obj)}");
        }

        private async void NovaRegra()
        {
            await _navigationService.NavigateAsync("NovaRegraPage");
        }

        public override async Task LoadAsync()
        {
            AtivarLoad(true);
            //regras
            var api = new Services.AppFidelidadeService(Data.ObterToken());
            var result = await api.ObterRegras(Data.ObterIdFilial(), 100, 0);
            if (result == null || result.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", result?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
                return;
            }
            else
            {
                var regras = result.Item2;
                total = regras.Total;
                Regras = new List<Regra>();
                foreach (var item in regras.Regras)
                    Regras.Add(item);
            }
            //resumo
            var resultResumo = await api.ObterResumoRegraFuncionario(Data.ObterIdFuncionario(), Data.ObterIdFilial());
            if (resultResumo == null || resultResumo.Item1 != null)
            {
                await _dialogService.DisplayAlertAsync("Erro", resultResumo?.Item1.errors[0].Value ?? "Ocorreu um erro", "OK");
                AtivarLoad(false);
                return;
            }
            else
            {
                ResumoRegraFuncionario = resultResumo.Item2;
            }
            AtivarLoad(false);
        }
    }
}
