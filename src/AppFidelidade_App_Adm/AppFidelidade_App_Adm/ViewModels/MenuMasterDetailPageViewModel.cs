using AppFidelidade_App_Adm.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
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
            ItensMenu = new List<ItemMenu>()
            {
                new ItemMenu
                {
                    Icone = "inicio_black.png",
                    Nome = "Inicio",
                    Parametro = "MenuNavigationPage/InicialPage"
                },
                new ItemMenu
                {
                    Icone = "gerar_credito_black.png",
                    Nome = "Gerar credito",
                    Parametro = "MenuNavigationPage/GerarCreditoPage"
                },
                new ItemMenu
                {
                    Icone = "resgatar_credito_black.png",
                    Nome = "Resgatar creito",
                    Parametro = "MenuNavigationPage/ResgatarCreditoPage"
                },
                new ItemMenu
                {
                    Icone = "regra_black.png",
                    Nome = "Regras",
                    Parametro = "MenuNavigationPage/RegrasPage"
                },
                new ItemMenu
                {
                    Icone = "funcionario_black.png",
                    Nome = "Funcionarios",
                    Parametro = "MenuNavigationPage/FuncionariosPage"
                }
                ,
                new ItemMenu
                {
                    Icone = "sobre_black.png",
                    Nome = "Sobre",
                    Parametro = "MenuNavigationPage/SobrePage"
                },
                new ItemMenu
                {
                    Icone = "sobre_black.png",
                    Nome = "Sair",
                    Parametro = "LoginPage"
                }
            };
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
    }

    public class ItemMenu
    {
        public string Icone { get; set; }
        public string Nome { get; set; }
        public string Parametro { get; set; }
    }
}
