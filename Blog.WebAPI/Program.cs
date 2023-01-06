using Blog.WebAPI;
using Blog.WebAPI.Utility.JWTOption;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    //���� jwt  Authorization ���밴ť 
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);
});



#region SqlSugarIOC 
builder.Services.AddSqlsugarSetup(builder.Configuration["ConnectionsString:SqlServerConn"]);
#endregion
//���ע��
builder.Services.AddCustomIOC();  

#region ����JWT��Ϣ
builder.Services.AddJWTConfig(builder);
#endregion




//ʵ�ֿ�������
string[] urls = new[] { "http://localhost:8022" };
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder.WithOrigins(urls)
    .AllowAnyMethod().AllowAnyHeader().AllowCredentials()));



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
