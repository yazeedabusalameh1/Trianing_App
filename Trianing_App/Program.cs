
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.RepositoryDAL;
using System.Reflection;
//using DAL.Models;
using Trianing_App.BL;
using Trianing_App.BL.BLInterface;
using DAL.Interface;
using Trianing_App.Middleware;
using DAL.Dependencies.DatabaseSetting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));


builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// MongoDB Client
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
    return new MongoClient(settings.ConnectionString);
});





// Register the Business Logic Layer (BL)
builder.Services.AddScoped<ICitizenBLService, CitizenBLService>();
// Register your Mongo Repositories
builder.Services.AddScoped<ICitizenRepositoryDAL, CitizenRepositoryDAL>();
builder.Services.AddScoped<ILogsRepositoriesDAL,LogsRepositoriesDAL>();
builder.Services.AddScoped<ICityRepositoryDAL, CityRepositoryDAL>();
builder.Services.AddScoped<ICityBLService, CityBLService>();
builder.Services.AddScoped<ILogsBLService, LogsBLService>();
builder.Services.Configure<HeaderCheckSrtingModel>(builder.Configuration.GetSection("HeaderCheckSettings"));



builder.Services.AddEndpointsApiExplorer(); // ???? APIs
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<HeaderChackMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

