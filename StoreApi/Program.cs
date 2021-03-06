global using Serilog;
using Microsoft.Extensions.Configuration;
using StoreBL;
using StoreDL;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logs/User.txt") 
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//******CUSTOMERS
//Provides an object out of the Customers ISQL_CREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISqlcRepository>(repo => new SqlcRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<ICustomersBL, CustomersBL>();

//******ORDERS
//Provides an object out of the Order ISQL_OREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISqloRepository>(repo => new SQLoRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IOrdersBL, OrdersBL>();


//******Products
//Provides an object out of the Products ISQL_PREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISqlpRepository>(repo => new SqlpRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IProductsBL, ProductsBL>();

//******StoreFronts
//Provides an object out of the StoreFronts ISQL_SREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISqLsRepository>(repo => new SqlsRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IStoreFrontsBL, StoreFrontsBL>();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Information("User is using the OpenAPI");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
Log.Information("User is exiting the Program");