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

        public ClienteBasicoViewModel AdicionarAtualizar(ClienteBasicoViewModel obj)
        {
            //verifica se ja tem cadastro
            var clienteDb = _clienteRepositorio.ObterPorAuth(obj.UserId);
            if (clienteDb != null)
            {
                clienteDb.Atualizar(obj);
                var retorno = new ClienteBasicoViewModel(clienteDb, null);
                retorno.ValorCreditoNaFilial = _clienteRepositorio.ObterTotalCreditosCliente(clienteDb.IdCliente);
                return Commit() ? retorno : null;

            }
            //cria um novo
            var cliente = new Dominio.Cliente.Entidade.Cliente(obj.Nome, obj.Sobrenome, obj.DataNascimento, new Dominio._Comum.Entidade.Endereco(null, null, null, null, null), obj.UserId);
            while (_clienteRepositorio.VerificaSeTokenIdJaExiste(cliente.TokenId))
                cliente.GerarTokenId();
            var dbCliente = _clienteRepositorio.Adicionar(cliente);
            if (Commit())
            {
                var retorno = new ClienteBasicoViewModel(dbCliente, null);
                retorno.ValorCreditoNaFilial = _clienteRepositorio.ObterTotalCreditosCliente(dbCliente.IdCliente);
                return retorno;
            }
            return null;
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
                DomainEvent.Raise(new DomainNotification("ObeterPorTokenId", "Cliente nao encontrado"));
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

        public ClienteBasicoViewModel ObterPorId(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id, new string[] { });
            if (cliente == null)
            {
                DomainEvent.Raise(new DomainNotification("ObterPorId", "Cliente nao encontrado"));
                return null;
            }
            var retorno = new ClienteBasicoViewModel(cliente, null);
            retorno.ValorCreditoNaFilial = _clienteRepositorio.ObterTotalCreditosCliente(id);
            return retorno;
        }
    }
}
