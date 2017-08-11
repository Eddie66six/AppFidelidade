using System;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.Entidade;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.ViewModel;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class CompraAplicacao : AppBase, ICompraAplicacao
    {
        private readonly ICompraRepositorio _compraRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        public CompraAplicacao(IUnitOfWork unitOfWork, ICompraRepositorio compraRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IClienteRepositorio clienteRepositorio) : base(unitOfWork)
        {
            _compraRepositorio = compraRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente, int skip, int take)
        {
            return _compraRepositorio.ObeterBasicoCreditosCliente(idCliente, skip, take);
        }

        public ClienteCreditosRetirarViewModel ObterBasicoCreditoRetirarCliente(int idCliente)
        {
            return _compraRepositorio.ObterBasicoCreditoRetirarCliente(idCliente);
        }
        public CompraBasicoViewModel LancarCompra(LancarCompraViewModel obj)
        {
            if (obj.ValorCompra <= 0)
            {
                DomainEvent.Raise(new DomainNotification("lancarCompra", "A Compra deve ter valor"));
                return null;
            }
            var funcionario = _funcionarioRepositorio.ObterPorId(obj.IdFuncionarioLogado, new string[] { "Filial.Regras" });
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("lancarCompra", "Funcionario nao encontrado"));
                return null;
            }
            var cliente = _clienteRepositorio.ObterPorId(obj.IdCliente, new string[] { "Filiais" });
            if (cliente == null)
            {
                DomainEvent.Raise(new DomainNotification("lancarCompra", "Cliente nao encontrado"));
                return null;
            }
            var compra = funcionario.Filial.InserirCompra(new Compra(obj.ValorCompra, funcionario.Filial, funcionario, cliente, null));
            return Commit() ? new CompraBasicoViewModel(compra) : null;
        }

        public void CreditarCompra(CreditarCompraViewModel obj)
        {
            var compra = _compraRepositorio.ObterPorId(obj.IdCompra, new string[] { "Filial", "Regra" });
            if (compra == null || compra.IdCliente != obj.IdCliente)
            {
                DomainEvent.Raise(new DomainNotification("CreditarCompra", "Compra nao encontrado"));
                return;
            }
            compra.Creditar();
            Commit();
        }
    }
}
