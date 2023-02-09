using Blog.Model.BlogNew;
using Blog.WebAPI.Utility.ApiResult;
using Blog.WebAPI.Utility.Http;
using Blog.WebAPI.Utility.JWTOption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {


        private readonly IHttpService _httpService;

        public UtilityController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetPhoneNum(string url, string data)
        {

            int value =  _httpService.HttpClientPost(url, data, out string result);

            if (value<0)
            {
                return ApiResultHelper.Error("发起请求失败！");
            }
            return ApiResultHelper.Success("请求成功");
        }
    }
}
