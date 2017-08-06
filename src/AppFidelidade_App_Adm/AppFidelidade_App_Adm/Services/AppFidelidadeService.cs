using AppFidelidade_App_Adm.Models;
using AppFidelidade_App_Adm.Models.Clientes;
using AppFidelidade_App_Adm.Models.Compras;
using AppFidelidade_App_Adm.Models.Contratos;
using AppFidelidade_App_Adm.Models.Filiais;
using AppFidelidade_App_Adm.Models.Funcionarios;
using AppFidelidade_App_Adm.Models.Regras;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.Services
{
    public class AppFidelidadeService
    {
        private readonly string _baseUrl = "http://192.168.0.104:3000/";
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
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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

        public async Task<Tuple<Errors, RegrasLista>> ObterRegras(int idFilial, int take, int skip)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/regra/obter?idFilial={idFilial}&take={take}&skip={skip}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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

        public async Task<Tuple<Errors, Regra>> AtualizarRegra(Regra obj)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{_baseUrl}api/v1/regra/atualizar", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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

        public async Task<Tuple<Errors, string>> AtivarDesativarRegra(int idRegra, int idFuncionarioLogado)
        {
            try
            {
                var values = new Dictionary<string, string>{
                    { "idRegra", idRegra.ToString() },
                    { "idFuncionarioLogado", idFuncionarioLogado.ToString() }
                };
                HttpResponseMessage response = await client.PutAsync($"{_baseUrl}api/v1/regra/ativarDesativar", new FormUrlEncodedContent(values));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, string>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, string>(null, result);
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
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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
                if (result == null)
                    return null;
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
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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
        public async Task<Tuple<Errors, Models.Funcionarios.Funcionario>> AtualizarFuncionario(Models.Funcionarios.Funcionario obj)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{_baseUrl}api/v1/funcionario/atualizar", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
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

        public async Task<Tuple<Errors, Cliente>> ObterCliente(string tokenId, int idFilial)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/cliente/obter?tokenId={tokenId}&idFilial={idFilial}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, Cliente>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, Cliente>(null, JsonConvert.DeserializeObject<Cliente>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, Models.Compras.Compra>> LancarCompra(Models.Compras.LancarCompra obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"{_baseUrl}api/v1/compra/lancarCompra", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, Models.Compras.Compra>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, Models.Compras.Compra>(null, JsonConvert.DeserializeObject<Models.Compras.Compra>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, string>> ResgatarCredito(ResgatarCredito obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"{_baseUrl}api/v1/filial/resgatarCredito", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, string>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, string>(null, result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, decimal?>> ObterMaximoCreditoPermitidoParaUso(int idFilial)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/filial/obterMaximoCreditoPermitidoParaUso?idFilial={idFilial}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, decimal?>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, decimal?>(null, Convert.ToDecimal(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Tuple<Errors, InformcoesBasicaFilial>> ObterInformacoesBasicasFilial(int idFilial, int idFuncionarioLogado)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/filial/obterInformacoesBasicasFilial?idFilial={idFilial}&idFuncionarioLogado={idFuncionarioLogado}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, InformcoesBasicaFilial>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, InformcoesBasicaFilial>(null, JsonConvert.DeserializeObject<InformcoesBasicaFilial>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, string>> ExcluirFuncionario(int idFuncionario, int idFuncionarioLogado)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{_baseUrl}api/v1/funcionario/excluir?idFuncionario={idFuncionario}&idFuncionarioLogado={idFuncionarioLogado}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, string>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, string>(null, result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
