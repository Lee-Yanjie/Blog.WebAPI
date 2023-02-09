using Newtonsoft.Json;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace Blog.WebAPI.Utility.Http
{
    public class HttpService : IHttpService
    {
        public int HttpClientPost(string url, string data, out string reslut)
        {
            reslut = "";
            try
            {
                var str = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(str, Encoding.UTF8, "application/json");

                //string url = GetConfigUrl(encode);

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    reslut = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                reslut= ex.Message;
                return  -1;
            }

            return 0;
        }

    }
}
