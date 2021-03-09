using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Next.Request
{
    public class Client
    {

        public static HttpResponseMessage POST<T>(string urlAPI, string metodo, T parametros, string token = null)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlAPI);

            if (token != null)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                return client.PostAsync(metodo, CreateHttpContent<T>(parametros)).GetAwaiter().GetResult();
            }
            catch
            {
                throw new Exception("Erro ao consultar API " + urlAPI + " Método: " + metodo);
            }
        }

        public static HttpResponseMessage GET(string urlAPI, string metodo, Dictionary<string, string> parametros, string token = null)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlAPI);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (token != null)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            foreach (var parametro in parametros)
            {
                client.DefaultRequestHeaders.Add(parametro.Key, parametro.Value);
            }

            try
            {
                return client.GetAsync(metodo).GetAwaiter().GetResult();
            }
            catch
            {

                throw new Exception("Erro ao consultar API " + urlAPI + " Método: " + metodo);
            }

        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                NullValueHandling = NullValueHandling.Ignore
            });
            var retorno = new StringContent(json, Encoding.UTF8, "application/json");
            return retorno;
        }
    }
}
