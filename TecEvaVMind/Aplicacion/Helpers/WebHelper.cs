using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Aplicacion.Monedas;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Aplicacion.Helpers
{
    public class WebHelper
    {
        private string apiURL = "";
        static readonly HttpClient cliente = new HttpClient();
        public WebHelper(string apiURL)
        {
            this.apiURL = apiURL;
        }

        public async Task<string> GetResponse()
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync(apiURL);
                response.EnsureSuccessStatusCode();
                string respuesta = await response.Content.ReadAsStringAsync();
                return respuesta;
            }
            catch (HttpRequestException e)
            {
                //Console.WriteLine($"ups {e.Message}");
                throw new Exception($"Fallo en la llamada a {apiURL}");
            }
        }        
    }
}
