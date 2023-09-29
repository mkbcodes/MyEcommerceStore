global using System.Net.Http.Json;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WasmStore.Client;
using WasmStore.Client.Services.CategoryService;
using WasmStore.Client.Services.ProductService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Default HttpClient for authenticated (authorized) calls
builder.Services.AddHttpClient("WasmStore.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Additional HttpClient for unauthenticated (public) calls
builder.Services.AddHttpClient("WasmStore.PublicClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WasmStore.ServerAPI"));

// Optionally, register the public HttpClient, for basic shop and other page viewing for users without an account.
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WasmStore.PublicClient"));

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
