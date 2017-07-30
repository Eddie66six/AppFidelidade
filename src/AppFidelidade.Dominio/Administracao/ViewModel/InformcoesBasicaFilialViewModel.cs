using AppFidelidade.Dominio.Administracao.Entidade;
using System;
using System.Linq;

namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class InformcoesBasicaFilialViewModel
    {
        public InformcoesBasicaFilialViewModel(Filial obj)
        {
            var contrato = obj.Contratos.First();
            DescricaoContrato = contrato.Descricao;
            DataDaAdesao = contrato.Data;
            MaximoFuncionarions = contrato.MaxFuncionariosCadastrados;
            MaximoRegras = contrato.MaxRegrasCadastradas;
            ValorMensal = contrato.Valor;
            NomeFilial = obj.NomeFantasia;
        }
        public string NomeFilial { get; set; }
        public string DescricaoContrato { get; set; }
        public DateTime DataDaAdesao { get; set; }
        public int MaximoFuncionarions { get; set; }
        public int MaximoRegras { get; set; }
        public decimal ValorMensal { get; set; }
    }
}
