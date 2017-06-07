using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao
{
    public class AppBase
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        protected AppBase(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public bool Commit()
        {
            return _transacaoRepositorio.Commit();
        }
    }
}
