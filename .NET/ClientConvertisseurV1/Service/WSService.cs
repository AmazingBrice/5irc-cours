using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WSConvertisseur.Models;

namespace ClientConvertisseurV1.Service
{
    class WSService
    {
        static HttpClient client = new HttpClient();

        public static async Task<List<Devise>> GetAllDevisesAsync()
        {
            List<Devise> devises = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/devise");
            if (response.IsSuccessStatusCode)
            {
                devises = await response.Content.ReadAsAsync<List<Devise>>();
            }
            return devises;
        }
    }
}
