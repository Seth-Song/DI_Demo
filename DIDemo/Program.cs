using DIDemo.Services.Interface;
using DIDemo.Data;
using DIDemo.Services.Interface;
using DIDemo.Services.Interface.IMultipleServiceOneInterface;
using DIDemo.Services.Service;
using DIDemo.Services.Service.MultipleServiceOneInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Service provide 注入方式实现验证
builder.Services.AddTransient</*IServiceA,*/ ServiceA>();
builder.Services.AddTransient<IServiceB, ServiceB>();
builder.Services.AddTransient<IServiceC, ServiceC>();
builder.Services.AddTransient<IServiceD, ServiceD>();
builder.Services.AddTransient<IServiceE, ServiceE>();

builder.Services.AddTransient<IMethodA, MethodA>();


builder.Services.AddTransient<Service1>();
builder.Services.AddTransient<Service2>();
builder.Services.AddTransient(serviceProvider =>
{
    Func<Type, IService> accesor = key =>
    {
        if (key == typeof(Service1))
            return serviceProvider.GetService<Service1>();
        else if (key == typeof(Service2))
            return serviceProvider.GetService<Service2>();
        else
            throw new ArgumentException($"不支持的DI Key: {key}");
    };
    return accesor;

});






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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
