using SqlSugar.IOC;
using Microsoft.Extensions.Configuration;
using Blog.WebAPI;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region SqlSugarIOC 
builder.Services.AddSqlsugarSetup(builder.Configuration["ConnectionsString:SqlServerConn"]);
#endregion
//¶à¸ö×¢Èë
builder.Services.AddCustomIOC();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
