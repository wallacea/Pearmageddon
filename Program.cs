using Pearmageddon.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();
builder.Services.AddTransient<IPearTypeRepository, DBPearTypeRepository>();
builder.Services.AddTransient<ICanningSessionRepository, InMemoryCanningSessionRepository>();
builder.Configuration.AddJsonFile("PearTypes.json", optional:false, reloadOnChange: true);
builder.Services.Configure<PearmageddonConfig>(builder.Configuration.GetSection("PearmageddonConfig"));
// Add services to the container.
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
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllers();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
