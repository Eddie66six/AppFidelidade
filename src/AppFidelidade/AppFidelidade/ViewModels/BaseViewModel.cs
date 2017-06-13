using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AppFidelidade.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool SetPropertyChanged<T>(T storege, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storege, value))
                return false;

            storege = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async void PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewName = $"MaratonaIntermediaria.Views.{viewModelType?.Name.Replace("ViewModel", "")}Page";
            var viewType = Type.GetType(viewName);
            //injeção de dependencia
            //if (viewType.GetTypeInfo().DeclaredConstructors.Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(IServiceApi))))
            //{
            //    var lstArgs = args.ToList();
            //    var viewModel = DependencyService.Get<IServiceApi>();
            //    lstArgs.Insert(0, viewModel);
            //    args = lstArgs.ToArray();
            //}
            var view = Activator.CreateInstance(viewType, args) as Page;
            //binging
            if (view != null)
            {
                var viewModel = Activator.CreateInstance(viewModelType);
                view.BindingContext = viewModel;
            }
            await Application.Current.MainPage.Navigation.PushAsync(view);
        }
    }
}
