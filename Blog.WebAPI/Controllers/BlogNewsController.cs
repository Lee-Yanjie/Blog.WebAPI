using Blog.Model.BlogNew;
using Blog.Service.BlogNewsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.WebAPI.Utility.ApiResult;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;
        private readonly ILogger<BlogNewsController> _logger;
        public BlogNewsController(ILogger<BlogNewsController> logger, IBlogNewsService iBlogNewsService)
        {
            _logger = logger;
            this._iBlogNewsService = iBlogNewsService;
        }
        //MD5加密 
        //MD5Helper.MD5Encrypt32(userpwd),


        /// <summary>
        /// 添加一个博客信息
        /// </summary>
        /// <param name="blogNews"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResult>> CreateBlogNews(BlogNews blogNews)
        {
            bool dataResult = await _iBlogNewsService.CreateAsync(blogNews);
            if (!dataResult) return ApiResultHelper.Error("添加失败，服务器发生错误");
            return ApiResultHelper.Success(blogNews);
        }
        /// <summary>
        /// 查询所有博客信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            DataTable dt = _iBlogNewsService.GetInfoTest();
            var data = await _iBlogNewsService.QueryAsync(c => c.Title != null);
            if (data == null) return ApiResultHelper.Error("没有更多的文章");
            return ApiResultHelper.Success(data);
        }
         
    }
}
