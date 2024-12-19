using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using passeports_backend.Endpoints;
using passeports_backend.Repository;
using passeports_backend.Services;
using Serilog;
using PostgresContext = passeports_backend.Context.PostgresContext;

public class Program
{
    public static void Main(string[] args)
    {
        Env.Load();
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddScoped<IRepository, PasseportRepository>();
        builder.Services.AddScoped<IPasseportService, PasseportService>();
        builder.Services.AddOpenApi();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Passeports Backend",
                Version = "v1"
            });
        });

// Configuration de Serilog
        var loggerConfiguration = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour);
        var logger = loggerConfiguration.CreateLogger();
        builder.Logging.AddSerilog(logger);

// Configuration de la connexion à la base de données
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La chaîne de connexion à la base de données n'est pas définie.");
        }

        builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connectionString));

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Passeports Backend v1");
                c.RoutePrefix = "swagger";
            });
        }



        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();


// Test de connexion à la base de données
        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connexion réussie à la base de données PostgreSQL.");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la connexion à la base de données : {ex.Message}");
        }

        app.MapGroup("/passeport").MapPasseportEndpoints();

        app.Run();
    }
}
