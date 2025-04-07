﻿using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FrontEndTiendaOnline.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace FrontEndTiendaOnline.Controllers
{
    public class AdministradorController : ApiController
    {

        private static readonly HttpClient client = new HttpClient();


        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44304/api/Admin";
            var respuestaJson = await GetAsync(apiUrl);
            List<Administrador> listaadministrador = JsonConvert.DeserializeObject<List<Administrador>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaadministrador, loadOptions));
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


        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44304/api/Admin";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var response = await client.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON

            var apiUrlGetcliente = "https://localhost:44304/api/Admin/" + key;
            var respuestacliente = await GetAsync(apiUrlGetcliente = "https://localhost:44304/api/Admin/" + key);
            Administrador administrador = JsonConvert.DeserializeObject<Administrador>(respuestacliente);

            JsonConvert.PopulateObject(values, administrador);

            string jsonString = JsonConvert.SerializeObject(administrador);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44304/api/Admin/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelPeli = "https://localhost:44304/api/Admin/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var respuestaPelic = await client.DeleteAsync(apiUrlDelPeli);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
