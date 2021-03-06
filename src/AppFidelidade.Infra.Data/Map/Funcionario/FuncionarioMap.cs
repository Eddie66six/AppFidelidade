﻿using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Funcionario
{
    public class FuncionarioMap : EntityTypeConfiguration<Dominio.Funcionario.Entidade.Funcionario>
    {
        public FuncionarioMap()
        {
            //HasMany(p => p.Filiais)
            //    .WithMany(p => p.Funcionarios)
            //    .Map(p =>
            //        {
            //            p.MapLeftKey("IdFilial");
            //            p.MapRightKey("IdFuncionario");
            //            p.ToTable("FilialFuncionario");
            //        }
            //    );
            HasRequired(p => p.Filial)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(p => p.IdFilial);
            HasOptional(p => p.FuncionarioExclusao)
                .WithMany(p => p.FuncionariosExcluidos)
                .HasForeignKey(p => p.IdFuncionarioExclusao);
        }
    }
}
