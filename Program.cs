using Microsoft.EntityFrameworkCore;
using TiendaRopa.Data;
using TiendaRopa.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TiendaRopaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// HttpClient para consumir la API del profesor
builder.Services.AddHttpClient("ApiProfesor", client =>
{
    client.BaseAddress = new Uri("https://api-udec-pweb-aedec9hxbugye0am.westus3-01.azurewebsites.net/");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
