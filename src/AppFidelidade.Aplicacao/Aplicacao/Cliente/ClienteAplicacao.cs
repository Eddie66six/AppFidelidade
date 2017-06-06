using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Cliente
{
    public class ClienteAplicacao : IClienteAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteAplicacao(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
    }
}
