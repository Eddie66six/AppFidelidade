using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IRegraAplicacao
    {
        Regra ObterPorId(int id);
        RegraListaViewModel ObterPorTipoDesconto(int idFilial, Enum.ETipoDesconto tipo, int take, int skip);
        RegraListaViewModel ObterTodos(int idFilial, int take, int skip);
        RegraListaViewModel ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip);
        RegraBasicoViewModel Adicionar(RegraBasicoViewModel obj);
        RegraBasicoViewModel Atualizar(RegraBasicoViewModel obj);
        void AtivarDesativar(int idRegra, int idFuncionarioLogado);
    }
}
