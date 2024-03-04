using Domain.Models;
using Infrastructure.DataContext;
using Dapper;

namespace Infrastructure.Services;

public class StoreService : IService<Store>
{
    private readonly DapperContext _context;

    public StoreService()
    {
        _context = new DapperContext();
    }


    public void Add(Store some)
    {
        var sql = @"insert into Stores (StoreName,Address)
                    values(@StoreName,@Address)";
        _context.Connection().Execute(sql, some);
    }

    public void Delete(int id)
    {
        var sql = @"delete from Stores where Id = @Id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public List<Store> Get()
    {
        var sql = @"select * from Stores";
        return _context.Connection().Query<Store>(sql).ToList();
    }

    public void Update(Store some)
    {
        var sql = @"update Stores set StoreName=@StoreName,Address=@Address where Id=@Id";
        _context.Connection().Execute(sql, some);
    }
}
