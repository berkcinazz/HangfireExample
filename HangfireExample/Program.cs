using Hangfire;
using HangfireExample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(conf => conf.UseSqlServerStorage(string.Format(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HangfireLogs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<HangfireJob>(x => x.SendWelcome("startup"),"*/20 * * * * *");//Every 20 seconds
RecurringJob.AddOrUpdate<HangfireJob>(x => x.SendVersionOfHangFire(),"*/20 * * * * *");//Every 20 seconds


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
