using DesingPattern.Models.Data;
using DesingPattern.Repository;
using DesingPatterns_AspNet.Configuration;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;
using Tools.Generator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Se Inyecta la dependencia para el patron SINGLETON.
builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig"));

// OBJETO CON PATRON DE DISEÑO REPOSITORY
builder.Services.AddDbContext<DesignPatternsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Se Inyecta la dependencia para factory
builder.Services.AddTransient((factory) => { 
    decimal localPercentage = builder.Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage");
    return new LocalEarnFactory(localPercentage);
});

builder.Services.AddTransient((factory) => {

    decimal foreignPercentage = builder.Configuration.GetSection("MyConfig").GetValue<decimal>("ForeignPercentage");
    decimal extra = builder.Configuration.GetSection("MyConfig").GetValue<decimal>("Extra");

    return new ForeignEarnFactory(foreignPercentage, extra);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<GeneratorConcreteBuilder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

