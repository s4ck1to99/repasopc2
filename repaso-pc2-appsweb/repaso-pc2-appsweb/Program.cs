using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using repaso_pc2_appsweb.Logistics.Application.Internal.CommandServices;
using repaso_pc2_appsweb.Logistics.Application.Internal.QueryServices;
using repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;
using repaso_pc2_appsweb.Logistics.Domain.Model.Services;
using repaso_pc2_appsweb.Logistics.Infrastructure.Persistence.EFC.Repositories;
using repaso_pc2_appsweb.Shared.Domain.Repositories;
using repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Repositories;
using repaso_pc2_appsweb.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add Database Connection
var connectionString= builder.Configuration.GetConnectionString("DefaultConnection");

//Configure DB Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if(connectionString !=null)
        if(builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine,LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine,LogLevel.Information)
                .EnableDetailedErrors();
            
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c=>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1",
            Description = "A simple example ASP.NET Core Web API",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Shayne Boyer",
                Email = "contact@api.com"

            },
            License = new OpenApiLicense
            {
                Name = "Use under LICX",
                Url = new Uri("https://example.com/license")
            }
        });
    }
    );


//Configura LowerCase url
builder.Services.AddRouting(options => options.LowercaseUrls = true);
//Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
//Inventory Injection Configuration
builder.Services.AddScoped<IInventoryRepository,InventoryRepository>();
builder.Services.AddScoped<IInventoryQueryService,InventoryQueryService>();
builder.Services.AddScoped<IInventoryCommandService,InventoryCommandService>();
var app = builder.Build();

//Verificar si la base de datos existe
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();