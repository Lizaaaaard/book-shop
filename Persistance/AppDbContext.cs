using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<OrderBook> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<Book>().
            HasMany(bo => bo.OrderBooks);
        modelBuilder.Entity<OrderBook>().HasKey(o => o.Id);

        modelBuilder.Entity<Book>()
            .HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Green Mile",
                    AuthorName = "S. King",
                    ReleaseDate = new DateTime(1999, 12, 9)
                },
                new Book
                {
                    Id = 2,
                    Title = "The Hound of Baskervilles",
                    AuthorName = "A. C. Doyle",
                    ReleaseDate = new DateTime(1901, 8, 1)
                },
                new Book
                {
                    Id = 3,
                    Title = "Martin Eden",
                    AuthorName = "J. London",
                    ReleaseDate = new DateTime(1909, 9, 20)
                },
                new Book
                {
                    Id = 4,
                    Title = "Treasure island",
                    AuthorName = "R. L. Stevenson",
                    ReleaseDate = new DateTime(1883, 5, 11)
                },
                new Book
                {
                    Id = 5,
                    Title = "Gone with the Wind",
                    AuthorName = "M. Mitchell",
                    ReleaseDate = new DateTime(1936, 6, 30)
                }
            );

        modelBuilder.Entity<OrderBook>()
            .HasData(
                new OrderBook
                {
                    Id = 1,
                    OrderId = 1,
                    BookId = 1,
                    OrderDate = new DateTime(2023, 2, 11)
                },
                new OrderBook
                {
                    Id = 2,
                    OrderId = 1,
                    BookId = 3,
                    OrderDate = new DateTime(2023, 2, 11)
                },
                new OrderBook
                {
                    Id = 3,
                    OrderId = 1,
                    BookId = 4,
                    OrderDate = new DateTime(2023, 2, 11)
                },
                new OrderBook
                {
                    Id = 4,
                    OrderId = 2,
                    BookId = 2,
                    OrderDate = new DateTime(2023, 2, 25)
                },
                new OrderBook
                {
                    Id = 5,
                    OrderId = 2,
                    BookId = 3,
                    OrderDate = new DateTime(2023, 2, 25)
                },
                new OrderBook
                {
                    Id = 6,
                    OrderId = 3,
                    BookId = 1,
                    OrderDate = new DateTime(2023, 3, 3)
                },
                new OrderBook
                {
                    Id = 7,
                    OrderId = 3,
                    BookId = 4,
                    OrderDate = new DateTime(2023, 3, 3)
                },
                new OrderBook
                {
                    Id = 8,
                    OrderId = 3,
                    BookId = 5,
                    OrderDate = new DateTime(2023, 3, 3)
                },
                new OrderBook
                {
                    Id = 9,
                    OrderId = 4,
                    BookId = 2,
                    OrderDate = new DateTime(2023, 3, 11)
                },
                new OrderBook
                {
                    Id = 10,
                    OrderId = 4,
                    BookId = 5,
                    OrderDate = new DateTime(2023, 3, 11)
                }
            );
    }
}