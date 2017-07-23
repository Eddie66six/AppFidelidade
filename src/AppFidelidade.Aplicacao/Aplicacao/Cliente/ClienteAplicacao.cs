using System;
using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class ClienteAplicacao : AppBase, IClienteAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteAplicacao(IClienteRepositorio clienteRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Dominio.Cliente.Entidade.Cliente Adicionar(Dominio.Cliente.Entidade.Cliente obj)
        {
            _clienteRepositorio.Adicionar(obj);
            return Commit() ? obj : null;
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
