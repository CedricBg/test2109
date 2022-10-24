using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.IRepositories;
using DataAccess.Services;
using BusinessAccessLayer.Services;

var builder = WebApplication.CreateBuilder(args);


//DAL
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

//BLL
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SecurityCompanyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
