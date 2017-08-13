using System;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteCreditoBasicoViewModel
    {
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalCompras { get; set; }
    }
}