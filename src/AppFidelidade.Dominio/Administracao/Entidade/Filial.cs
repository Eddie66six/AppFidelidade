using AppFidelidade.Dominio.Cliente.Entidade;
using System.Collections.Generic;
using System.Linq;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Filial
    {
        protected Filial()
        {
            Funcionarios = new List<Funcionario.Entidade.Funcionario>();
            Clientes = new List<Cliente.Entidade.Cliente>();
            Regras = new List<Regra>();
            Compras = new List<Compra>();
        }
        public Filial(string cnpj, string razaoSocial,string nomeFantasia, decimal valorCreditoMaximoPermitidoPorUso)
        {
            Funcionarios = new List<Funcionario.Entidade.Funcionario>();
            Clientes = new List<Cliente.Entidade.Cliente>();
            Regras = new List<Regra>();
            Compras = new List<Compra>();

            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            ValorCreditoMaximoPermitidoPorUso = valorCreditoMaximoPermitidoPorUso;
        }

        #region Metodos
        public Funcionario.Entidade.Funcionario AdicionarFuncionario(Funcionario.Entidade.Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
            return funcionario;
        }
        public Regra AdicionarRegra(Regra regra)
        {
            Regras.Add(regra);
            return regra;
        }

        public Regra ObterRegra(decimal valorDaCompra)
        {
            return Regras.FirstOrDefault(p => p.ValorInicial <= valorDaCompra && p.ValorFinal >= valorDaCompra);
        }

        public Compra InserirCompra(Compra compra)
        {
            Compras.Add(compra);
            return compra;
        }
        #endregion
        #region attr
        public int IdFilial { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public decimal ValorCreditoMaximoPermitidoPorUso { get; set; }
        public int IdEmpresa { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public List<Funcionario.Entidade.Funcionario> Funcionarios { get; private set; }
        public List<Cliente.Entidade.Cliente> Clientes { get; private set; }
        public List<Regra> Regras { get; private set; }
        public List<Cliente.Entidade.Compra> Compras { get; private set; }
        public List<FilialCliente> Filiais { get; private set; }
        #endregion
    }
}
