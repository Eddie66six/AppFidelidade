using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteCreditosRetirarViewModel
    {
        public decimal TotalCreditos { get; set; }
        public List<ClienteCreditosRetirarBasicoViewModel> Creditos { get; set; }
    }
}
