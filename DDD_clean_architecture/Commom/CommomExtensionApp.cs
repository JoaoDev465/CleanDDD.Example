namespace DDD_clean_architecture.Commom;

public static class CommomExtensionApp
{
    public static void MapControllerInApi(this WebApplication app)
    {
        app.MapControllers();
    }

    public static void ConfigurationsStringsConnections(this WebApplication app)
    {
        app.Configuration.GetConnectionString("connection");
    }

    public static void AppSwaggerFeature(this WebApplication app)
    {
        app.UseSwaggerUI();
        app.UseSwagger();
    }
    
}