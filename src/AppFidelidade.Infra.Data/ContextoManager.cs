using System.Web;

namespace AppFidelidade.Infra.Data
{
    public class ContextoManager
    {
        public Contexto GetContext()
        {
            if (HttpContext.Current.Items["ContextManager.Context"] == null)
            {

                HttpContext.Current.Items["ContextManager.Context"] = new Contexto();
            }

            return (Contexto)HttpContext.Current.Items["ContextManager.Context"];
        }
    }
}
