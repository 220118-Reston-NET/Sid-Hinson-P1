// using System.Text.Json;
// using StoreModel;
// namespace StoreDL
// {

//     /// <summary>
//     /// Products Repository CRUD
//     /// </summary>
//     public class ProductsRepository : IProductsRepo
//     {
//         private string _filepath = "../StoreDL/DB/";
//         private string _jsonString;
//         /// <summary>
//         /// Write Products to DB
//         /// </summary>
//         /// <param name="p_product"></param>
//         /// <returns></returns>
//         public Products AddProducts(Products p_product)
//         {
            
//             string _path = _filepath + "Products.json";
//             //Add an ID at the time of Save
//             // p_product.ProductID = Guid.NewGuid().ToString();
            
//             //Create file
//             List<Products> listofproducts = GetAllProducts();
//             listofproducts.Add(p_product);
//             _jsonString = JsonSerializer.Serialize(listofproducts, new JsonSerializerOptions {WriteIndented = true});
//             File.WriteAllText(_path, _jsonString);
//             Console.WriteLine("New Product was Saved to Database");
//             Console.WriteLine("Press Enter to Continue");
//             Console.ReadLine();
//             return p_product;
//         }
//         /// <summary>
//         /// Grab Products from DB
//         /// </summary>
//         /// <returns></returns>
//         public List<Products> GetAllProducts()
//         {
//             _jsonString = File.ReadAllText(_filepath + "Products.json");
//             return JsonSerializer.Deserialize<List<Products>>(_jsonString);
//         }

//         /// <summary>
//         /// Returns All Products in a Given StoreNumber
//         /// </summary>
//         /// <param name="storeNumber"></param>
//         /// <returns></returns>
//         public List<Products> GetProdbyNameSF(string productName)
//         {
//             string _path = _filepath + "Product.json";
//             List<Products> listofproducts = GetAllProducts();
//             List<Products> listofselected = new List<Products>();
//             for (int i = 0; i < listofproducts.Count(); i++)
//             {
//                 if (listofproducts[i].ProductName.Contains(productName))
//                 {
//                     listofselected.Add(listofproducts[i]);
//                     return listofselected;
//                 }
//                 else
//                 {   
//                     Console.WriteLine("No products to List");
//                     return listofselected;
//                 }

//             }
//             return listofselected;

//         }
//     }
// }