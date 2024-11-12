using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.DataAccessors;
using Serilog;

namespace OutboundCommunication.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build())
            .CreateLogger();

        try
        {
            Log.Information("Starting application");

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();

            ConfigureServices(builder);

            var app = builder.Build();

            ConfigurePipeline(app);

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
            Environment.Exit(1);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigurePipeline(WebApplication app)
    {
        if (!app.Environment.IsDevelopment() || app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.Configure<AppSettings>(builder.Configuration);
        var appSettings = builder.Configuration.Get<AppSettings>();
        ConfigureData(builder.Services, appSettings?.ConnectionStrings?.DbConnection);
        ConfigureHsts(builder.Services);
        ConfigureCors(builder.Services, appSettings);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    private static void ConfigureData(IServiceCollection services, string? coffeeApplicationConnection)
    {
        if (coffeeApplicationConnection == null)
        {
            throw new ArgumentNullException(nameof(coffeeApplicationConnection));
        }

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(coffeeApplicationConnection);
        });

        services.AddScoped<IDataStore, DataStore>();

        services.AddScoped<PatientService>();
        services.AddScoped<DiagnosesService>();
        services.AddScoped<AppointmentService>();
        services.AddScoped<DoctorService>();
        services.AddScoped<MedicationService>();
    }

    private static void ConfigureCors(IServiceCollection services, AppSettings appSettings)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder.AllowCredentials().AllowAnyHeader().AllowAnyMethod()
                             .WithExposedHeaders(HeaderNames.ContentDisposition);

                policyBuilder.WithOrigins(appSettings.AllowedOrigins.ToArray());
            });
        });
    }

    private static void ConfigureHsts(IServiceCollection services)
    {
        services.AddHsts(options =>
        {
            options.Preload = true;
            options.IncludeSubDomains = true;
            options.MaxAge = TimeSpan.FromSeconds(63072000);
        });
    }
}