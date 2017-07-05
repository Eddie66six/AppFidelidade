using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Administracao
{
    public class ContratoMap : EntityTypeConfiguration<Dominio.Administracao.Entidade.Contrato>
    {
        public ContratoMap()
        {
            HasOptional(p => p.FuncionarioCancelamento)
                .WithMany(p => p.ContratosCancelados)
                .HasForeignKey(p => p.IdFuncionarioCancelamento);
            HasRequired(p => p.Filial)
                .WithMany(p => p.Contratos)
                .HasForeignKey(p => p.IdFilial);
        }
    }
}
