using Microsoft.EntityFrameworkCore;
using CurriculoApi.Model;
using CurriculoApi.Data;



var myAllowSpecifcOriginns = "myAllowSpecifcOriginns";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(dbOptions =>
{
    dbOptions.UseSqlServer(builder.Configuration.GetConnectionString("dbCon"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecifcOriginns,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("myAllowSpecifcOriginns");

app.UseAuthorization();

app.MapControllers();

app.Run();
