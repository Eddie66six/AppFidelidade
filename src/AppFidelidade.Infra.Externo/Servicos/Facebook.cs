using Facebook;
using System.Dynamic;

namespace AppFidelidade.Infra.Externo.Servicos
{
    public class Facebook
    {
        private FacebookClient client;
        public Facebook(string accessToken)
        {
            client = new FacebookClient(accessToken);
        }
        public bool Compartilhar(string titulo, string linkPage)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.message = titulo;
                parameters.link = linkPage;
                //parameters.picture = "http://loudwire.com/files/2015/04/TEH_MUMMIE-630x420.jpg";
                //parameters.name = "Article Title";
                //parameters.caption = "Caption for the link";
                //parameters.description = "Longer description of the link";
                //parameters.actions = new
                //{
                //    name = "View on Zombo",
                //    link = "http://www.zombo.com",
                //};
                parameters.privacy = new
                {
                    value = "ALL_FRIENDS",
                };
                //parameters.targeting = new
                //{
                //    countries = "US",
                //    regions = "6,53",
                //    locales = "6",
                //};
                var result = client.Post("me/feed", parameters);
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
    }
}
