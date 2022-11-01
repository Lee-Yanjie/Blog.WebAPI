using Blog.Model.BlogNew;
using Blog.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Blog.Repository.BlogNewsRepository
{
    public interface IBlogNewsRepository : IBaseRepository<BlogNews>
    {
        DataTable GetInfoTest();
    }
}
