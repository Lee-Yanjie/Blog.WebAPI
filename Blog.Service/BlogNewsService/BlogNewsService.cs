using Blog.Model.BlogNew;
using Blog.Repository.BlogNewsRepository;
using Blog.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Blog.Service.BlogNewsService
{
    public class BlogNewsService : BaseService<BlogNews>, IBlogNewsService
    {
        private readonly IBlogNewsRepository _iBlogNewsRepository;

        public BlogNewsService(IBlogNewsRepository iBlogNewsRepository)
        {
            base._iBaseRepository = iBlogNewsRepository;
            _iBlogNewsRepository = iBlogNewsRepository;
        }
        public async Task<bool> GetInfo()
        {
           return await _iBlogNewsRepository.DeleteAsync(1);
        }

        public DataTable GetInfoTest()
        {
            return _iBlogNewsRepository.GetInfoTest();
             
        }
    }
}
