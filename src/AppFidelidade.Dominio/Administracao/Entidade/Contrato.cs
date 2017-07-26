using System;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Contrato
    {
        protected Contrato()
        {

        }

        public Contrato(int maxFuncionariosCadastrados, decimal valor)
        {
            MaxFuncionariosCadastrados = maxFuncionariosCadastrados;
            Data = DateTime.UtcNow;
            Descricao = $"Contrato - limite de cadastro de funcionario: {maxFuncionariosCadastrados}";
            Valor = valor;
        }

        #region Attr
        public int IdContrato { get;    private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public int MaxFuncionariosCadastrados { get; private set; }
        public int MaxRegrasCadastradas { get; private set; }
        public string Observacao { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public int? IdFuncionarioCancelamento { get; private set; }
        public virtual Funcionario.Entidade.Funcionario FuncionarioCancelamento { get; private set; }
        public int IdFilial { get; private set; }
        public virtual Filial Filial { get; private set; }
        #endregion
    }
}
