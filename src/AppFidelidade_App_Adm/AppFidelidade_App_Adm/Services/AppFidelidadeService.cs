using AppFidelidade_App_Adm.Models;
using AppFidelidade_App_Adm.Models.Contratos;
using AppFidelidade_App_Adm.Models.Funcionarios;
using AppFidelidade_App_Adm.Models.Regras;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.Services
{
    public class AppFidelidadeService
    {
        private readonly string _baseUrl = "http://192.168.15.6:3000/";
        private HttpClient client = new HttpClient();
        public AppFidelidadeService(string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Tuple<Errors, FuncionarioLogin>> FuncionarioLogin(string usuario, string senha)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/auth/funcionario?usuario={usuario}&senha={senha}");
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, FuncionarioLogin>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, FuncionarioLogin>(null, JsonConvert.DeserializeObject<FuncionarioLogin>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors,RegrasLista>> ObterRegras(int idFilial, int take, int skip)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/regra/obter?idFilial={idFilial}&take={take}&skip={skip}");
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, RegrasLista>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, RegrasLista>(null, JsonConvert.DeserializeObject<RegrasLista>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, Regra>> AdicionarRegra(Regra obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"{_baseUrl}api/v1/regra/adicionar", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, Regra>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, Regra>(null, JsonConvert.DeserializeObject<Regra>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, FuncionariosLista>> ObterFuncionarios(int idFuncionarioLogado, int idFilial, int take, int skip)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/funcionario/obter/filial?idFuncionarioLogado={idFuncionarioLogado}&idFilial={idFilial}&take={take}&skip={skip}");
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, FuncionariosLista>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, FuncionariosLista>(null, JsonConvert.DeserializeObject<FuncionariosLista>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ResumoRegraFuncionario>> ObterResumoRegraFuncionario(int idFuncionarioLogado, int idFilial)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/contrato/obter?idFuncionarioLogado={idFuncionarioLogado}&idFilial={idFilial}");
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, ResumoRegraFuncionario>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ResumoRegraFuncionario>(null, JsonConvert.DeserializeObject<ResumoRegraFuncionario>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, Models.Funcionarios.Funcionario>> AdicionarFuncionario(Models.Funcionarios.Funcionario obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"{_baseUrl}api/v1/funcionario/adicionar", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                    return new Tuple<Errors, Models.Funcionarios.Funcionario>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, Models.Funcionarios.Funcionario>(null, JsonConvert.DeserializeObject<Models.Funcionarios.Funcionario>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
