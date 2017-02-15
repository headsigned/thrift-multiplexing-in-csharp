namespace * Common.ThriftGenerated

struct BookInfo
{
  1: i32 Id,
  2: string Author,
  3: string Title
}

service BookService
{
  list<BookInfo> GetAllBooks();
  BookInfo GetBook(1: i32 bookId);
}