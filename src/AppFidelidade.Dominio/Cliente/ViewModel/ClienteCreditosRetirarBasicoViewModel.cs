using System;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteCreditosRetirarBasicoViewModel
    {
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public long IdCompra { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal Creditos { get; set; }
        public decimal ValorCompra { get; set; }
    }
}
