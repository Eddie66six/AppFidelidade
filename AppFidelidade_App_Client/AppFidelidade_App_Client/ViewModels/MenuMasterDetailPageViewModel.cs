using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Services;

namespace AppFidelidade_App_Client.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel
    {
        AzureServices azureService;
        public List<ItemMenu> ItensMenu { get; }
        INavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }

        public string UrlFoto { get; set; }
        public string Nome { get; set; }

        public MenuMasterDetailPageViewModel(INavigationService navigationService)
        {
            azureService = Xamarin.Forms.DependencyService.Get<AzureServices>();
            UrlFoto = Settings.Foto;
            Nome = Settings.Nome;
            _navigationService = navigationService;
            NavigateCommand = new Command<ItemMenu>(Navigate);
            ItensMenu = ObterMenus();
        }

        private void Navigate(ItemMenu parametro)
        {
            if(parametro.Parametro != "LoginPage")
            {
                _navigationService.NavigateAsync(parametro.Parametro);
            }
            else
            {
                Settings.Clear();
                _navigationService.NavigateAsync(parametro.Parametro);
            }
        }

        public override async Task LoadAsync()
        {
            if (Convert.ToDateTime(Settings.LoginDate).Date != DateTime.UtcNow.Date)
            {
                if (!await azureService.LoginAsync())
                {
                    await _navigationService.NavigateAsync("LoginPage");
                    return;
                }
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
    }
    public class ItemMenu
    {
        public string Icone { get; set; }
        public string Nome { get; set; }
        public string Parametro { get; set; }
    }
}
