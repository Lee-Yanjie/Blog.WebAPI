using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

namespace Blog.WebAPI.Utility.JWTOption
{
    public static class JWTConfig
    {
        public static IServiceCollection AddJWTConfig(this IServiceCollection services, WebApplicationBuilder builder)
        {
			services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
			{
				var jwtOpt = builder.Configuration.GetSection("JWT").Get<JWTOptions>();
				byte[] keyBytes = Encoding.UTF8.GetBytes(jwtOpt.SigningKey);
				var secKey = new SymmetricSecurityKey(keyBytes);
				x.TokenValidationParameters = new()
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = secKey
				};
			});
			return services;
        }
    }
}
