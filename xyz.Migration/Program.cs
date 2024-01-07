using xyz.Data;
using xyz.Domain.Personas.Projections;
using Autofac;
using dotenv.net;
using Enee.Core.CQRS.Query;
using Enee.Core.Data.EFCore;
using Enee.IoC.Architecture;
using Enee.IoC.Architecture.Extensions;
using Enee.IoC.Autofac;
using Oakton;

DotEnv.Load();
var domainAssembly = typeof(PersonaDocumento).Assembly;

//var postgresConnection = "Server=localhost;Database=enee;User Id=postgres; Password=P@ssword1234;";
// var config = ConfigBuilder.Conexion(postgresConnection)
//     .SchemaEvents("gestor_eventos")
//     .SchemaDocuments("gestor_documentos")
//     .SchemaTables("gestor_relacional")
//     .Build();


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var dbSettings = configuration.GetRequiredSection(DbSettings.ConfigurationSectionName)
    .Get<DbSettings>();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder=>builder.AddConfiguration(configuration))
    .ApplyOaktonExtensions()
    .ConfigureServices(services =>
    {
        services.Configure<DbSettings>(
            configuration.GetRequiredSection(DbSettings.ConfigurationSectionName)
        );
        
        services.ConfigureDb<CodeFirstDataContext>(null);
        services.SetupMarten(dbSettings, domainAssembly,withAsyncProjectors:true);

    });
    
    hostBuilder.AddAutofac((context, builder) =>
        {
            Console.WriteLine("ENTRO AQUI");
            builder.RegisterModule(new RegisterByInterfaces(domainAssembly, typeof(IProjector<>)));
            builder.RegisterType<DiscoverEfConfigurations>().As<IModelBuildingStrategy>();
        });

    var host= hostBuilder.Build();
    
await host.RunOaktonCommands(args);

