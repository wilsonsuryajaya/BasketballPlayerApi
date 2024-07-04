global using BasketballPlayerApi.Models;
global using Microsoft.EntityFrameworkCore;
using BasketballPlayerApi.Data.Interfaces;
using BasketballPlayerApi.Data.Repositories;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SampleDatabaseContext>(options =>
{
    options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( opt =>
{
    opt.AddPolicy( name: "CorsPolicy", builder =>
    {
        builder.WithOrigins( "http://localhost:4200" )
            .AllowAnyHeader()
            .AllowAnyMethod();
    } );
} );

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors( "CorsPolicy" );

app.MapControllers();

app.Run();
