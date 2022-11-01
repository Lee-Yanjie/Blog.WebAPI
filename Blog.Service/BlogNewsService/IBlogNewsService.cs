﻿using Blog.Model.BlogNew;
using Blog.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Blog.Service.BlogNewsService
{
    public interface IBlogNewsService : IBaseService<BlogNews>
    {
        DataTable GetInfoTest();
    }
}
