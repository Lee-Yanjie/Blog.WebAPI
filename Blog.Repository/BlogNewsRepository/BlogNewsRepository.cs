using Blog.Model.BlogNew;
using Blog.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.BlogNewsRepository
{
    public class BlogNewsRepository : BaseRepository<BlogNews>, IBlogNewsRepository
    {
        public bool GetInfo()
        {
            this.Context.Ado.GetDataTable($@"select * from table where id=@id and name like @name",new { id = 1, name = "%" +1 + "%" });
            return true;
        }
    }
}
