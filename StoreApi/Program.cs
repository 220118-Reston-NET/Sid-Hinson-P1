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
//Call on a delegate to pass a new Customers Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_CRepository>(repo => new SQL_CRepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
builder.Services.AddScoped<ICustomersBL, CustomersBL>();

//******ORDERS
//Provides an object out of the Order ISQL_OREPO
//Call on a delegate to pass a new Order Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_ORepository>(repo => new SQL_ORepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
builder.Services.AddScoped<IOrdersBL, OrdersBL>();

//******INVENTORY
//Provides an object out of the Inventory ISQL_InvREPO
//Call on a delegate to pass a new Inventory Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_InvRepository>(repo => new SQL_InvRepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
builder.Services.AddScoped<IInventoryBL, InventoryBL>();

//******Products
//Provides an object out of the Products ISQL_PREPO
//Call on a delegate to pass a new Product Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_PRepository>(repo => new SQL_PRepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
builder.Services.AddScoped<IProductsBL, ProductsBL>();

//******StoreFronts
//Provides an object out of the StoreFronts ISQL_SREPO
//Call on a delegate to pass a new StoreFronts Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_SRepository>(repo => new SQL_SRepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
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
