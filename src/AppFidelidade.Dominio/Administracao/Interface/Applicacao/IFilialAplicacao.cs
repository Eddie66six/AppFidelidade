using AppFidelidade.Dominio.Administracao.ViewModel;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IFilialAplicacao
    {
        IEnumerable<Entidade.Filial> ObterTodos();
        Entidade.Filial ObterPorId(int id);
        ViewModel.FilialResumoViewModel ObterResumoPorId(int id);
        Entidade.Filial Adicionar(Entidade.Filial obj);
        void Atualizar(Entidade.Filial obj);
        void Remover(int id);
        void ResgatarCredito(ResgatarCreditoViewModel obj);
        decimal ObterMaximoCreditoPermitidoParaUso(int idFilial);
        InformcoesBasicaFilialViewModel ObterInformacoesBasicasFilial(int idFilial, int idFuncionarioLogado);
    }
}
