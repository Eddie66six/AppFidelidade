﻿using Prism.Commands;
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
                    Nome = "Inicio",
                    Parametro = "MenuNavigationPage/InicialPage"
                },
                new ItemMenu
                {
                    Nome = "Gerar credito",
                    Parametro = "MenuNavigationPage/GerarCreditoPage"
                },
                new ItemMenu
                {
                    Nome = "Resgatar creito",
                    Parametro = "MenuNavigationPage/ResgatarCreditoPage"
                },
                new ItemMenu
                {
                    Nome = "Regras",
                    Parametro = "MenuNavigationPage/RegrasPage"
                },
                new ItemMenu
                {
                    Nome = "Funcionarios",
                    Parametro = "MenuNavigationPage/FuncionariosPage"
                }
            };
        }

        private void Navigate(ItemMenu parametro)
        {
            _navigationService.NavigateAsync(parametro.Parametro);
        }
    }

    public class ItemMenu
    {
        public string Icone { get; set; }
        public string Nome { get; set; }
        public string Parametro { get; set; }
    }
}