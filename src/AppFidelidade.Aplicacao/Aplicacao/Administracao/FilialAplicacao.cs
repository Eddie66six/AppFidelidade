using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.ViewModel;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Cliente.Entidade;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using System;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class FilialAplicacao : AppBase, IFilialAplicacao
    {
        private readonly IFilialRepositorio _filialRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        public FilialAplicacao(IFilialRepositorio filialRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IClienteRepositorio clienteRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _filialRepositorio = filialRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public Filial Adicionar(Filial obj)
        {
            _filialRepositorio.Adicionar(obj);
            return Commit() ? obj : null;
        }

        public void Atualizar(Filial obj)
        {
            _filialRepositorio.Atualizar(obj);
            Commit();
        }

        public void Remover(int id)
        {
            var filial = _filialRepositorio.ObterPorId(id, new string[0]);
            if (filial != null)
            {
                filial.Excluir();
                _filialRepositorio.Remover(filial);
            }
            Commit();
        }

        public Filial ObterPorId(int id)
        {
            string[] includes = { };
            return _filialRepositorio.ObterPorId(id, includes);
        }

        public IEnumerable<Filial> ObterTodos()
        {
            string[] includes = { };
            return _filialRepositorio.ObterTodos(includes);
        }

        public FilialResumoViewModel ObterResumoPorId(int id)
        {
            string[] includes = { };
            var filial = _filialRepositorio.ObterPorId(id, includes);
            var contrato = _filialRepositorio.ObterContratoPorIdFilial(id, includes);
            return new FilialResumoViewModel
            {
                IdFilial = filial.IdFilial,
                Cnpj = filial.Cnpj,
                RazaoSocial = filial.RazaoSocial,
                NomeFantasia = filial.NomeFantasia,
                ValorCreditoMaximoPermitidoPorUso = filial.ValorCreditoMaximoPermitidoPorUso,
                IdContrato = contrato.IdContrato,
                Descricao = contrato.Descricao,
                Data = contrato.Data,
                Valor = contrato.Valor,
                MaxFuncionariosCadastrados = contrato.MaxFuncionariosCadastrados,
                QuantidadeFuncionariosCadastrados = _filialRepositorio.ObterQuantidadeFuncionariosCadastrados(id)
            };
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
        public void ResgatarCredito(ResgatarCreditoViewModel obj)
        {
            if (obj.ValorDesconto <= 0)
            {
                DomainEvent.Raise(new DomainNotification("ResgatarCredito", "O valor do desconto deve ser maior que 0"));
                return;
            }
            var cliente = _clienteRepositorio.ObterPorId(obj.IdCliente, new string[] { "Compras" });
            if (cliente == null)
            {
                DomainEvent.Raise(new DomainNotification("ResgatarCredito", "Cliente nao encontrado"));
                return;
            }
            var funcionario = _funcionarioRepositorio.ObterPorId(obj.IdFuncionarioLogado, new string[] { "Filial" });
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("lancarCompra", "Funcionario nao encontrado"));
                return;
            }
            var efetuadoDesconto = cliente.RetirarCredito(obj.ValorDesconto, funcionario.Filial);
            if(!efetuadoDesconto)
            {
                DomainEvent.Raise(new DomainNotification("lancarCompra", "Cliente não tem creditos nescessario"));
                return;
            }
            Commit();
        }

        public decimal ObterMaximoCreditoPermitidoParaUso(int idFilial)
        {
            var filial = _filialRepositorio.ObterPorId(idFilial, new string[] { });
            if (filial == null)
            {
                DomainEvent.Raise(new DomainNotification("ObterMaximoCreditoPermitidoParaUso", "Filial nao encontrada"));
                return 0;
            }
            return filial.ValorCreditoMaximoPermitidoPorUso;
        }

        public InformcoesBasicaFilialViewModel ObterInformacoesBasicasFilial(int idFilial, int idFuncionarioLogado)
        {
            var filial = _filialRepositorio.ObterPorId(idFilial, new string[] { "Contratos" });
            if (filial == null)
            {
                DomainEvent.Raise(new DomainNotification("ObterInformacoesBasicasFilial", "Filial nao encontrada"));
                return null;
            }
            return new InformcoesBasicaFilialViewModel(filial);
        }
    }
}
