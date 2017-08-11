using AppFidelidade.Dominio.Cliente.ViewModel;

namespace AppFidelidade.Dominio.Cliente.Interface.Aplicacao
{
    public interface ICompraAplicacao
    {
        ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente, int skip, int take);
        ClienteCreditosRetirarViewModel ObterBasicoCreditoRetirarCliente(int idCliente);
        CompraBasicoViewModel LancarCompra(LancarCompraViewModel obj);
        void CreditarCompra(CreditarCompraViewModel obj);
    }
}
