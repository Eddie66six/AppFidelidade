using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class RegrasPageViewModel : BaseViewModel
    {
        INavigationService _navigationService;
        public ICommand NovaRegraCommand { get; }
        public List<Models.Regra> Regras { get; set; }
        public RegrasPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NovaRegraCommand = new Command(NovaRegra);
            Regras = new List<Models.Regra>()
            {
                new Models.Regra()
                {
                    IdRegra = 1,
                    Nome = "Acima de 10",
                    Valor = 10.0m,
                    ValorGanho = 5.0m
                },
                new Models.Regra()
                {
                    IdRegra = 1,
                    Nome = "Acima de 30",
                    Valor = 30.0m,
                    ValorGanho = 15.0m
                },
                new Models.Regra()
                {
                    IdRegra = 1,
                    Nome = "Acima de 100",
                    Valor = 100.0m,
                    ValorGanho = 25.0m
                },
                new Models.Regra()
                {
                    IdRegra = 1,
                    Nome = "Acima de 200",
                    Valor = 200.0m,
                    ValorGanho = 10.0m
                },
                new Models.Regra()
                {
                    IdRegra = 1,
                    Nome = "Acima de 500",
                    Valor = 500.0m,
                    ValorGanho = 15.0m
                }
            };
        }

        private void NovaRegra()
        {
            _navigationService.NavigateAsync("NovaRegraPage");
        }
    }
}
