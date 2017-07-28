using System;
using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Cliente.ViewModel;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class ClienteAplicacao : AppBase, IClienteAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteAplicacao(IClienteRepositorio clienteRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public ClienteBasicoViewModel Adicionar(ClienteBasicoViewModel obj)
        {
            var cliente = new Dominio.Cliente.Entidade.Cliente(obj.Nome, obj.Sobrenome, obj.DataNascimento, obj.Endereco);
            while (_clienteRepositorio.VerificaSeTokenIdJaExiste(cliente.TokenId))
                cliente.GerarTokenId();
            var dbCliente = _clienteRepositorio.Adicionar(cliente);
            return Commit() ? new ClienteBasicoViewModel(cliente) : null;
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
