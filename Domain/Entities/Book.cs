// <summary>
//Book - entity
// </summary>

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }

    public ICollection<OrderBook>? OrderBooks { get; set; } //ref to OrderBook entity

    public Book()
    {
        OrderBooks = new List<OrderBook>();
    }
}