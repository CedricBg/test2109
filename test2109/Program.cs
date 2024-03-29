using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.IRepositories;
using DataAccess.Services;
using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BusinessAccessLayer.Tools;
using test2109.Tools;
using test2109.Services;

var builder = WebApplication.CreateBuilder(args);


//DAL
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<IInformationServices, InformationServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IPlanningServices, PlanningServices>();
builder.Services.AddScoped<IRapportServices, RapportServices>();
builder.Services.AddScoped<IAgentServices, AgentServices>();
builder.Services.AddScoped<IMessagesServices, MessagesServices>();
builder.Services.AddScoped<IRondesServices, RondesServices>();
builder.Services.AddScoped<TokenService>();


//BLL
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IInformationService, InformationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IPlanningService, PlanningService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IMessagesService, MessagesService>();
builder.Services.AddScoped<IRondesService, RondesService>();

//API
builder.Services.AddSingleton<CacheService>();

builder.Services.AddMemoryCache();



builder.Services.AddAutoMapper(profiles =>
{ 
    profiles.AddProfile(typeof(AutoMapperProfileBll));
    profiles.AddProfile(typeof(AutoMapperProfileApi));
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
    options.AddPolicy("agentpolicy", policy => policy.RequireRole("Agent statique", "Opérations", "Administratif"));
    options.AddPolicy("opspolicy", policy => policy.RequireRole("Opérations", "Administratif"));
    options.AddPolicy("authpolicy",  policy => policy.RequireAuthenticatedUser());
    
} 
);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});


var app = builder.Build();

app.UseResponseCompression();

//// Configure the HTTP request pipeline.
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
