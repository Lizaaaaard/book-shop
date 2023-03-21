using Domain.Entities;
using Domain.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories;

namespace BookShop.Controllers;

[ApiController]
public class OrderController:ControllerBase
{
    private readonly IRepository _repository;
    
    public OrderController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("order")]
    public ActionResult<OrderDto> GetOrderByIdAAndDate(int id, DateTime date)
    {
        return _repository.GetOrderByIdAndDate(id, date);
    }

    [HttpPost("order")]
    public ActionResult<OrderDto> SaveOrder(List<OrderBookDto> orders)
    {
        return _repository.SaveOrder(orders);
    }
}