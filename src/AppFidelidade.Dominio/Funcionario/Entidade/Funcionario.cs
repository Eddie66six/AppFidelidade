using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Funcionario.Enum;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario.Entidade
{
    public class Funcionario
    {
        protected Funcionario()
        {
            RegrasCadastradas = new List<Regra>();
            Vendas = new List<Cliente.Entidade.Compra>();
            ContratosCancelados = new List<Contrato>();
            Tipo = ETipoFuncionario.Normal;
        }

        public Funcionario(string nome, ETipoFuncionario tipo = ETipoFuncionario.Normal)
        {
            RegrasCadastradas = new List<Regra>();
            Vendas = new List<Cliente.Entidade.Compra>();
            ContratosCancelados = new List<Contrato>();
            Nome = nome;
            Tipo = tipo;
        }

        #region attr
        public int IdFuncionario { get; private set; }
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public ETipoFuncionario Tipo { get; set; }
        public List<Regra> RegrasCadastradas { get; private set; }
        public int IdFilial { get; private set; }
        public Filial Filial { get; private set; }
        public List<Cliente.Entidade.Compra> Vendas { get; private set; }
        public List<Contrato> ContratosCancelados { get; private set; }
        #endregion
    }
}
