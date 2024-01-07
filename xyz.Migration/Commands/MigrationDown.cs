using xyz.Data;
using Enee.IoC.Architecture;
using Oakton;

namespace xyz.Migration.Commands;

public class RunMigrationDown
{
    public class MigrationDown
    {
        //[FlagAlias("s")]
        [Description("Optional Cantidad de migraciones a dar rollback desde la ultima migración", Name = "steps")]
        public string Steps { get; set; }
    }

    [Description("Migration Down", Name = "migration-down")]
    public class MigrationDownCommand : OaktonAsyncCommand<MigrationDown>
    {
        public MigrationDownCommand()
        {
            Usage("steps").NoArguments();
            Usage("steps").Arguments(x=>x.Steps);

        }

        public override async Task<bool> Execute(MigrationDown input)
        {
            Console.WriteLine("ALERT");
            
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var dbSettings = configuration.GetRequiredSection(DbSettings.ConfigurationSectionName)
                .Get<DbSettings>();
            MigrationStartup.MigrationDown(
                postgresConexion:dbSettings.postgresConexion, 
                defaultSchema:dbSettings.schemaTables,
                steps: string.IsNullOrWhiteSpace(input.Steps) ?1: int.Parse(input.Steps)  ,
                typeof(DiscoverEfConfigurations).Assembly);
            return true;
        }
    }
}