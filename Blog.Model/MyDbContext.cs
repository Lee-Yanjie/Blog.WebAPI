using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar.IOC;
using Blog.Model.System;
using Blog.Model.BlogNew;

namespace Blog.Model
{
    public class MyDbContext<TEntity> : SimpleClient<TEntity> where TEntity : class, new()
    { 
        public MyDbContext(ISqlSugarClient? context = null) : base(context)
        {
            // base.Context = DbScoped.Sugar;
            base.Context = DbScoped.SugarScope; // SqlSugar.Ioc这样写
            // 创建数据库
            // base.Context.DbMaintenance.CreateDatabase();
            // 创建表
            base.Context.CodeFirst.InitTables(
               typeof(SystemUser),
               typeof(BlogNews)
              );
        }
        
    }
}
