using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class FilialClienteAplicacao : IFilialClienteAplicacao
    {
        private readonly IFilialClienteRepositorio _filialClienteRepositorio;
        public FilialClienteAplicacao(IFilialClienteRepositorio filialClienteRepositorio)
        {
            _filialClienteRepositorio = filialClienteRepositorio;
        }
    }
}
