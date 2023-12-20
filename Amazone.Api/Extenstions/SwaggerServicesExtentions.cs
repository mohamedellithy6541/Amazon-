namespace Amazone.Api.Extenstions
{
    public static class SwaggerServicesExtentions
    {
        public static IServiceCollection AddSwaggerServices( this IServiceCollection services) 
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
          services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static void UseSwaggerMIdelWare(this WebApplication app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
