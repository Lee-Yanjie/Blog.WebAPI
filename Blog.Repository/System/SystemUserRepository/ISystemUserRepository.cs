using Blog.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.System;

namespace Blog.Repository.System.SystemUserRepository
{
    public interface ISystemUserRepository:IBaseRepository<Blog.Model.System.SystemUser>
    {
    }
}
