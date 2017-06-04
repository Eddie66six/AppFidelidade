using AppFidelidade.Dominio.Cliente.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Cliente
{
    public class FilialClienteMap : EntityTypeConfiguration<FilialCliente>
    {
        public FilialClienteMap()
        {
            HasKey(p => new { p.IdCliente, p.IdFilial });
            HasRequired(p => p.Cliente)
                .WithMany(p => p.Filiais)
                .HasForeignKey(p => p.IdCliente);
            HasRequired(p => p.Filial)
                .WithMany(p => p.Filiais)
                .HasForeignKey(p => p.IdFilial);
        }
    }
}
