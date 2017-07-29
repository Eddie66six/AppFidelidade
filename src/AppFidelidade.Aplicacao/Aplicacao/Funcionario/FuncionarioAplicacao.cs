using System;
using AppFidelidade.Dominio.Funcionario.Interface.Applicacao;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Dominio.Funcionario.ViewModel;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Funcionario
{
    public class FuncionarioAplicacao : AppBase, IFuncionarioAplicacao
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioAplicacao(IFuncionarioRepositorio funcionarioRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public Dominio.Funcionario.Entidade.Funcionario ObterPorId(int idFuncionarioLogado, int idFuncionario)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterPorId(idFuncionario, includes);
        }

        public FuncionarioListaViewModel ObterTodosPorFilial(int idFuncionarioLogado, int idFilial, int take, int skip)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterTodosPorFilial(idFuncionarioLogado, idFilial, take, skip, includes);
        }
        public FuncionarioListaViewModel ObterTodosPorEmpresa(int idFuncionarioLogado, int idEmpresa, int take, int skip)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterTodosPorEmpresa(idEmpresa, take, skip, includes);
        }

        public FuncionarioBasicoViewModel Adicionar(FuncionarioBasicoViewModel obj)
        {
            var funcionario = _funcionarioRepositorio.ObterPorId(obj.IdFuncionarioLogado, new string[] { });
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("adicionarFuncionario", "Usuario nao encontrado"));
                return null;
            }
            if (funcionario.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", "Funcionario sem autorização"));
                return null;
            }
            var objSalvo = _funcionarioRepositorio.Adicionar(new Dominio.Funcionario.Entidade.Funcionario(obj.Nome, obj.Tipo, funcionario.IdFilial));
            return Commit() ? new FuncionarioBasicoViewModel(objSalvo) : null;
        }
    }
}
