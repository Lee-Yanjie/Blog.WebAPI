using Blog.Repository.BlogNewsRepository;
using Blog.Repository.System.SystemUser;
using Blog.Repository.System.SystemUserRepository;
using Blog.Service.BlogNewsService;
using Blog.Service.System.SystemUserService;

namespace Blog.WebAPI
{
    public static class IOCExtend
    {
        /// <summary>
        /// 仓储服务器  集中 注册； 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        { 
            services.AddScoped<IBlogNewsRepository, BlogNewsRepository>();
            services.AddScoped<IBlogNewsService, BlogNewsService>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<ISystemUserService, SystemUserService>();

            return services;
        }
         
    }
}
