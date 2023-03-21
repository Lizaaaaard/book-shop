// <summary>
//OrderDto is a format of returning data about orders with the list of books
// </summary>

namespace Domain.Entities.Dto;

public class OrderDto
{
    public int OrderId { get; set; }
    public List<BookDto> Books { get; set; }
    public DateTime OrderDate { get; set; }
}