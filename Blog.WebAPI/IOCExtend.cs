using Blog.Repository.BlogNewsRepository;
using Blog.Service.BlogNewsService;

namespace Blog.WebAPI
{
    public static class IOCExtend
    {
        public static IServiceCollection AddCustomIOC(this IServiceCollection services)
        { 
            services.AddScoped<IBlogNewsRepository, BlogNewsRepository>();
            services.AddScoped<IBlogNewsService, BlogNewsService>(); 
            return services;
        }
         
    }
}
