using System;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteCreditoBasico
    {
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal TotalCreditos { get; set; }
    }
}
