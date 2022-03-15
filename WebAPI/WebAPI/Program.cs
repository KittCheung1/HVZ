using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=> {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HvZAPI", Version = "v1" });

   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
c.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<HvZContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi", builder => builder.WithOrigins("http://localhost:3000", "")
     .AllowAnyHeader()
     .AllowAnyMethod());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Detta mirakulöst gör så att docker funkar med databasen på azure
string ManagedNetworkingAppContextSwitch = "Switch.Microsoft.Data.SqlClient.UseManagedNetworkingOnWindows";
AppContext.SetSwitch(ManagedNetworkingAppContextSwitch, true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
}

app.UseHttpsRedirection();

app.UseCors("CorsApi");

app.UseAuthorization();

app.MapControllers();

app.Run();

