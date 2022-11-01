using Blog.Repository.System.SystemUserRepository;
using Blog.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.System.SystemUserService
{
    public class SystemUserService :BaseService<Blog.Model.System.SystemUser>,ISystemUserService
    {
        private readonly ISystemUserRepository _iSystemUserRepository;

        public SystemUserService(ISystemUserRepository iSystemUserRepository)
        {
            base._iBaseRepository = iSystemUserRepository;
            _iSystemUserRepository = iSystemUserRepository;
        }
    }
}
