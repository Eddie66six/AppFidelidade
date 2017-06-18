using System.Threading.Tasks;
using AppFidelidadeMobile.Service;
using AppFidelidadeMobile.Models;

namespace AppFidelidadeMobile.ViewModels
{
    public class PerfilPageViewModel : BaseViewModel
    {
        AppFidelidadeApiService api;
        private Cliente _perfil;
        public Cliente Perfil
        {
            get { return _perfil; }
            set { SetProperty(ref _perfil, value); }
        }

        public PerfilPageViewModel()
        {
            api = new AppFidelidadeApiService();
        }

        public override async Task LoadAsync()
        {
            Perfil = await api.GetCliente(1);
        }
    }
}
