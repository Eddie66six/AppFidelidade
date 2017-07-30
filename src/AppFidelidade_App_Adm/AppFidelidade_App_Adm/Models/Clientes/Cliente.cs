using System;

namespace AppFidelidade_App_Adm.Models.Clientes
{

    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TokenId { get; set; }
        public Endereco Endereco { get; set; }
        public decimal ValorCreditoNaFilial { get; set; }
        public string Detalhes => $"{Nome} Creditos:{ValorCreditoNaFilial}";
    }
}
