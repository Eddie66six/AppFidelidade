using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class RegraAplicacao : IRegraAplicacao
    {
        private readonly IRegraRepositorio _regraRepositorio;
        public RegraAplicacao(IRegraRepositorio regraRepositorio)
        {
            _regraRepositorio = regraRepositorio;
        }
    }
}
