using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FrontEndTiendaOnline.Models;
using Newtonsoft.Json;

namespace FrontEndTiendaOnline.Controllers
{
    public class CategoriaController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44304/api/Categoria";
            var respuestaJson = await GetAsync(apiUrl);
            List<Categoria> listaCategoria = JsonConvert.DeserializeObject<List<Categoria>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaCategoria, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var client = new HttpClient(handler))
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                var m = e.Message;
                return null;
            }

        }
    }
}
