using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Funcionario
{
    public class FuncionarioMap : EntityTypeConfiguration<Dominio.Funcionario.Funcionario>
    {
        public FuncionarioMap()
        {
            HasMany(p => p.Filiais)
                .WithMany(p => p.Funcionarios)
                .Map(p =>
                    {
                        p.MapLeftKey("IdFilial");
                        p.MapRightKey("IdFuncionario");
                        p.ToTable("FilialFuncionario");
                    }
                );
        }
    }
}
