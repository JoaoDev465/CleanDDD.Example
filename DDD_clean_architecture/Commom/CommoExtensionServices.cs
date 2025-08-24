
using Core.Uses_Cases;
using DDD_clean_architecture.API;
using DDD_clean_architecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DDD_clean_architecture.Commom;

public static class CommomExtensionServices
{
   public static void ContextServices(this WebApplicationBuilder builder)
   {
       builder.Services.AddDbContext<Context>(x =>
           x.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
   }

   public static void RepositorysServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICarHandle,CarHandler>();
    }

   public static void ControllerServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(x =>
        {
        });
    }

    public static void SwaggerDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            var InfoScheme = new OpenApiInfo()
            {
                Version = "0.0.1",
                Description = "This is a Release APi, Other features will be avaliable soon",
                Title = "Cars Storage",
            };
            x.SwaggerDoc("Doc",InfoScheme);
        });
    }
}