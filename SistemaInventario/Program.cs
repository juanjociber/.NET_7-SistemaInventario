using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.AccesoDatos.Repositorio;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.UI.Services;
using SistemaInventario.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    //Agergando clase ErrorDescriber para personalizar errores
    .AddErrorDescriber<ErrorDescriber>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Cambiando reglas del password
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    //Permite que como mínimo el password tenga 6 caracteres
    options.Password.RequiredLength = 6;
    //Permte que se repita al menos una vez uno de los caracteres
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Agregando servicio de Unidad de Trabajo
builder.Services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();

//Servicios para paginas RAZOR
builder.Services.AddRazorPages();

//Agregando Servicio
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var options = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.Preserve,
    MaxDepth = 64 // Puedes ajustar este valor seg�n tus necesidades
};

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
    pattern: "{area=Inventario}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
