using AppFidelidade_App_Adm.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel
    {
        public List<ItemMenu> ItensMenu { get; }
        INavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }
        public MenuMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new Command<ItemMenu>(Navigate);
            ItensMenu = ObterMenus().Where(p => p.Visivel == true).ToList();
        }

        private void Navigate(ItemMenu parametro)
        {
            if(parametro.Parametro != "LoginPage")
                _navigationService.NavigateAsync(parametro.Parametro);
            else
            {
                var storage = new StorageService();
                storage.Limpar();
                _navigationService.NavigateAsync(parametro.Parametro);
            }
        }

        private List<ItemMenu> ObterMenus()
        {
            return new List<ItemMenu>()
            {
                new ItemMenu
                {
                    Icone = "inicio_black.png",
                    Nome = "Inicio",
                    Parametro = "MenuNavigationPage/InicialPage",
                    Visivel = true
                },
                new ItemMenu
                {
                    Icone = "gerar_credito_black.png",
                    Nome = "Gerar credito",
                    Parametro = "MenuNavigationPage/GerarCreditoPage",
                    Visivel = true
                },
                new ItemMenu
                {
                    Icone = "resgatar_credito_black.png",
                    Nome = "Resgatar creito",
                    Parametro = "MenuNavigationPage/ResgatarCreditoPage",
                    Visivel = true
                },
                new ItemMenu
                {
                    Icone = "regra_black.png",
                    Nome = "Regras",
                    Parametro = "MenuNavigationPage/RegrasPage",
                    Visivel = true
                },
                new ItemMenu
                {
                    Icone = "funcionario_black.png",
                    Nome = "Funcionarios",
                    Parametro = "MenuNavigationPage/FuncionariosPage",
                    Visivel = Data.ObterTipoFuncionario() == 1
                }
                ,
                new ItemMenu
                {
                    Icone = "sobre_black.png",
                    Nome = "Sobre",
                    Parametro = "MenuNavigationPage/SobrePage",
                    Visivel = true
                },
                new ItemMenu
                {
                    Icone = "sair_black.png",
                    Nome = "Sair",
                    Parametro = "LoginPage",
                    Visivel = true
                }
            };
        }
    }

    public class ItemMenu
    {
        public string Icone { get; set; }
        public string Nome { get; set; }
        public string Parametro { get; set; }
        public bool Visivel { get; set; }
    }
}
