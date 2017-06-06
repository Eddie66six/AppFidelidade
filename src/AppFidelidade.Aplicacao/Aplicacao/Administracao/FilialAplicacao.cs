using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class FilialAplicacao : IFilialAplicacao
    {
        private readonly IFilialRepositorio _filialRepositorio;
        public FilialAplicacao(IFilialRepositorio filialRepositorio)
        {
            _filialRepositorio = filialRepositorio;
        }
    }
}
