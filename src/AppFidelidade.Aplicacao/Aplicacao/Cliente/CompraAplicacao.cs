using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class CompraAplicacao : ICompraAplicacao
    {
        private readonly ICompraRepositorio _compraRepositorio;
        public CompraAplicacao(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }
    }
}
