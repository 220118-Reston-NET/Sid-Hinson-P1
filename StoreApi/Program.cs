using StoreBL;
using StoreDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Provides an object out of the Customers ISQL_REPO
//Call on a delegate to pass a new Customers Repo
//The Dependency on the Implemented repo is the string; we need to add it to the appsettings and call on it
builder.Services.AddScoped<ISQL_CRepository>(repo => new SQL_CRepository(builder.Configuration.GetConnectionString("Reference2DB")));
//Add the Business Layer, and the Concrete Class attached to the Layer
//Make sure using refs are added
builder.Services.AddScoped<ICustomersBL, CustomersBL>();


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
