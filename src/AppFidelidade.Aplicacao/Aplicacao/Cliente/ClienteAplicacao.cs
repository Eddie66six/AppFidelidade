using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Cliente.ViewModel;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class ClienteAplicacao : AppBase, IClienteAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFilialRepositorio _filialRepositorio;
        public ClienteAplicacao(IClienteRepositorio clienteRepositorio, IFilialRepositorio filialRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
            _filialRepositorio = filialRepositorio;
        }

        public ClienteBasicoViewModel Adicionar(ClienteBasicoViewModel obj)
        {
            var cliente = new Dominio.Cliente.Entidade.Cliente(obj.Nome, obj.Sobrenome, obj.DataNascimento, obj.Endereco);
            while (_clienteRepositorio.VerificaSeTokenIdJaExiste(cliente.TokenId))
                cliente.GerarTokenId();
            var dbCliente = _clienteRepositorio.Adicionar(cliente);
            return Commit() ? new ClienteBasicoViewModel(cliente, null) : null;
        }

        public Dominio.Cliente.Entidade.Cliente Adicionar(Dominio.Cliente.Entidade.Cliente obj)
        {
            var cliente = _clienteRepositorio.Adicionar(obj);
            return Commit() ? cliente : null;
        }

        public void Atualizar(Dominio.Cliente.Entidade.Cliente obj)
        {
            _clienteRepositorio.Atualizar(obj);
            Commit();
        }

        public ClienteBasicoViewModel ObeterPorTokenId(string tokenId, int idFilial)
        {
            var cliente = _clienteRepositorio.ObeterPorTokenId(tokenId, new string[] { "Compras" });
            if (cliente == null)
            {
                DomainEvent.Raise(new DomainNotification("obterCliente", "Cliente nao encontrado"));
                return null;
            }
            var filial = _filialRepositorio.ObterPorId(idFilial, new string[] { });
            return new ClienteBasicoViewModel(cliente, filial);
        }

        public List<Dominio.Cliente.Entidade.Cliente> ObterPorFilial(int idFilial)
        {
            string[] includes = { };
            return _clienteRepositorio.ObterPorFilial(idFilial, includes);
        }

        public Dominio.Cliente.Entidade.Cliente ObterPorId(int id)
        {
            string[] includes = { };
            return _clienteRepositorio.ObterPorId(id, includes);
        }
    }
}
