using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Mono.Data.VehicledbContext>(x => x.UseSqlServer("Data Source=.\\SQLExpress; Initial catalog=Vehicledb; trusted_connection=yes; Encrypt=False"));

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

var containerBuilder = new ContainerBuilder();
containerBuilder.Populate(app.Services);

var container = containerBuilder.Build();

app.ApplicationServices = new AutofacServiceProvider(container);

app.Run();
