﻿using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Models;
using AppFidelidade_App_Client.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AppFidelidadeService))]
namespace AppFidelidade_App_Client.Services
{
    public class AppFidelidadeService
    {
        private readonly string _baseUrl = "http://appfidelidadeapi.azurewebsites.net/";
        //private readonly string _baseUrl = "http://192.168.15.8:3000/";
        private HttpClient client = new HttpClient();
        public AppFidelidadeService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Tuple<Errors, ClienteBasico>> ClienteBasico(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/cliente/obter?id={idCliente}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return new Tuple<Errors, ClienteBasico>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteBasico>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteBasico>(null, JsonConvert.DeserializeObject<ClienteBasico>(result));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ClienteCredito>> ObterCreditoBasico(int idCliente, int skip, int take)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/compra/obeterBasicoCreditosCliente?idCliente={idCliente}&skip={skip}&take={take}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return new Tuple<Errors, ClienteCredito>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteCredito>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteCredito>(null, JsonConvert.DeserializeObject<ClienteCredito>(result));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ClienteCreditosRetirar>> ObterCreditoResgatarBasico(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/compra/obterBasicoCreditoRetirarCliente?idCliente={idCliente}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return new Tuple<Errors, ClienteCreditosRetirar>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteCreditosRetirar>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteCreditosRetirar>(null, JsonConvert.DeserializeObject<ClienteCreditosRetirar>(result));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, string>> CreditarCompra(int idCliente, long idCompra)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"{_baseUrl}api/v1/compra/creditarCompra", new StringContent(JsonConvert.SerializeObject(new { IdCliente = idCliente, IdCompra = idCompra, AccessToken = Settings.TokenAuth }), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, string>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, string>(null, result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ClienteBasico>> AdicionarAtualizar(string nome, string userId, string tokenPush)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"{_baseUrl}api/v1/cliente/adicionarAtualizar", new StringContent(JsonConvert.SerializeObject(new { Nome = nome, UserId = userId, TokenPush = tokenPush }), Encoding.UTF8, "application/json"));
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteBasico>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteBasico>(null, JsonConvert.DeserializeObject<ClienteBasico>(result));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async void RemoverTokenPush(int idCliente)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}api/v1/cliente/removerTokenPush?idCliente={idCliente}");
                var response = await client.SendAsync(request);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
