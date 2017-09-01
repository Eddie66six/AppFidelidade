using System;

namespace AppFidelidade_App_Client.Models
{
    public class ClienteBasico
    {
        public ClienteBasico()
        {

        }
        public ClienteBasico(string nome, string userId)
        {
            Nome = nome;
            UserId = userId;
        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string TokenId { get; set; }
        public string UserId { get; set; }
        //public Endereco Endereco { get; set; }
        public decimal ValorCreditoNaFilial { get; set; }
        public string NomeCompleto => $"{Nome} {Sobrenome}";
    }
}
