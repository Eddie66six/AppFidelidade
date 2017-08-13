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
        public decimal ValorCompra { get; set; }
        public string DetalheCompra => $"Total da compra: R${Creditos:0.00#} - {DataCompra:dd/MM/yyyy}";
    }
}
