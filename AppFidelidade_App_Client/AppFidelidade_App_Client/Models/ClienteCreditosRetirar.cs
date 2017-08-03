using System.Collections.Generic;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteCreditosRetirar
    {
        public decimal TotalCreditos { get; set; }
        public List<ClienteCreditosRetirarBasico> Creditos { get; set; }
    }
}
