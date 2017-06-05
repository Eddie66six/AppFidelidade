using System;
using System.Collections.Generic;
using AppFidelidade.Dominio._Comum.Interface.Servico;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Dominio.Servico._Comum
{
    public class BaseServico<T>  : IDisposable, IBaseServico<T> where T : class
    {
        private readonly IBaseRepositorio<T> _repositorio;
        public BaseServico(IBaseRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }
        public T Adicionar(T obj)
        {
            return _repositorio.Adicionar(obj);
        }

        public void Atualizar(T obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public T ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
