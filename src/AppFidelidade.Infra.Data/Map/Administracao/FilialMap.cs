using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Administracao
{
    class FilialMap : EntityTypeConfiguration<Dominio.Administracao.Entidade.Filial>
    {
        public FilialMap()
        {
            HasRequired(p => p.Empresa)
                .WithMany(p => p.Filiais)
                .HasForeignKey(p => p.IdEmpresa);
        }
    }
}
