using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IRegraRepositorio : IBaseRepositorio<Regra>
    {
        Regra ObterPorId(int id, string[] includes);
        List<Regra> ObterPorTipoDesconto(int idFilial, Enum.ETipoDesconto tipo,string[] includes);
        List<Regra> ObterTodos(int idFilial, string[] includes);
        List<Regra> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, string[] includes);
    }
}