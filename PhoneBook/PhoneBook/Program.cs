using Microsoft.EntityFrameworkCore;
using PhoneBook.Client.Pages;
using PhoneBook.Components;
using PhoneBook.Data;
using PhoneBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


//Sqlite ba�lant�s�
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=PhoneBook.db");
});

//Service kay�t
builder.Services.AddScoped<ContactService>();

var app = builder.Build();

//Veritaban�n� otomatik olu�tur
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.InitiliazeDatabase();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PhoneBook.Client._Imports).Assembly);

app.Run();
