using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using System.Collections.Generic;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class FilialAplicacao : AppBase, IFilialAplicacao
    {
        private readonly IFilialRepositorio _filialRepositorio;
        public FilialAplicacao(IFilialRepositorio filialRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _filialRepositorio = filialRepositorio;
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
    }
}
