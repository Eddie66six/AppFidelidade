using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Cliente.ViewModel;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Cliente.Interface.Repositorio
{
    public interface ICompraRepositorio : IBaseRepositorio<Entidade.Compra>
    {
        Entidade.Compra ObterPorId(int id, string[] includes);
        List<Entidade.Compra> ObterPorFilial(int idFilial, string[] includes);
        List<Entidade.Compra> ObterPorCliente(int idCliente, string[] includes);
        List<Entidade.Compra> ObterComCreditoPorCliente(int idCliente, string[] includes);
        List<Entidade.Compra> ObterSemCreditoPorCliente(int idCliente, string[] includes);
        ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente);
    }
}