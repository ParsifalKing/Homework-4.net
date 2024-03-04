using Domain.Models;
using Infrastructure.DataContext;
using Dapper;

namespace Infrastructure.Services;

public class StoreProduct_Service
{

    private readonly DapperContext _context;

    public StoreProduct_Service()
    {
        _context = new DapperContext();
    }

    public void Add(Movement some)
    {
        var sql = @"insert into Store_Product (StoreId,ProductId,Quantity)
                    values(@StoreId,@ProductId,@Quantity);
                   )";
        _context.Connection().Execute(sql, some);
    }

    //  2
    public List<Store_ListProducts> GetStoresProducts()
    {
        var sql = "select id from Stores";
        var stores_id = _context.Connection().Query<int>(sql);
        var sql1 = @"select * from Stores as s where s.id = @Id;
        select * from Products as p
        join Store_Product as sp on sp.ProductId = p.Id
        where sp.StoreId = @Id;
        ";
        var storesWithProducts = new List<Store_ListProducts>();

        foreach (var item in stores_id)
        {
            using (var multiple = _context.Connection().QueryMultiple(sql1, new { Id = item }))
            {
                var storeProducts = new Store_ListProducts();
                storeProducts.Store = multiple.ReadFirst<Store>();
                storeProducts.ListProducts = multiple.Read<Product>().ToList();
                storesWithProducts.Add(storeProducts);
            }
        }
        return storesWithProducts;


    }


}
