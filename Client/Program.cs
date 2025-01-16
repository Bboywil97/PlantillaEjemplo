using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlantillaEjemplo.Client;
using PlantillaEjemplo.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Asegúrate de que BlazorBootstrap esté correctamente configurado
builder.Services.AddBlazorBootstrap();

// Configura HttpClient con la dirección base del entorno de host
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registra los servicios como singleton
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<ArticulosService>();
builder.Services.AddSingleton<AdscripcionesService>();

await builder.Build().RunAsync();
