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
using AutoMapper;
using WasmStore.Server.Services.CategoryService;
using Duende.IdentityServer.Services;
using Microsoft.Extensions.Options;
using WasmStore.Server.Services.AddressService;
using WasmStore.Server.Services.FavouriteService;
using WasmStore.Server.Services.CartService;
using WasmStore.Server.Services.ReportService;
using WasmStore.Server.Services.TagService;
using WasmStore.Server.Services.OrderService;
using WasmStore.Server.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("AzureConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, options => options.CommandTimeout(120)));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddSwaggerGen();

        // Tells DI every time that this interface is requested, it should create a new instance of the ProductService class but only once per instance and reused for the duration of a single client request
        builder.Services.AddScoped<ISeedService, SeedService>()
        .AddScoped<IProductService, ProductService>()
        .AddScoped<ICategoryService, CategoryService>()
        .AddScoped<IAddressService, AddressService>()
        .AddScoped<IFavouriteService, FavouriteService>()
        .AddScoped<ICartService, CartService>()
        .AddScoped<IReportService, ReportService>()
        .AddScoped<ITagService, TagService>()
        .AddScoped<IOrderService, OrderService>()
        .AddScoped<IUserService, UserService>();

        builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        { 
            // Password options
            options.SignIn.RequireConfirmedAccount = false; // Development only.
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddTransient<IProfileService, CustomProfileService>();

        builder.Services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
            .AddProfileService<CustomProfileService>();



        builder.Services.AddAuthentication()
            .AddIdentityServerJwt();

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline for development only.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
            app.UseWebAssemblyDebugging();
            app.UseSwaggerUI();

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
        // Identity Server Middleware exposes OpenID Connect (OIDC) endpoints.
        app.UseIdentityServer();
        // Responsible for validating request credentials and setting the user on the request context.
        app.UseAuthentication();
        app.UseAuthorization();
        // Placeholer where my application was.

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();

    }
}