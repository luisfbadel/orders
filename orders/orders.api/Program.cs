using Microsoft.EntityFrameworkCore;
using order.application;
using order.infrastructure;
using orders.core.Configuration.DatabaseConfiguration;
using orders.core.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection for services
builder.Services.AddTransient<IOrderServices, OrderService>();

//Dependency Injection for adapters
builder.Services.AddTransient<IOrderAdapter, OrderAdapter>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
