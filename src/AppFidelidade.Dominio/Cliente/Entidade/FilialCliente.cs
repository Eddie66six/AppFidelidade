using AppFidelidade.Dominio.Administracao.Entidade;

namespace AppFidelidade.Dominio.Cliente.Entidade
{
    public class FilialCliente
    {
        protected FilialCliente()
        {

        }

        public FilialCliente(Cliente cliente, Filial filial)
        {
            Cliente = cliente;
            Filial = filial;
        }

        #region Metodos
        #endregion
        #region attr
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdFilial { get; set; }
        public Filial Filial { get; set; }
        #endregion
    }
}
