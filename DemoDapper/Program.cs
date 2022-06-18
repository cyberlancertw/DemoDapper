using DemoDapper.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddScoped<ProductFactory, ProductFactory>();
builder.Services.AddScoped<IFactory<Product>, ProductFactory>();
builder.Services.AddScoped<IFactory<Order>, OrderFactory>();
builder.Services.AddControllersWithViews();
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



// builder.Services.AddScoped<ProductFactory, ProductFactory>();
// 則 Controller 用
// private readonly ProductFactory _factory;
// public ProductController(ProductFactory factory)
// {
//     _factory = factory;
// }

// builder.Services.AddScoped<IFactory<Product>, ProductFactory>();
// 則 Controller 用
// private readonly ProductFactory _factory;
// public ProductController(IFactory<Product> factory)
// {
//     _factory = factory as ProductFactory;
// }