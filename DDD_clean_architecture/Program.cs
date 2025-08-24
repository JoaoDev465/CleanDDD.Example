using DDD_clean_architecture.Commom;

var builder = WebApplication.CreateBuilder(args);
builder.ContextServices();
builder.ControllerServices();
builder.RepositorysServices();
builder.SwaggerDocumentation();

var app = builder.Build();
app.MapControllerInApi();
app.ConfigurationsStringsConnections();

if (app.Environment.IsDevelopment())
{
    app.AppSwaggerFeature();
    Console.WriteLine("This Is Development Environment");
}

app.Run();
