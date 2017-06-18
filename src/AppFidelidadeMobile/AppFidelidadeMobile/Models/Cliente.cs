using System;

namespace AppFidelidadeMobile.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public object[] Compras { get; set; }
        public object[] Filiais { get; set; }
    }
}
