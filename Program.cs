using Pearmageddon.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pearmageddon.Data;
using Pearmageddon.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PearmageddonContextConnection") ?? throw new InvalidOperationException("Connection string 'PearmageddonContextConnection' not found.");

builder.Services.AddDbContext<PearmageddonContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PearmageddonUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<PearmageddonContext>();
builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();
builder.Services.AddTransient<IPearTypeRepository, FlatFilePearTypeRepository>();
builder.Services.AddTransient<ICanningSessionRepository, InMemoryCanningSessionRepository>();
builder.Configuration.AddJsonFile("PearTypes.json", optional:false, reloadOnChange: true);
builder.Services.Configure<PearmageddonConfig>(builder.Configuration.GetSection("PearmageddonConfig"));

//Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews().AddXmlDataContractSerializerFormatters();

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

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseResponseCaching();
app.UseOutputCache();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllers();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
