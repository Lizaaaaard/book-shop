using AutoMapper;
using Domain.Entities;
using Domain.Entities.Dto;


namespace Persistance.Repositories;

public class Repository : IRepository
{
    private AppDbContext _ctx;
    public Repository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    private static MapperConfiguration bookConfig = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>()
       .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
       .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
       .ForMember(dest => dest.AuthorName, act => act.MapFrom(src => src.AuthorName))
       .ForMember(dest => dest.ReleaseDate, act => act.MapFrom(src => src.ReleaseDate))
    );

    private static MapperConfiguration orderConfig = new MapperConfiguration(cfg => cfg.CreateMap<Tuple<List<OrderBook>, List<BookDto>>, OrderDto>()
        .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.Item1.First().OrderId))
        .ForMember(dest => dest.Books, act => act.MapFrom(src => src.Item2))
        .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => src.Item1.First().OrderDate))
    );

    private static MapperConfiguration orderBookConfig = new MapperConfiguration(cfg => cfg.CreateMap<OrderBookDto, OrderBook>()
        .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderId))
        .ForMember(dest => dest.BookId, act => act.MapFrom(src => src.BookId))
        .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => src.OrderDate))
    );
    private Mapper bookMapper = new Mapper(bookConfig);
    private Mapper orderMapper = new Mapper(orderConfig);
    private Mapper orderBookMapper = new Mapper(orderBookConfig);

    private List<BookDto> MapBookList(List<Book> books)
    {
        List<BookDto> bookDtos = new List<BookDto>();
        foreach (var book in books)
        {
            BookDto bookDto = MapBook(book);
            bookDtos.Add(bookDto);
        }

        return bookDtos;
    }

    private BookDto MapBook(Book book)
    {
        return bookMapper.Map<Book, BookDto>(book);
    }

    private OrderDto MapOrder(List<OrderBook> orderList, List<BookDto> books)
    {
        return orderMapper.Map<Tuple<List<OrderBook>, List<BookDto>>, OrderDto>(Tuple.Create(orderList, books));
    }

    private OrderBook MapOrderBookDto(OrderBookDto orderBookDto)
    {
        return orderBookMapper.Map<OrderBookDto, OrderBook>(orderBookDto);
    }

    public BookDto GetBook(int id)
    {
        Book book = _ctx.Books.FirstOrDefault(b => b.Id == id)!;
        return MapBook(book);
    }

    public List<BookDto> GetBookList()
    {
        List<Book> books = _ctx.Books.ToList();
        return MapBookList(books);
    }

    public List<BookDto> GetBookByTitleAndDate(string title, DateTime date)
    {
        List<Book> books = _ctx.Books
           .Where(i => i.Title.Equals(title) && i.ReleaseDate.Equals(date))
           .ToList();
        return MapBookList(books);
    }

    public OrderDto GetOrderByIdAndDate(int id, DateTime date)
    {
        List<OrderBook> orders = _ctx.Orders
            .Where(i => i.OrderId.Equals(id) && i.OrderDate.Equals(date))
            .ToList();
        throw new ArgumentException();
        List<int> bookIdList = orders
            .Select(i => i.BookId)
            .ToList();
        List<Book> books = _ctx.Books
            .Where(i => bookIdList.Contains(i.Id))
            .ToList();
        List<BookDto> bookDtos = MapBookList(books);
        return MapOrder(orders, bookDtos);
    }

    public OrderDto SaveOrder(List<OrderBookDto> orders)
    {
        foreach (var order in orders)
        {
            var orderBook = MapOrderBookDto(order);
            _ctx.Orders.Add(orderBook);
        }
        _ctx.SaveChanges();
        return GetOrderByIdAndDate(orders.First().OrderId, orders.First().OrderDate);
    }
}