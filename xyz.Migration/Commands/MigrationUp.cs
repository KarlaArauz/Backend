using xyz.Data;
using Enee.IoC.Architecture;
using Oakton;

namespace xyz.Migration.Commands;

public class RunMigrationUp
{
    public class MigrationUp
    {
    }

    [Description("Migration up", Name = "migration-up")]
    public class MigrationUpCommand : OaktonAsyncCommand<MigrationUp>
    {
       

        public override async Task<bool> Execute(MigrationUp input)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var dbSettings = configuration.GetRequiredSection(DbSettings.ConfigurationSectionName)
                .Get<DbSettings>();
            MigrationStartup.RunMigrations(dbSettings.postgresConexion, dbSettings.schemaTables,typeof(DiscoverEfConfigurations).Assembly);
            return true;
        }
    }
}