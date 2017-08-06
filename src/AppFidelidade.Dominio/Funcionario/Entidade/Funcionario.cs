using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Funcionario.Enum;
using AppFidelidade.Dominio.Funcionario.ViewModel;
using System;
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
            FuncionariosExcluidos = new List<Funcionario>();
            Tipo = ETipoFuncionario.Normal;
        }

        public Funcionario(string nome, ETipoFuncionario tipo, int idFilial, string usuario, string senha)
        {
            RegrasCadastradas = new List<Regra>();
            Vendas = new List<Cliente.Entidade.Compra>();
            ContratosCancelados = new List<Contrato>();
            FuncionariosExcluidos = new List<Funcionario>();
            Nome = nome;
            Tipo = tipo;
            IdFilial = idFilial;
            Usuario = usuario;
            Senha = senha;
        }
        #region Metodos
        public void Atualizar(FuncionarioBasicoViewModel obj)
        {
            Nome = obj.Nome;
            Tipo = obj.Tipo;
            Usuario = obj.Usuario;
            Senha = obj.Senha;
        }
        public void Excluir(int idFuncionarioLogado)
        {
            DataExclusao = DateTime.UtcNow;
            IdFuncionarioExclusao = idFuncionarioLogado;
        }
        #endregion
        #region attr
        public int IdFuncionario { get; private set; }
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public ETipoFuncionario Tipo { get; private set; }
        public DateTime? DataExclusao { get; private set; }
        public int? IdFuncionarioExclusao { get; private set; }
        public virtual Funcionario FuncionarioExclusao { get; private set; }
        public List<Funcionario> FuncionariosExcluidos { get; set; }
        public List<Regra> RegrasCadastradas { get; private set; }
        public int IdFilial { get; private set; }
        public Filial Filial { get; private set; }
        public List<Cliente.Entidade.Compra> Vendas { get; private set; }
        public List<Contrato> ContratosCancelados { get; private set; }
        #endregion
    }
}
