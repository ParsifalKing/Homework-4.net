namespace Domain.Models;

public class Movement
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int FromStore { get; set; }
    public int ToStore { get; set; }
    public int Quantity { get; set; }
    public DateTime DateOfMovement { get; set; }
}
