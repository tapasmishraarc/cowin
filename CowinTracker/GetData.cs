using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CowinTracker
{
    class GetData
    {
        //public async Task<Root> GetDetails()
        //{
        //    List<Session> sessions = new List<Session>();
        //    Root root = new Root();
        //    using (var httpClient = new HttpClient())
        //    {

        //        using (var response = await httpClient.GetAsync("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/findByDistrict?district_id=446&date=5-05-2021"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            sessions = JsonConvert.DeserializeObject<List<Session>>(apiResponse);
        //            response.EnsureSuccessStatusCode();
        //            root.sessions = sessions;
        //        }

        //    }
        //    return root;
        //}

        public async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/findByDistrict?district_id=446&date=5-05-2021");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
