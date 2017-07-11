namespace AppFidelidade_App_Adm.Models
{
    public class Regra
    {
        public int IdRegra { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorGanho { get; set; }
        public string Detalhes => string.Format("Valor da regra: {0:C} - Gera Credito de: {1}%", Valor, ValorGanho);
    }
}