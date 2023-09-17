global using Microsoft.EntityFrameworkCore;
global using WasmStore.Server.Data;
global using WasmStore.Server.Services.ProductService;
global using WasmStore.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ResponseCompression;
using System.Data;
using WasmStore.Server.Models;
using WasmStore.Server.Services.SeedService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DevelopmentLocalConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddSwaggerGen();

        // Tells DI every time that this interface is requested, it should create a new instance of the ProductService class but only once per instance and reused for the duration of a single client request
        builder.Services.AddScoped<ISeedService, SeedService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        { 
            // Password options
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
        
        builder.Services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        builder.Services.AddAuthentication()
            .AddIdentityServerJwt();

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline for development only.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseWebAssemblyDebugging();
            app.UseSwaggerUI();
            // Initiates a block where services can be retrieved from the app's dependency injection container.
            using var scope = app.Services.CreateScope();

            // Retrieves the seed service that implements ISeedService from the scoped services.
            var seeder = scope.ServiceProvider.GetRequiredService<ISeedService>();

            // Calls the seed method to add roles.
            seeder.SeedRolesAsync().Wait();

            // Calls the seed method to add default user and admin temporary accounts for development purposes.
            seeder.SeedDefaultUsersAsync().Wait();

        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseSwagger();
        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
        // Placeholer where my application was.

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();

    }
}