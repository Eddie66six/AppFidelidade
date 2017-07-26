namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class RegraBasicoViewModel
    {
        public int IdRegra { get; set; }
        public string Nome { get; set; }
        public Enum.ETipoDesconto TipoDesconto { get; set; }
        public decimal ValorDaRegra { get; set; }
        public decimal ValorAcimaDe { get; set; }
    }
}
