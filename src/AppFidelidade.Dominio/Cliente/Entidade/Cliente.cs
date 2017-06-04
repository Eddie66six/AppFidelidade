using AppFidelidade.Dominio.Administracao.Entidade;
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
        public Cliente(string nome)
        {
            Filiais = new List<FilialCliente>();
            Compras = new List<Compra>();
            Nome = nome;
        }

        #region Metodos
        public decimal ObterCreditoNaFilial(Filial filial)
        {
            var filialCredito = Filiais.FirstOrDefault(p => p.Filial == filial);
            if (filialCredito == null)
                return 0;
            return filialCredito.ValorCreditoNaFilial;
        }
        public bool RetirarCredito(decimal valor, Filial filial)
        {
            var filialCredito = Filiais.FirstOrDefault(p => p.Filial == filial);
            if (filialCredito == null)
                return false;
            filialCredito.RemoverCredito(valor);
            return true;
        }
        public bool InserirCredito(decimal valor, Filial filial)
        {
            var filialCredito = Filiais.FirstOrDefault(p => p.Filial == filial);
            if (filialCredito == null)
                return false;
            filialCredito.InserirCredito(valor);
            return true;
        }
        #endregion
        #region attr
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public List<Compra> Compras { get; private set; }
        public List<FilialCliente> Filiais { get; private set; }
        #endregion
    }
}
