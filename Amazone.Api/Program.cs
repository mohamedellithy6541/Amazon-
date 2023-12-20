using Amazon.Repository;
using Amazon.Repository.Context;
using Amazon.Repository.Data;
using Amazone.Api.Extenstions;
using Amazone.Api.Helper;
using Amozon.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Amazone.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region configur Services
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<StoreContext>(Options =>
              Options.UseSqlServer(builder.Configuration.GetConnectionString("Conf")));

            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerServices();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Mypolice", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().WithMethods(builder.Configuration["FontBaseUrl"]);

                });
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(s =>
            {
                var connection = builder.Configuration.GetConnectionString("redis");
                return ConnectionMultiplexer.Connect(connection);
            });


            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var provide = scope.ServiceProvider;

            var loggerfactory = app.Services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = provide.GetRequiredService<StoreContext>();
                await dbcontext.Database.MigrateAsync();
                await storeContextseed.AddseedAsync(dbcontext);
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }

            #endregion

            #region Configure
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMIdelWare();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCors("Mypolice");
            app.MapControllers();

            app.Run();
            #endregion 
        }
    }
}