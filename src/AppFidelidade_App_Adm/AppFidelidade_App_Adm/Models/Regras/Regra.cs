namespace AppFidelidade_App_Adm.Models.Regras
{
    public class Regra
    {
        public Regra()
        {

        }
        public Regra(int idFuncionarioLogado)
        {
            IdFuncionarioLogado = idFuncionarioLogado;
            Inativo = false;
        }
        public int IdRegra { get; set; }
        public string Nome { get; set; }
        public int TipoDesconto => 2;
        public decimal ValorDaRegra { get; set; }
        public decimal ValorAcimaDe { get; set; }
        public bool Inativo { get; set; }
        public int IdFuncionarioLogado { get; set; }
        public string Detalhes => string.Format("Valor acima de: {0:C} - Gera Credito de: {1}%", ValorAcimaDe, ValorDaRegra);
    }
}
