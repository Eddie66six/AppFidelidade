using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class EmpresaAplicacao : AppBase, IEmpresaAplicacao
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        public EmpresaAplicacao(IEmpresaRepositorio empresaRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public Empresa Adicionar(Empresa obj)
        {
            _empresaRepositorio.Adicionar(obj);
            return Commit() ? obj : null;
        }

        public void Atualizar(Empresa obj)
        {
            _empresaRepositorio.Atualizar(obj);
            Commit();
        }

        public void Remover(int id)
        {
            var empresa = _empresaRepositorio.ObterPorId(id, new string[0]);
            if(empresa != null)
            {
                empresa.Excluir();
                _empresaRepositorio.Remover(empresa);
            }
            Commit();
        }

        public Empresa ObterPorId(int id)
        {
            string[] includes = { "Filiais" };
            return _empresaRepositorio.ObterPorId(id, includes);
        }

        public IEnumerable<Empresa> ObterTodos(int idEmpresa)
        {
            string[] includes = { "Filiais" };
            return _empresaRepositorio.ObterTodos(idEmpresa,includes);
        }
    }
}
