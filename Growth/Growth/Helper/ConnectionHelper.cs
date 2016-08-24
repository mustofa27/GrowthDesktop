using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Growth.Interfaces;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Growth.Helper
{
    class ConnectionHelper
    {
        private class Test
        {
            public int kd_user;
            public string id_gcm;
            public Test(int kd_user,string id_gcm)
            {
                this.id_gcm = id_gcm;
                this.kd_user = kd_user;
            }
        }
        public static async void DownloadPageAsync(string page, Callback ca)
        {
            // ... Target page.

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null)
                {
                    ca.Done(result);
                }
                //return "";
            }
        }
        public static async void PostToPage(string page, Callback ca)
        {
            // ... Target page.

            // ... Use HttpClient.
            string json = JsonConvert.SerializeObject(new Test(1,"testing 123"));

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await client.PostAsync(page, new StringContent(json,Encoding.UTF8,"application/json")))
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    string result = await content.ReadAsStringAsync();

                    // ... Display the result.
                    if (result != null)
                    {
                        ca.Done(result);
                    }
                    //return "";
                }
            }
        }
    }
}
