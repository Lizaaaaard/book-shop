namespace Domain.Entities.Dto;
// <summary>
//BookDto is a format of returning data about book
// </summary>
public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
}