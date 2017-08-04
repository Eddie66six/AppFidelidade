using AppFidelidade.Dominio.Cliente.ViewModel;

namespace AppFidelidade.Dominio.Cliente.Interface.Aplicacao
{
    public interface ICompraAplicacao
    {
        ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente);
        ClienteCreditosRetirarViewModel ObterBasicoCreditoRetirarCliente(int idCliente);
        CompraBasicoViewModel LancarCompra(LancarCompraViewModel obj);
    }
}
