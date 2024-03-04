namespace Domain.Models;

public class MoveType
{
    public string ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public string Address { get; set; }
    public int ProductId { get; set; }
    public int FromStore { get; set; }
    public int ToStore { get; set; }
    public int MoveQuantity { get; set; }
    public DateTime DateOfMovement { get; set; }
    public int StoreProductsQuantity { get; set; }
}
