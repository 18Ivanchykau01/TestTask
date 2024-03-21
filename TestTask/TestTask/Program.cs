using Microsoft.EntityFrameworkCore;
using TestTask;
using TestTask.Controllers;
using TestTask.Data;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderService, OrderService>()
    .AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.Services.GetService<OrdersController>().Get();
    await app.Services.GetService<OrdersController>().GetOrders();
    await app.Services.GetService<UsersController>().Get();
    await app.Services.GetService<UsersController>().GetUsers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();