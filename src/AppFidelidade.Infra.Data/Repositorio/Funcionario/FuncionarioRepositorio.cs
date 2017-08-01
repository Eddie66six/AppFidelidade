using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using AppFidelidade.Dominio.Funcionario.ViewModel;
using AppFidelidade.Dominio.Funcionario.Entidade;
using System;
using System.Data.Entity;

namespace AppFidelidade.Infra.Data.Repositorio.Funcionario
{
    public class FuncionarioRepositorio : BaseRepositorio<Dominio.Funcionario.Entidade.Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public Dominio.Funcionario.Entidade.Funcionario ObterPorId(int idFuncionario, string[] includes)
        {
            var query = Db.Funcionario.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdFuncionario == idFuncionario);
        }

        public FuncionarioListaViewModel ObterTodosPorFilial(int idFuncionarioLogado, int idFilial, int take, int skip, string[] includes)
        {
            var funcionaros = Db.Funcionario.Where(p => p.IdFilial == idFilial && p.IdFuncionario != idFuncionarioLogado);
            return new FuncionarioListaViewModel
            {
                Total = funcionaros.Count(),
                Funcionarios = funcionaros.Select(p=> new FuncionarioBasicoViewModel
                {
                    IdFuncionario = p.IdFuncionario,
                    Nome = p.Nome,
                    Tipo = p.Tipo,
                    IdFilial = p.IdFilial,
                    Usuario = p.Usuario,
                    Senha = p.Senha
                }).OrderBy(p => p.Nome).Skip(skip).Take(take).ToList()
            };
        }
        public FuncionarioListaViewModel ObterTodosPorEmpresa(int idEmpresa, int take, int skip, string[] includes)
        {
            var funcionaros = Db.Funcionario.Where(p => p.Filial.IdEmpresa == idEmpresa);
            return new FuncionarioListaViewModel
            {
                Total = funcionaros.Count(),
                Funcionarios = funcionaros.Select(p => new FuncionarioBasicoViewModel
                {
                    IdFuncionario = p.IdFuncionario,
                    Nome = p.Nome,
                    Tipo = p.Tipo,
                    IdFilial = p.IdFilial
                }).OrderBy(p => p.Nome).Skip(skip).Take(take).ToList()
            };
        }

        public Dominio.Funcionario.Entidade.Funcionario ObterPorLogin(string usuario, string senha, string[] includes)
        {
            return Db.Funcionario.FirstOrDefault(p => p.Usuario == usuario && p.Senha == senha);
        }

        public int ObterQuantidadeFuncionarioAtivosCadastrados(int idFilial)
        {
            return Db.Funcionario.Count(p => p.IdFilial == idFilial);
        }
    }
}
