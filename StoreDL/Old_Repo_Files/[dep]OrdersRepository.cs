// using System.Text.Json;
// using StoreModel;
// namespace StoreDL
// {

//     /// <summary>
//     /// Orders Repository CRUD
//     /// </summary>
//     public class OrdersRepository : IOrdersRepo
//     {
//         private string _filepath = "../StoreDL/DB/";
//         private string _jsonString;
//         /// <summary>
//         /// Write Orders to DB
//         /// </summary>
//         /// <param name="p_order"></param>
//         /// <returns></returns>
//         public Orders AddOrders(Orders p_order)
//         {
//             string _path = _filepath + "Orders.json";
//             //Generate OrderID
//             // p_order.OrderID = Guid.NewGuid().ToString();

//             //Write File
//             List<Orders> listoforders = GetAllOrders();
//             listoforders.Add(p_order);
//             _jsonString = JsonSerializer.Serialize(listoforders, new JsonSerializerOptions {WriteIndented = true});
//             File.WriteAllText(_path, _jsonString);
//             Console.WriteLine("New Order was Saved");
//             Console.WriteLine("Your Order will be billed to your address.");
//             Console.WriteLine("Once payment is received, expect 2-3 weeks for delivery");
//             Console.WriteLine("Thank you for shopping RetroBarbarian Gaming Lair. Follow us on Instagram.");
//             Console.WriteLine("Press Enter to Continue");
//             Console.ReadLine();
//             return p_order;
//         }


//         public Orders AddOrdersHistory(Orders p_order)
//         {
//             string _path = _filepath + "OrdersHistory.json";
//             //Generate OrderID
//             // p_order.OrderID = Guid.NewGuid().ToString();

//             //Write File
//             List<Orders> listoforders = GetAllOrders();
//             listoforders.Add(p_order);
//             _jsonString = JsonSerializer.Serialize(listoforders, new JsonSerializerOptions {WriteIndented = true});
//             File.WriteAllText(_path, _jsonString);
//             Console.WriteLine("Order History was Updated");
//             Console.WriteLine("Press Enter to Continue");
//             Console.ReadLine();
//             return p_order;
//         }
//         /// <summary>
//         /// Grab Orders From DB
//         /// </summary>
//         /// <returns></returns>
//         public List<Orders> GetAllOrders()
//         {
//             _jsonString = File.ReadAllText(_filepath + "Orders.json");
//             return JsonSerializer.Deserialize<List<Orders>>(_jsonString);
//         }


//     }

// }