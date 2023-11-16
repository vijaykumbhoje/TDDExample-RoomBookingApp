using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Core.DataService;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Persistence;
using RoomBookingApp.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> 
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RoomBookingApp.API", Version = "v1" });
});

var conString = "DataSource=:memory:";

var conn = new SqliteConnection(conString);

conn.Open();

builder.Services.AddDbContext<RoomBookingAppDbContext>(opt => opt.UseSqlite(conn));

EnsureDatabaseCreated(conn);

 static void EnsureDatabaseCreated(SqliteConnection conn)
{

    var builder = new DbContextOptionsBuilder<RoomBookingAppDbContext>();
    builder.UseSqlite(conn);

    using var context = new RoomBookingAppDbContext(builder.Options);
    context.Database.EnsureCreated();
   
}

builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
builder.Services.AddScoped<IRoomBookingRequestProcessor, RoomBookingRequestProcessor>();


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

app.Run();
