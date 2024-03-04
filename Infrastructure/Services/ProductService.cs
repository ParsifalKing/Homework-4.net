using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class ProductService : IService<Product>
{
    private readonly DapperContext _context;

    public ProductService()
    {
        _context = new DapperContext();
    }


    public void Add(Product some)
    {
        var sql = @"insert into Products(ProductName,Quantity,StoreId)
                    values(@ProductName,@Quantity,@StoreId)";
        _context.Connection().Execute(sql, some);

    }

    public void Delete(int id)
    {
        var sql = @"delete from Products where Id = @Id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public List<Product> Get()
    {
        var sql = @"select * from Products";
        return _context.Connection().Query<Product>(sql).ToList();

    }

    public void Update(Product some)
    {
        var sql = @"update Products set ProductName=@ProductName,Quantity=@Quantity,StoreId=@StoreId where Id=@Id";
        _context.Connection().Execute(sql, some);
    }

}
