using AppFidelidade.Dominio.Cliente.ViewModel;

namespace AppFidelidade.Dominio.Cliente.Interface.Aplicacao
{
    public interface ICompraAplicacao
    {
        ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente);
    }
}
