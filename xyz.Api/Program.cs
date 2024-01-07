using Autofac;
using dotenv.net;
using Enee.Core.Data.EFCore;
using Enee.IoC.Architecture;
using Enee.IoC.Architecture.Extensions;
using xyz.Data;
using xyz.Domain.Personas.Projections;
using Oakton;

//using Oakton;

DotEnv.Load();
var domainAssembly = typeof(PersonaDocumento).Assembly;
//var postgresConnection = "Server=localhost;Database=enee;User Id=postgres; Password=P@ssword1234;";

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var dbSettings = configuration.GetRequiredSection(DbSettings.ConfigurationSectionName)
    .Get<DbSettings>();

var builder = WebApplication.CreateBuilder(args);
builder.Host.ApplyOaktonExtensions();
// Add services to the container.

builder.Services.AddControllers().AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// var config = ConfigBuilder.Conexion(postgresConnection)
//     .SchemaEvents("gestor_eventos")
//     .SchemaDocuments("gestor_documentos")
//     .SchemaTables("gestor_relacional")
//     .Build();

builder.SetupArchitecture(dbSettings,domainAssembly, ( containerBuilder) =>
{
    containerBuilder.RegisterType<DiscoverEfConfigurations>().As<IModelBuildingStrategy>();
});

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

//app.Run();
await app.RunOaktonCommands(args);