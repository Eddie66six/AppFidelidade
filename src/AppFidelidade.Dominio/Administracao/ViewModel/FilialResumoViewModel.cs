using System;

namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class FilialResumoViewModel
    {
        public int IdFilial { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public decimal ValorCreditoMaximoPermitidoPorUso { get; set; }
        public int IdContrato { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int MaxFuncionariosCadastrados { get; set; }
        public int QuantidadeFuncionariosCadastrados { get; set; }
    }
}
