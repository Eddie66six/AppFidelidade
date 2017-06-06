using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class EmpresaAplicacao : IEmpresaAplicacao
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        public EmpresaAplicacao(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }
    }
}
