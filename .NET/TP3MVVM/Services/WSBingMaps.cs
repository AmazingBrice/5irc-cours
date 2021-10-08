using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TP3MVVM.Models;

namespace TP3MVVM.Services
{
    class WSBingMaps
    {
        private static WSBingMaps Instance { get; set; }
        private string Key { get; set; }

        private WSBingMaps()
        {
            Key = "Ag7KBEIMrvvjF2Kpz9Ze9UaNNoj1jkizmw-_bxWFpRaLJEXzBGNW-IFl4aHj5jd1";
        }

        public static WSBingMaps GetInstance()
        {
            return Instance ?? new WSBingMaps();
        }

        public async Task<float[]> GetCoordinatesByCompte(Compte compte)
        {
            HttpResponseMessage response = await new HttpClient().GetAsync($"http://dev.virtualearth.net/REST/v1/Locations/FR/{compte.CodePostal}/{compte.Ville}/{compte.Rue}?key={Key}");
            
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadAsAsync<Rootobject>()).resourceSets[0].resources[0].point.coordinates;
            }

            return null;
        }
    }
}
