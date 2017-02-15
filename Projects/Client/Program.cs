namespace Client
{
  using System;
  using System.Linq;
  using System.Net.Sockets;
  using Common.ThriftGenerated;
  using Thrift.Protocol;
  using Thrift.Transport;

  internal class Program
  {
    private static void Main(string[] args)
    {
      var transport = new TSocket("localhost", 9090, 100);
      var binaryProtocol = new TBinaryProtocol(transport);

      var bookServiceProtocol = new TMultiplexedProtocol(binaryProtocol, nameof(BookService));
      var userAccountServiceProtocol = new TMultiplexedProtocol(binaryProtocol, nameof(UserAccountService));

      var bookServiceClient = new BookService.Client(bookServiceProtocol);
      var userAccountServiceClient = new UserAccountService.Client(userAccountServiceProtocol);

      try
      {
        transport.Open();

        var allBooks = bookServiceClient.GetAllBooks(); // Thrift call
        var allUserAccounts = userAccountServiceClient.GetAllUserAccounts(); // Thrift call

        Console.WriteLine("Total number of books: {0}", allBooks.Count);
        Console.WriteLine("Total number of user accounts: {0}\n", allUserAccounts.Count);

        if (allBooks.Any())
        {
          Console.Write("Getting the first book: ");
          var firstBook = bookServiceClient.GetBook(allBooks.First().Id); // Thrift call

          Console.WriteLine("Id: {0}, {1} by {2}", firstBook.Id, firstBook.Title, firstBook.Author);
        }

        if (allUserAccounts.Any())
        {
          Console.Write("Getting the last user account: ");
          var lastUserAccount = userAccountServiceClient.GetUserAccount(allUserAccounts.Last().Id); // Thrift call

          Console.WriteLine("Id: {0}, Username: {1}", lastUserAccount.Id, lastUserAccount.Username);
        }
      }
      catch (SocketException e)
      {
        Console.WriteLine("Could not connect to the server: {0}.", e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("An error occured: {0}", e.Message);
      }

      Console.WriteLine("\nDone. Press any key to continue...");
      Console.ReadKey(true);
    }
  }
}
