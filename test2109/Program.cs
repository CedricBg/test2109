using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.IRepositories;
using DataAccess.Services;
using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using DATA = DataAccess.Models.Employees;
using BusinessAccessLayer.Tools;
using test2109.Tools;
using DataAccess.tools;
using Newtonsoft;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


//DAL
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<IInformationServices, InformationServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();


//BLL
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IInformationService, InformationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddAutoMapper(profiles =>
{ 
    profiles.AddProfile(typeof(AutoMapperProfileBll));
    profiles.AddProfile(typeof(AutoMapperProfileApi));
    profiles.AddProfile(typeof(AutoMapperProfileData));
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SecurityCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"), o=>o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});


builder.Services.AddSwaggerGen(options =>
    options.CustomSchemaIds(type => type.ToString()
));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("tokenValidation").GetSection("issuer").Value,
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("tokenValidation").GetSection("audience").Value,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("tokenValidation").GetSection("secret").Value)),
            ValidateLifetime = true,
              
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminpolicy", policy => policy.RequireRole("Administratif"));
    options.AddPolicy("agentpolicy", policy => policy.RequireRole("agent", "Administratif"));
    options.AddPolicy("authpolicy",  policy => policy.RequireAuthenticatedUser());
}
);



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();

app.Run();
