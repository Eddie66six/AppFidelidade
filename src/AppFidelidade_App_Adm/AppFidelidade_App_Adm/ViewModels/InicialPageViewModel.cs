using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace AppFidelidade_App_Adm.ViewModels
{
    public class InicialPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand ResgatarCreditoCommand { get; }
        public ICommand GerarCreditoCommand { get; }
        public InicialPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ResgatarCreditoCommand = new Command(ResgatarCredito);
            GerarCreditoCommand = new Command(GerarCredito);
        }

        private async void GerarCredito()
        {
            await _navigationService.NavigateAsync("GerarCreditoPage");
        }

        private async void ResgatarCredito()
        {
            await _navigationService.NavigateAsync("ResgatarCreditoPage");
        }
    }
}
