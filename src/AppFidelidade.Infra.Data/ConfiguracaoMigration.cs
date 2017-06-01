using System.Data.Entity.Migrations;

namespace AppFidelidade.Infra.Data
{
    public class ConfiguracaoMigration : DbMigrationsConfiguration<Contexto>
    {
        public ConfiguracaoMigration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto contexto)
        {
            //Professor professor1 = new Professor();
            //professor1.Nome = "Professor Um";

            //Professor professor2 = new Professor();
            //professor2.Nome = "Professor Dois";

            //Curso curso1 = new Curso();
            //curso1.Numero = "70-480";
            //curso1.Descricao = "Programming in HTML5 with JavaScript and CSS3";
            //curso1.ProfessorLista.Add(professor1);
            //curso1.ProfessorLista.Add(professor2);

            //Curso curso2 = new Curso();
            //curso2.Numero = "70-486";
            //curso2.Descricao = "Developing ASP.NET MVC 4 Web Applications";
            //curso2.ProfessorLista.Add(professor2);

            //context.Cursos.Add(curso1);
            //context.Cursos.Add(curso2);

        }
    }
}
