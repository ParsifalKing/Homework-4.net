using Domain.Models;
using Infrastructure.DataContext;
using Dapper;

namespace Infrastructure.Services;

public class MovementService
{
    private readonly DapperContext _context;

    public MovementService()
    {
        _context = new DapperContext();
    }

    // 3
    public string Move(Movement some)
    {
        var sql = @"insert into Movements (ProductId,FromStore,ToStore,Quantity,DateOfMovement)
                    values(@ProductId,@FromStore,@ToStore,@Quantity,@DateOfMovement);";
        _context.Connection().Execute(sql, some);

        var sql1 = @"select * from  Store_Product where StoreId = @StoreId and ProductId = @ProductId;";
        var sql2 = @"select * from  Store_Product where StoreId = @StoreId and ProductId = @ProductId;";

        var fromStorePr = _context.Connection().QueryFirstOrDefault<Store_Product>(sql1, new { StoreId = some.FromStore, ProductId = some.ProductId });
        var toStorePr = _context.Connection().QueryFirstOrDefault<Store_Product>(sql2, new { StoreId = some.ToStore, ProductId = some.ProductId });

        if (fromStorePr == null)
        {
            return "From store - Product not found";
        }
        if (toStorePr == null)
        {
            return "To store - Product not found";
        }
        if (fromStorePr.Quantity <= toStorePr.Quantity)
        {
            return "From store have not enough products";
        }

        fromStorePr.Quantity -= some.Quantity;
        var sql3 = @"update Store_Product as sp set Quantity = @Quantity where sp.ProductId = @ProductId and sp.StoreId = @StoreId";
        _context.Connection().Execute(sql3, new { StoreId = some.FromStore, ProductId = some.ProductId, Quantity = fromStorePr.Quantity });

        toStorePr.Quantity += some.Quantity;
        var sql4 = @"update Store_Product as sp set Quantity = @Quantity where sp.ProductId = @ProductId and sp.StoreId = @StoreId";
        _context.Connection().Execute(sql4, new { StoreId = some.ToStore, ProductId = some.ProductId, Quantity = toStorePr.Quantity });
        return "Product moved succesfully!!!";
    }

    public List<MoveType> Get()
    {
        var sql = @"select s.StoreName,s.Address,p.ProductName,p.Quantity as ProductQuantity,
        m.Quantity as MoveQuantity, m.DateOfMovement
        from Movements as m
		join Products as p on m.ProductId = p.Id
        join Stores as s on p.StoreId = s.Id";
        return _context.Connection().Query<MoveType>(sql).ToList();
    }

    public void Delete(int id)
    {
        var sql = @"delete from Movements where Id = @Id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public void Update(Movement some)
    {
        var sql = @"update Movements set ProductId=@ProductId,FromStore=@FromStore,ToStore=@ToStore,Quantity=@Quantity,DateOfMovement=@DateOfMovement where Id=@Id";
        _context.Connection().Execute(sql, some);
    }

    //  4
    public List<MoveType> MovesOfProductByDate(DateTime date)
    {
        var sql = @"select s.StoreName,s.Address,p.ProductName,p.Quantity as ProductQuantity,
        m.Quantity as MoveQuantity, m.DateOfMovement
        from Movements as m
		join Products as p on m.ProductId = p.Id
        join Stores as s on p.StoreId = s.Id
		where DateOfMovement > '2024-01-01'; ";
        return _context.Connection().Query<MoveType>(sql).ToList();
    }

    public List<MoveType> MovesOfProductById(int productId)
    {
        var sql = @"select s.StoreName,s.Address,p.ProductName,p.Quantity as ProductQuantity,m.Quantity as MoveQuantity, m.DateOfMovement
        from Movements as m
		join Products as p on m.ProductId = p.Id
        join Stores as s on p.StoreId = s.Id
		where m.ProductId = p.Id; ";
        return _context.Connection().Query<MoveType>(sql).ToList();
    }



    public void MovesToLessStore()
    {
        var sql = @"select * from Store_Product where quantity <= 3";
        var stProd1 = _context.Connection().Query<Store_Product>(sql).ToList();
        var sql1 = @"select * from Store_Product where quantity > 3";
        var stProd2 = _context.Connection().Query<Store_Product>(sql1).ToList();

        foreach (var item1 in stProd1)
        {
            foreach (var item2 in stProd2)
            {
                if (item1.ProductId == item2.ProductId)
                {
                    var move = new Movement();
                    move.Id = _context.Connection().QueryFirst<int>(@"select Count(*) from Movements");
                    move.ProductId = item1.ProductId;
                    move.FromStore = item2.StoreId;
                    move.ToStore = item1.StoreId;
                    move.Quantity = 1;
                    move.DateOfMovement = DateTime.Now;
                    var moveServ = new MovementService();
                    System.Console.WriteLine(moveServ.Move(move));
                }
            }
        }

    }


}
