using AppFidelidade.Dominio._Comum.Entidade;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Cliente.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class Cliente
    {
        protected Cliente()
        {
            Filiais = new List<FilialCliente>();
            Compras = new List<Compra>();
        }
        public Cliente(string nome, string sobrenome, DateTime? dataNascimento, Endereco endereco, string userId)
        {
            Filiais = new List<FilialCliente>();
            Compras = new List<Compra>();
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            DataCadastro = DateTime.UtcNow;
            UserId = userId;
            GerarTokenId();
        }
        #region Metodos
        public void GerarTokenId()
        {
            var guid = Guid.NewGuid();
            // Uses base64 encoding the guid.(Or  ASCII85 encoded)
            // But not recommend using Hex, as it is less efficient.
            TokenId = Convert.ToBase64String(guid.ToByteArray());
        }
        public decimal ObterCreditoNaFilial(Filial filial)
        {
            var creditoCompras = Compras.Where(p => p.Filial == filial && p.DataRetiradaCredito .HasValue && p.ValorRestanteCredito > 0);
            if (creditoCompras == null)
                return 0;
            return creditoCompras.Sum(p => p.ValorRestanteCredito);
        }
        public bool RetirarCredito(decimal valor, Filial filial)
        {
            if (ObterCreditoNaFilial(filial) < valor)
                return false;
            foreach (var item in Compras.Where(p => p.Filial == filial && p.DataRetiradaCredito.HasValue && p.ValorRestanteCredito > 0))
            {
                var credito = valor - item.ValorRestanteCredito;
                if (credito <= 0)
                {
                    item.RetirarCredito(valor);
                    break;
                }
                else
                {
                    item.RetirarCredito(item.ValorRestanteCredito);
                }

            }
            return true;
        }

        public void Atualizar(ClienteBasicoViewModel obj)
        {
            Nome = obj.Nome;
            Sobrenome = obj.Sobrenome;
            DataNascimento = obj.DataNascimento;
            UserId = obj.UserId;
            //Endereco = obj.Endereco;
        }
        #endregion
        #region attr
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string TokenId { get; private set; }
        public string UserId { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Compra> Compras { get; private set; }
        public List<FilialCliente> Filiais { get; private set; }
        #endregion
    }
}
