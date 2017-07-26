namespace AppFidelidade_App_Adm.Models.Regras
{
    public class Regra
    {
        public int IdRegra { get; set; }
        public string Nome { get; set; }
        public int TipoDesconto { get; set; }
        public decimal ValorDaRegra { get; set; }
        public decimal ValorAcimaDe { get; set; }
        public string Detalhes => string.Format("Valor da regra: {0:C} - Gera Credito de: {1}%", ValorAcimaDe, ValorDaRegra);
    }
}
