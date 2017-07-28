using System;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.ViewModel;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using AppFidelidade.Dominio.Administracao.Entidade;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class ContratoRepositorio : BaseRepositorio<Contrato>, IContratoRepositorio
    {
        public ContratoRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public Contrato ObterPorIdFilial(int idFilial)
        {
            return Db.Contrato.FirstOrDefault(p=> p.IdFilial == idFilial);
        }

        public ResumoRegraFuncionarioViewModel ObterResumoRegraFuncionario(int idFilial)
        {
            return Db.Contrato.Where(p => p.IdFilial == idFilial && p.DataCancelamento == null)
                .Select(p => new ResumoRegraFuncionarioViewModel
                {
                    FuncionariosCadastrados = p.Filial.Funcionarios.Count(),
                    MaxFuncionariosCadastrados = p.MaxFuncionariosCadastrados,
                    RegrasCadastradas = p.Filial.Regras.Count(),
                    MaxRegrasCadastradas = p.MaxRegrasCadastradas
                }).FirstOrDefault();
        }
    }
}
