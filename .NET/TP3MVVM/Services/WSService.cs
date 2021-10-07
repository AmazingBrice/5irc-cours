using TP3MVVM.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace TP3MVVM.Services
{
    class WSService
    {
        static HttpClient client = new HttpClient();

        public static async Task<Compte> GetCompteByMailAsync(string email)
        {
            Compte compte = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/api/Compte/GetCompteByEmail/{email}");
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<Compte>();
            }
            return compte;
        }
    }
}
