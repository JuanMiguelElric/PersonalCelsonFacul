using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalTrainer.Data;
using PersonalTrainer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PersonalTrainer.Role;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
var roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();
await RoleSeeder.SeedRolesAsync(roleManager);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Adicionando serviços de identidade
 builder.Services.AddIdentity<ApplicationUser, IdentityRole>() 
    .AddEntityFrameworkStores<ApplicationDbContext>() 
    .AddDefaultTokenProviders(); 

// Adicionando autenticação e autorização
 builder.Services.AddAuthentication(options => 
{ 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(options => 
{ 
    options.TokenValidationParameters = new TokenValidationParameters 
    { 
        ValidateIssuer = true , 
        ValidateAudience = true , 
        ValidateLifetime = true , 
        ValidateIssuerSigningKey = true , 
        ValidIssuer = builder.Configuration[ "Jwt:Issuer" ], 
        ValidAudience = builder.Configuration[ "Jwt:Audience" ], 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[ "Jwt:Key" ])) 
    }; 
}); 

builder.Services.AddAuthorization(opções => 
{ 
    opções.AddPolicy( "AdminOnly" , política => política.RequireRole( "Admin" )); 
    opções.AddPolicy( "UserOnly" , política => política.RequireRole( "Usuário" )); 
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();