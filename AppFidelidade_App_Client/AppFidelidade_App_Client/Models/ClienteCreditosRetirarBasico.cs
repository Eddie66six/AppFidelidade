using System;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteCreditosRetirarBasico
    {
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public long IdCompra { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal Creditos { get; set; }
    }
}
