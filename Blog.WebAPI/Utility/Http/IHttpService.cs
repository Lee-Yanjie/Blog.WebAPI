using System.Net;

namespace Blog.WebAPI.Utility.Http
{
    public interface IHttpService
    {
        /// <summary>
        /// 发起HttpClien post请求
        /// </summary>
        int HttpClientPost(string url, string data, out string reslut);

    }
}
