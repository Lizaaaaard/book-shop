using Domain.Entities;
using Domain.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories;

namespace BookShop.Controllers;

[ApiController]
public class BookController:ControllerBase
{
    private readonly IRepository _repository;
    
    public BookController(IRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet("books")]
    public ActionResult<List<BookDto>> GetAllBooks(string title, DateTime date)
    {
        return _repository.GetBookByTitleAndDate(title, date);
    }

    [HttpGet("books/{bookId}")]
    public ActionResult<BookDto> GetBook(int bookId)
    {
        return _repository.GetBook(bookId);
    }
}