using AppFidelidade.Dominio._Comum.Entidade;
using AppFidelidade.Dominio.Administracao.Entidade;
using System;

namespace AppFidelidade.Dominio.Cliente.ViewModel
{
    public class ClienteBasicoViewModel
    {
        public ClienteBasicoViewModel()
        {

        }

        public ClienteBasicoViewModel(Entidade.Cliente obj, Filial filial)
        {
            IdCliente = obj.IdCliente;
            Nome = obj.Nome;
            Sobrenome = obj.Sobrenome;
            DataNascimento = obj.DataNascimento;
            UserId = obj.UserId;
            TokenId = obj.TokenId;
            Endereco = obj.Endereco;
            ValorCreditoNaFilial = filial != null ? obj.ObterCreditoNaFilial(filial) : 0;
        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string TokenId { get; set; }
        public string UserId { get; set; }
        public Endereco Endereco { get; set; }
        public decimal ValorCreditoNaFilial { get; set; }
    }
}
