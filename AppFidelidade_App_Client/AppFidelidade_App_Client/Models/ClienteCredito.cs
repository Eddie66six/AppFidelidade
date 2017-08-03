using System.Collections.Generic;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteCredito
    {
        public decimal TotalCreditosParaRetirada { get; set; }
        public List<ClienteCreditoBasico> Creditos { get; set; }
    }
}
