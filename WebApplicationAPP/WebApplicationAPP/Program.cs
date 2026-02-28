using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

// Repositories en memoria
builder.Services.AddSingleton<ILaboratoryRepository, InMemoryLaboratoryRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IReservationRepository, InMemoryReservationRepository>();

// Servicios de negocio
builder.Services.AddScoped<LaboratoryService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ReservationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();