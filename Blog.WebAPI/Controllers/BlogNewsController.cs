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

        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            this._iBlogNewsService = iBlogNewsService;
        }

        [HttpPost]
        public async Task<bool> CreateBlogNews(BlogNews  blogNews)
        {
            bool data = await _iBlogNewsService.CreateAsync(blogNews);
            return data;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        { 
            var data = await _iBlogNewsService.QueryAsync(c => c.Title != null);
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的文章");
            return ApiResultHelper.Success(data);
        }
    }
}
