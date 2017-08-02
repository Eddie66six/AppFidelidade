using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteCreditoViewModel
    {
        public decimal TotalCreditosParaRetirada { get; set; }
        public List<ClienteCreditoBasicoViewModel> Creditos { get; set; }
    }
}
