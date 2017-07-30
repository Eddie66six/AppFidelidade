namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class LancarCompraViewModel
    {
        public decimal ValorCompra { get; set; }
        public int IdFuncionarioLogado { get; set; }
        public int IdCliente { get; set; }
        public decimal? ValorDesconto { get; set; }
    }
}
