using Chess.Rules;
using Chess.Rules.Taslar;
using Web.UI.Configuration;
using Web.UI.Entities.MongoDb;
using Web.UI.Repositories.Abstract;
using Web.UI.Repositories.Concrete;
using Web.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("SatrancDatabase"));

builder.Services.AddScoped<TahtaService>();
builder.Services.AddSingleton(typeof(IMongoDbRepository<TahtaEntity>), typeof(MongoDbRepository<TahtaEntity>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Satranc/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transactions}/{action=Login}/{id?}");

app.UseSession();

app.Run();
