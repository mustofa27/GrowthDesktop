using System.Text;
using System.Net.Http;
using Growth.Interfaces;
using System.Net.Http.Headers;

namespace Growth.Helper
{
    class ConnectionHelper
    {
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
        public static async void PostToPage(string page, Callback ca, string json)
        {
            // ... Target page.

            // ... Use HttpClient.

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
