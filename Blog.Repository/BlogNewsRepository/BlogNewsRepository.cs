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
    public class BlogNewsRepository : BaseRepository<BlogNews>, IBlogNewsRepository
    {
        public DataTable GetInfoTest()
        {
            return this.Context.Ado.GetDataTable($@"select * from BlogNews"); 
        }
    }
}
