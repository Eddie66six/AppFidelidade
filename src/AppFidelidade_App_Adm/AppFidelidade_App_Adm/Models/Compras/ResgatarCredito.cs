namespace AppFidelidade_App_Adm.Models.Compras
{
    public class ResgatarCredito
    {
        public ResgatarCredito(decimal valorDesconto, int idCliente, int idFuncionarioLogado)
        {
            ValorDesconto = valorDesconto;
            IdCliente = idCliente;
            IdFuncionarioLogado = idFuncionarioLogado;
        }
        public decimal ValorDesconto { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionarioLogado { get; set; }
    }
}
