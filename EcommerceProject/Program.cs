using EcommerceProject.Data;
using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
//Add chain of newtonsoftjson
builder.Services.AddControllers().AddNewtonsoftJson();


var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Db Context configuration: For SQL
//builder.Services.AddDbContext<EcommerceDbContext>(options =>
//    options.UseSqlServer("Server=localhost\\SQLEXPRESS01; Database=EcommerceDb; Trusted_Connection=True; TrustServerCertificate=True")//we can write manually the connection string here
//);

//Db Context Configuration: For MySQL.
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
);

//Add indentity:
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<EcommerceDbContext>()
    .AddDefaultTokenProviders();

//Way to  switch databases:
//update connection string
//update Add Db Context configuration
//Must have to delete Migrations folder before switch from one database to another.
//All packages remain into same version like 8 or 9 or 10. 


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//Add swagger and install :Swashbuckle.AspNetCore(10.2.3)
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

//Add auto mapper:
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

//Dependency Indejtion: using 3 services
//builder.Services.AddSingleton<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();

//builder.Services.AddSingleton<IProductRepository, ProductRepository>();//ignore it
//builder.Services.AddSingleton<IProductRepository, TestRepository>();

//builder.Services.TryAddSingleton<IProductRepository, ProductRepository>();
//builder.Services.TryAddSingleton<IProductRepository, TestRepository>();//ignore it

//builder.Services.AddTransient<IBooksRepository, BooksRepository>();
builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();
builder.Services.AddTransient<IAccountsRepository, AccountsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    //Add swagger
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
