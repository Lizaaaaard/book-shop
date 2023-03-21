// <summary>
//BookDto is a format of returning data about book
// </summary>

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class OrderBook
{
    [Key]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int BookId { get; set; }
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime OrderDate { get; set; }
    public Book? Book { get; set; }
}