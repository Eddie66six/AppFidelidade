using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IRegraAplicacao
    {
        Regra ObterPorId(int id);
        List<Regra> ObterPorTipoDesconto(int idFilial, Enum.ETipoDesconto tipo);
        List<Regra> ObterTodos(int idFilial);
        List<Regra> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal);
    }
}
