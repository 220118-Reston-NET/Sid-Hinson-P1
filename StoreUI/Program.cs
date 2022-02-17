global using Serilog;
using StoreUI;
using StoreDL;
using StoreBL;
using Microsoft.Extensions.Configuration;


//*********************************************
/// <summary>
/// Program Menu Logic Methods
/// </summary>
/// <returns>User String Selections</returns>
//*********************************************

/// <summary>
/// Creates Logger and Config
/// </summary>
/// <returns></returns>
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logs/User.txt") 
    .CreateLogger();

//Read and Obtain from the appsettings.json, needed to implement ConectionStrings
//Import Namespace, Set Basepath
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build(); //Build obj; Var used because method is abstracted

string _connectionString = configuration.GetConnectionString("Ref2DB");


//Main Logo Presentation Layer
StoreMainLogo main = new StoreMainLogo();
main.Display();


/// <summary>
/// Program Runtime Logic
/// </summary>
bool isValid = true;
IMenu mainmenu = new StoreMainMenu();



while(isValid)
{
    mainmenu.MenuDisplay();
    string userInput = mainmenu.UserSelection();


    switch(userInput)
    {
        case "StoreMainMenu":
            Log.Information("Displaying Main Menu to user");
            mainmenu = new StoreMainMenu();
            break;
        //Added in very primtive password protection : Pass is "8675309"
        //Added in For Effect ONLY; to be implemented better in future projects
        case "AdministrationMenu":
            // AdminValidate admin = new AdminValidate();
            // bool uservalidate = admin.ValidateAdminPassword();
            // if (uservalidate == true)
            // {
            //     mainmenu =  new AdministrationMenu();
            // }
            // else
            // {
            //     Console.WriteLine("Incorrect Password");
            //     mainmenu = new StoreMainMenu();
            //     break;
            // }
            mainmenu =  new AdministrationMenu();
            break;
        case "CustomersMenu":
            Log.Information("Displaying Customers Menu to user");
            mainmenu = new CustomersMenu();
            break;
        case "NewCustomersMenu":
            Log.Information("Displaying New Customer Menu to user");
            mainmenu = new NewCustomersMenu(new CustomersBL(new SQL_CRepository(_connectionString)));
            break;
        case "SearchCustomersMenu":
            Log.Information("Displaying Search Results Menu to user");
            mainmenu = new SearchCustomersMenu(new CustomersBL(new SQL_CRepository(_connectionString)));
            break;
        case "NewStoreFrontsMenu":
            Log.Information("Displaying New Store Fronts Menu to user");
            mainmenu = new NewStoreFrontsMenu(new StoreFrontsBL(new SQL_SRepository(_connectionString)));
            break;
        case "SearchStoreFrontsMenu":
            Log.Information("DisplayingSearch Store Fronts Menu to user");
            mainmenu = new SearchStoreFrontsMenu(new StoreFrontsBL(new SQL_SRepository(_connectionString)));
            break;
        case "AddNewProductsMenu":
            Log.Information("Displaying Add New Products Menu to user");
            mainmenu = new AddNewProductsMenu(new ProductsBL(new SQL_PRepository(_connectionString)), new InventoryBL(new SQL_InvRepository(_connectionString)));
            break;
        case "SearchProductsMenu":
            Log.Information("Displaying Search products Menu to user");
            mainmenu = new SearchProductsMenu(new ProductsBL(new SQL_PRepository(_connectionString)));
            break;
        case "AddNewOrderMenu":
            //Uses Quadruple Dependecy Injection to Abstract Access to All BL Methods information 
            Log.Information("Displaying Add New orders Menu to user");
            mainmenu = new AddNewOrderMenu(new OrdersBL(new SQL_ORepository(_connectionString)), new ProductsBL(new SQL_PRepository(_connectionString)), new CustomersBL(new SQL_CRepository(_connectionString)), new InventoryBL(new SQL_InvRepository(_connectionString)));
            break;
        case "AddBusinessTransaction":
            Log.Information("Displaying Add Business Transaction Menu to user");
            mainmenu = new AddBusinessTransaction();
            break;
        case "AddProductsDisplay":
            Log.Information("Displaying Products Display Menu to user");
            mainmenu = new AddProductsDisplay(new ProductsBL(new SQL_PRepository(_connectionString)));
            break;
        case "SearchOrdersCMenu":
            Log.Information("Displaying Search Orders Menu to user");
            mainmenu = new SearchOrdersCMenu(new OrdersBL(new SQL_ORepository(_connectionString)), new CustomersBL(new SQL_CRepository(_connectionString)), new ProductsBL(new SQL_PRepository(_connectionString)));
            break;
        case "AddShopNowMenu":
            //Uses Quadruple Dependecy Injection to Abstract Access to All BL Methods information 
            Log.Information("Displaying Add Shop Now to user");
            mainmenu = new AddShopNowMenu(new OrdersBL(new SQL_ORepository(_connectionString)), new ProductsBL(new SQL_PRepository(_connectionString)), new CustomersBL(new SQL_CRepository(_connectionString)), new InventoryBL(new SQL_InvRepository(_connectionString)),new StoreFrontsBL(new SQL_SRepository(_connectionString)));
            break;
        case "AdminProductMenu":
            //Uses Quadruple Dependecy Injection to Abstract Access to All BL Methods information 
            Log.Information("Displaying Admin Products Menu to user");
            mainmenu = new AdminProductMenu(new ProductsBL(new SQL_PRepository(_connectionString)), new InventoryBL(new SQL_InvRepository(_connectionString)));
            break;
        case "AdminOrderMenu":
            //Uses Quadruple Dependecy Injection to Abstract Access to All BL Methods information 
            Log.Information("Displaying Admin Orders Menu to user");
            mainmenu = new AdminOrderMenu(new OrdersBL(new SQL_ORepository(_connectionString)),  new CustomersBL(new SQL_CRepository(_connectionString)), new StoreFrontsBL(new SQL_SRepository(_connectionString)));
            break;
        case "Exit":
            Log.Information("User has Exited The Program");
            Log.CloseAndFlush(); //To close our logger resource
            isValid = false;
            break;
        default:
            Log.Information("User Input Wrong Selection");
            Console.WriteLine("No Page Found!");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            mainmenu = new StoreMainMenu();
            break;

    }
}

