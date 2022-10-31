using Blog.Model.BlogNew;
using Blog.Service.BlogNewsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.WebAPI.Utility.ApiResult;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;
        private readonly ILogger<BlogNewsController> _logger;
        public BlogNewsController(ILogger<BlogNewsController> logger, IBlogNewsService iBlogNewsService)
        {
            _logger = logger;
            this._iBlogNewsService = iBlogNewsService;
        }

        /// <summary>
        /// 添加一个博客信息
        /// </summary>
        /// <param name="blogNews"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> CreateBlogNews(BlogNews  blogNews)
        {
            bool data = await _iBlogNewsService.CreateAsync(blogNews);
            return data;
        }
        /// <summary>
        /// 查询所有博客信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        { 
            var data = await _iBlogNewsService.QueryAsync(c => c.Title != null);
            if (data==null) return ApiResultHelper.Error("没有更多的文章");
            return ApiResultHelper.Success(data);
        }
    }
}
