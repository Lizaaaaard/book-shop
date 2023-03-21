using Domain.Entities.Dto;

namespace Persistance.Repositories;

public interface IRepository
{

    BookDto GetBook(int id); //method will return book by id
    List<BookDto> GetBookByTitleAndDate(string title, DateTime date); //method will return a list of books by title and date of releasing
    OrderDto  GetOrderByIdAndDate(int id, DateTime date); //method will return order by id and order date
    OrderDto SaveOrder(List<OrderBookDto> orders); //method put new order into db

}