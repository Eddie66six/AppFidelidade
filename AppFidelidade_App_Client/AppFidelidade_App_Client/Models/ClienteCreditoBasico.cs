using System;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteCreditoBasico
    {
        public ClienteCreditoBasico()
        {
            Visivel = true;
        }
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalCompras { get; set; }
        public string Detalhe => $"Credito: R${TotalCreditos:0.00#} Vencimento: {DataVencimento:dd/MM/yyyy}";
        public bool Visivel { get; set; }
    }
}
