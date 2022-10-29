using SqlSugar;
using SqlSugar.IOC;

namespace Blog.WebAPI
{
    public static class SqlsugarSetup
    {
        public static IServiceCollection AddSqlsugarSetup(this IServiceCollection services, string configuration)
        {
            services.AddSqlSugar(new IocConfig()
            {
                //ConfigId="db01"  多租户用到
                ConnectionString = configuration,// "Data Source=.;Initial Catalog=Blog;Integrated Security=True",
                //configuration[dbName],
                //builder.Configuration.GetConnectionString("SqlServerConn"),
                //"server=.;uid=sa;pwd=sasa;database=SQLSUGAR4XTEST",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true//自动释放
            });
            return services;
        } 
    }
}
