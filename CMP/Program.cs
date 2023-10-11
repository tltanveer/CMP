using CMP.DBContexts;
using CMP.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CMPContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<IClientMSARepository, ClientMSARepository>();
builder.Services.AddTransient<IClientNDARepository, ClientNDARepository>();
builder.Services.AddTransient<IPartnerNDARepository, PartnerNDARepository>();
//builder.AddCors(Options =>
//{
//    Options.AddPolicy("AllowSpecificOrigins",
//        builder =>
//{
//    builder.WithOrigions("https://lively-smoke-06c12f810.3.azurestaticapps.net/")
//    .AllowAnyMethod()
//    .AllowedanyHeader();
//});
//});
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
