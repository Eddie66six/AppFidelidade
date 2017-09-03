using AppFidelidade_App_Client.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.Views
{
    public class BasePage : ContentPage
    {
        private BaseViewModel ViewModel => BindingContext as BaseViewModel;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel == null) return;
            await ViewModel.LoadAsync();
        }
        public void RemoveFirstPage()
        {
            var firstPage = Navigation.NavigationStack.FirstOrDefault();
            if (firstPage != null)
                Navigation.RemovePage(firstPage);
        }
    }
}
