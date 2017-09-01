using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Cliente
{
    public class ClienteMap : EntityTypeConfiguration<Dominio.Cliente.Entidade.Cliente>
    {
        public ClienteMap()
        {
            Property(p => p.UserId).HasMaxLength(500);
        }
    }
}
