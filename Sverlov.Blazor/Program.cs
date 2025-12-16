using Sverlov.Blazor.Components;
using Sverlov.Blazor.Services;
using Sverlov.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IProductService, ApiProductService>();


var apiBaseUri = "https://localhost:7002/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUri) });

//builder.Services.AddHttpClient<IProductService, ApiProductService>
//    (opt=> 
//    { 
//        opt.BaseAddress = new Uri("https://localhost:7002/api/automobiles");
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
