using AppFidelidade.Dominio._Comum.Entidade;
using System;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteBasicoViewModel
    {
        public ClienteBasicoViewModel()
        {

        }

        public ClienteBasicoViewModel(Entidade.Cliente obj)
        {
            IdCliente = obj.IdCliente;
            Nome = obj.Nome;
            Sobrenome = obj.Sobrenome;
            DataNascimento = obj.DataNascimento;
            TokenId = obj.TokenId;
            Endereco = obj.Endereco;
        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TokenId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
