using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Cliente
{
    public class ClienteMap : EntityTypeConfiguration<Dominio.Cliente.Cliente>
    {
        public ClienteMap()
        {
            HasMany(p => p.Filiais)
                .WithMany(p => p.Clientes)
                .Map(p =>
                {
                    p.MapLeftKey("IdFilial");
                    p.MapRightKey("IdCliente");
                    p.ToTable("FilialCliente");
                }
                );
            HasRequired(p => p.Carteira)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdCarteira);
        }
    }
}
