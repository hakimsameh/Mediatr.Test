using Microsoft.AspNetCore.Builder;

namespace MediatrTest.Infrastructure;

public static class DependencyInjection
{
    public static void AddMsSqlInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var connectionString = configuration!.GetConnectionString("DefaultConnection");
        services.AddDbContext<MediatorContext>(
            options => options.UseSqlServer(connectionString,
            op =>
                op.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds))
            .ConfigureWarnings(b => b.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS)));
        services.AddScoped<IItemModelRepository, ItemRepository>()
            .AddScoped<IDataLogRepository, DataLogRepository>()
            .AddScoped<IStoreDataRepository, StoreDataRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
    {
        using var serviceScope =
            app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
        {
            var context = serviceScope.ServiceProvider
                .GetService<MediatorContext>();
            if (context == null) return;
            context.Database
                .Migrate();
        }
    }
}
