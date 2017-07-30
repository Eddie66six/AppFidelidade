using AppFidelidade.Dominio.Cliente.ViewModel;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Interface.Aplicacao
{
    public interface IClienteAplicacao
    {
        Entidade.Cliente ObterPorId(int id);
        List<Entidade.Cliente> ObterPorFilial(int idFilial);
        Entidade.Cliente Adicionar(Entidade.Cliente obj);
        void Atualizar(Entidade.Cliente obj);
        ClienteBasicoViewModel Adicionar(ClienteBasicoViewModel obj);
        ClienteBasicoViewModel ObeterPorTokenId(string tokenId, int idFilial);
    }
}
