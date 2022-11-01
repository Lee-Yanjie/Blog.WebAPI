using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repository.BaseRepository;
using Blog.Repository.System.SystemUserRepository;

namespace Blog.Repository.System.SystemUser
{
    public class SystemUserRepository: Blog.Repository.BaseRepository.BaseRepository<Blog.Model.System.SystemUser>, ISystemUserRepository
    {
    }
}
