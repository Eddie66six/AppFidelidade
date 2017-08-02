using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.ViewModel;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class CompraAplicacao : ICompraAplicacao
    {
        private readonly ICompraRepositorio _compraRepositorio;
        public CompraAplicacao(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }

        public ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente)
        {
            return _compraRepositorio.ObeterBasicoCreditosCliente(idCliente);
        }
    }
}
