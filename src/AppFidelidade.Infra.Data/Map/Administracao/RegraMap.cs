using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Administracao
{
    class RegraMap : EntityTypeConfiguration<Dominio.Administracao.Entidade.Regra>
    {
        public RegraMap()
        {
            HasRequired(p => p.Filial)
                .WithMany(p => p.Regras)
                .HasForeignKey(p => p.IdFilial);
            HasRequired(p => p.FuncionarioCadastro)
                .WithMany(p => p.RegrasCadastradas)
                .HasForeignKey(p => p.IdFuncionario);
        }
    }
}
