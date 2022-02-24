using StoreBL;
using StoreDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//******CUSTOMERS
//Provides an object out of the Customers ISQL_CREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQLCRepository>(repo => new SQLCRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<ICustomersBL, CustomersBL>();

//******ORDERS
//Provides an object out of the Order ISQL_OREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQLORepository>(repo => new SQLORepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IOrdersBL, OrdersBL>();

//******INVENTORY
//Provides an object out of the Inventory ISQL_InvREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQLInvRepository>(repo => new SQLInvRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IInventoryBL, InventoryBL>();

//******Products
//Provides an object out of the Products ISQL_PREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQLPRepository>(repo => new SQLPRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IProductsBL, ProductsBL>();

//******StoreFronts
//Provides an object out of the StoreFronts ISQL_SREPO
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQLSRepository>(repo => new SQLSRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IStoreFrontsBL, StoreFrontsBL>();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
