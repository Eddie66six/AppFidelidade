using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IFilialRepositorio : IBaseRepositorio<Filial>
    {
        Filial ObterPorId(int id, string[] includes);
        Contrato ObterContratoPorIdFilial(int id, string[] includes);
        List<Filial> ObterTodos(string[] includes);
        int ObterQuantidadeFuncionariosCadastrados(int idFilial);
    }
}