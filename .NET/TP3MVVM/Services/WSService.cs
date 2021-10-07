using TP3MVVM.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TP3MVVM.Services
{
    class WSService
    {
        static HttpClient client = new HttpClient();

        public static async Task<List<Compte>> GetAllComptesAsync()
        {
            List<Compte> comptes = null;
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/compte");
            if (response.IsSuccessStatusCode)
            {
                comptes = await response.Content.ReadAsAsync<List<Compte>>();
            }
            return comptes;
        }
    }
}
