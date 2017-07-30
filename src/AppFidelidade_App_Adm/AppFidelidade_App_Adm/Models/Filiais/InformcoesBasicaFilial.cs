using System;

namespace AppFidelidade_App_Adm.Models.Filiais
{
    public class InformcoesBasicaFilial
    {
        public string NomeFilial { get; set; }
        public string DescricaoContrato { get; set; }
        public DateTime DataDaAdesao { get; set; }
        public int MaximoFuncionarions { get; set; }
        public int MaximoRegras { get; set; }
        public decimal ValorMensal { get; set; }
    }
}
