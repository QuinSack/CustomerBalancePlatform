using CustomerBalancePlatform.Models;
using CustomerBalancePlatform.Services.Interfaces;
using CustomerBalancePlatform.Services.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerConnection"))
);

builder.Services.AddDbContext<AuditLogContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuditLogConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuditLogService, AuditLogsService>();

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
