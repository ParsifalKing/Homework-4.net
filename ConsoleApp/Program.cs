using Domain.Models;
using Infrastructure.Services;

var prServ = new ProductService();

// try
// {
// var pr = new Product();
// pr.Id = 3;
// pr.ProductName = "Nut";
// pr.Quantity = 1;
// pr.StoreId = 1;

// prServ.Add(pr);
// prServ.Update(pr);

// foreach (var item in prServ.Get())
// {
//     System.Console.Write("Product Id : ");
//     System.Console.WriteLine(item.Id);
//     System.Console.Write("Product Name : ");
//     System.Console.WriteLine(item.ProductName);
//     System.Console.Write("Product quantity : ");
//     System.Console.WriteLine(item.Quantity);
//     System.Console.Write("Product store : ");
//     System.Console.WriteLine(item.StoreId);
//     System.Console.WriteLine("-----------------------");
// }



// var store = new Store();
// store.Id = 3;
// store.StoreName = "Last store";
// store.Address = "Bokhtar";
// var storeServ = new StoreService();
// storeServ.Add(store);

// foreach (var item in storeServ.Get())
// {
//     System.Console.Write("Store Id : ");
//     System.Console.WriteLine(item.Id);
//     System.Console.Write("Store Name : ");
//     System.Console.WriteLine(item.StoreName);
//     System.Console.Write("Store address : ");
//     System.Console.WriteLine(item.Address);
//     System.Console.WriteLine("-----------------------");
// }


var moveServ = new MovementService();
// foreach (var item in moveServ.MovesOfProductByDate(new DateTime(2024, 01, 01)))
// {
//     System.Console.WriteLine(item.StoreName);
//     System.Console.WriteLine(item.Address);
//     System.Console.WriteLine(item.ProductName);
//     System.Console.WriteLine(item.ProductQuantity);
//     System.Console.WriteLine(item.MoveQuantity);
//     System.Console.WriteLine(item.DateOfMovement);
//     System.Console.WriteLine("--------------------");
// }
// System.Console.WriteLine();


// foreach (var item in moveServ.MovesOfProductById(1))
// {
//     System.Console.WriteLine(item.StoreName);
//     System.Console.WriteLine(item.Address);
//     System.Console.WriteLine(item.ProductName);
//     System.Console.WriteLine(item.ProductQuantity);
//     System.Console.WriteLine(item.MoveQuantity);
//     System.Console.WriteLine(item.DateOfMovement);
//     System.Console.WriteLine("--------------------");
// }


// foreach (var item in moveServ.Move())
// {
//     System.Console.WriteLine(item.StoreName);
//     System.Console.WriteLine(item.Address);
//     System.Console.WriteLine(item.ProductName);
//     System.Console.WriteLine(item.ProductQuantity);
//     System.Console.WriteLine(item.MoveQuantity);
//     System.Console.WriteLine(item.DateOfMovement);
//     System.Console.WriteLine("--------------------");
// }

// var storePr_Serv = new StoreProduct_Service();
// foreach (var item in storePr_Serv.GetStoresProducts())
// {
//     System.Console.Write("   Store id : ");
//     System.Console.WriteLine(item.Store.Id);
//     System.Console.Write("   Store name : ");
//     System.Console.WriteLine(item.Store.StoreName);
//     System.Console.Write("   store address : ");
//     System.Console.WriteLine(item.Store.Address);
//     foreach (var products in item.ListProducts)
//     {
//         System.Console.Write("product id : ");
//         System.Console.WriteLine(products.Id);
//         System.Console.Write("product name : ");
//         System.Console.WriteLine(products.ProductName);
//         System.Console.Write("product quantuty : ");
//         System.Console.WriteLine(products.Quantity);
//         System.Console.WriteLine("-------------------");
//     }
//     System.Console.WriteLine();
// }

// var move = new Movement();
// move.Id = 1;
// move.ProductId = 2;
// move.FromStore = 2;
// move.ToStore = 1;
// move.Quantity = 3;
// move.DateOfMovement = DateTime.Now;
// System.Console.WriteLine(moveServ.Move(move));

moveServ.MovesToLessStore();
// }




// catch (System.Exception)
// {

//     System.Console.WriteLine("Warning!!! Exception");
// }

