using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;

namespace AppFidelidade_App_Client.ViewModels
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
            ItensMenu = ObterMenus();
        }

        private void Navigate(ItemMenu parametro)
        {
            _navigationService.NavigateAsync(parametro.Parametro);
        }

        private List<ItemMenu> ObterMenus()
        {
            return new List<ItemMenu>()
            {
                new ItemMenu
                {
                    Icone = "inicio_black.png",
                    Nome = "Inicio",
                    Parametro = "MenuNavigationPage/InicialPage"
                },
                new ItemMenu
                {
                    Icone = "credito_black.png",
                    Nome = "Creditos",
                    Parametro = "MenuNavigationPage/CreditosPage"
                },
                new ItemMenu
                {
                    Icone = "resgatar_credito_black.png",
                    Nome = "Resgate de credito",
                    Parametro = "MenuNavigationPage/CreditosResgatePage"
                },
                new ItemMenu
                {
                    Icone = "sobre_black.png",
                    Nome = "Sobre",
                    Parametro = "MenuNavigationPage/SobrePage"
                },
                new ItemMenu
                {
                    Icone = "sair_black.png",
                    Nome = "Sair",
                    Parametro = "LoginPage"
                }
            };
        }

        public override async Task LoadAsync()
        {
            if (Data.DataUltimoLogin != null && Data.DataUltimoLogin.Date == DateTime.Today.Date)
                return;
            if (!Data.ExisteCliente())
            {
                await _navigationService.NavigateAsync("LoginPage");
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
