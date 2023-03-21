// <summary>
//OrderBookDto is a format of returning data about single book in order
// </summary>

namespace Domain.Entities.Dto;

public class OrderBookDto
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public DateTime OrderDate { get; set; }
}