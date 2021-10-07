using TP3MVVM.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Text;

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

        public static async Task<bool> PutCompteAsync(Compte compte)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(compte), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:5001/api/Compte/{compte.CompteId}", stringContent);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> PostCompteAsync(Compte compte)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(compte), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"https://localhost:5001/api/Compte", stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
