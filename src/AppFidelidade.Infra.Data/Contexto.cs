using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AppFidelidade.Infra.Data
{
    public class Contexto : DbContext
    {
        //(localdb)\\MSSQLLocalDB
        //EDDIE-PC\\SQLEXPRESS
        public Contexto() : base("Data Source=EDDIE-PC\\SQLEXPRESS;Initial Catalog=AppFidelidade;Integrated Security=true")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        //administracao
        public DbSet<Dominio.Administracao.Entidade.Empresa> Empresa { get; set; }
        public DbSet<Dominio.Administracao.Entidade.Filial> Filial { get; set; }
        public DbSet<Dominio.Administracao.Entidade.Regra> Regra { get; set; }
        //cliente
        public DbSet<Dominio.Cliente.Entidade.Cliente> Cliente { get; set; }
        public DbSet<Dominio.Cliente.Entidade.Compra> Compra { get; set; }
        public DbSet<Dominio.Cliente.Entidade.FilialCliente> FiliaisCliente { get; set; }
        //funcionario
        public DbSet<Dominio.Funcionario.Entidade.Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region config geral
            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasMaxLength(150));

            /*Definimos usando reflexão que toda propriedade que contenha
           "Nome da classe" + Id como "CursoId" por exemplo, seja dada como
           chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
               .Where(p => p.Name == "Id" + p.ReflectedType.Name)
               .Configure(p =>
                p.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsKey().HasColumnOrder(0));
            #endregion
            #region map
            //administracao
            modelBuilder.Configurations.Add(new Map.Administracao.EmpresaMap());
            modelBuilder.Configurations.Add(new Map.Administracao.FilialMap());
            modelBuilder.Configurations.Add(new Map.Administracao.RegraMap());
            //cliente
            modelBuilder.Configurations.Add(new Map.Cliente.ClienteMap());
            modelBuilder.Configurations.Add(new Map.Cliente.CompraMap());
            modelBuilder.Configurations.Add(new Map.Cliente.FilialClienteMap());
            //funcionario
            modelBuilder.Configurations.Add(new Map.Funcionario.FuncionarioMap());
            #endregion
        }
    }
}
