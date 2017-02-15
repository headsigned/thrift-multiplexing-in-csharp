namespace Server
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Common.ThriftGenerated;

  /// <summary>
  /// Concrete implementation of the thrift-generated BookService interface.
  /// </summary>
  internal class BookServiceHandler : BookService.Iface
  {
    private readonly List<BookInfo> books;

    public BookServiceHandler()
    {
      // Initialize with dummy data
      books = new List<BookInfo>
        {
          new BookInfo {Id = 1, Author = "Author 1", Title = "Book 1"},
          new BookInfo {Id = 2, Author = "Author 2", Title = "Book 2"},
          new BookInfo {Id = 3, Author = "Author 3", Title = "Book 3"},
        };
    }

    public List<BookInfo> GetAllBooks()
    {
      Console.WriteLine("Returning all books...");
      return books;
    }

    public BookInfo GetBook(int bookId)
    {
      Console.WriteLine($"Returning book {bookId}...");
      return books.First(book => book.Id == bookId);
    }
  }
}
