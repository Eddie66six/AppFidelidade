namespace AppFidelidade_App_Adm.Models.Compras
{
    public class LancarCompra
    {
        public LancarCompra(decimal valorCompra,int idFuncionarioLogado,int idCliente, decimal? valorDesconto)
        {
            ValorCompra = valorCompra;
            IdFuncionarioLogado = idFuncionarioLogado;
            IdCliente = idCliente;
            ValorDesconto = valorDesconto;
        }
        public decimal ValorCompra { get; set; }
        public int IdFuncionarioLogado { get; set; }
        public int IdCliente { get; set; }
        public decimal? ValorDesconto { get; set; }
    }
}
