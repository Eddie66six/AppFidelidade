using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IRegraRepositorio : IBaseRepositorio<Regra>
    {
        Regra ObterPorId(int id, string[] includes);
        RegraListaViewModel ObterPorTipoDesconto(int idFilial, Enum.ETipoDesconto tipo, int take, int skip,string[] includes);
        RegraListaViewModel ObterTodos(int idFilial, int take, int skip, string[] includes);
        RegraListaViewModel ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip, string[] includes);
        int ObterQuantidadeRegrasAtivasCadastradas(int idFilial);
    }
}