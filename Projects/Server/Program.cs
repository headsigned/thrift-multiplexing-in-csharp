namespace Server
{
  using System;
  using System.Threading;
  using Common.ThriftGenerated;
  using Thrift.Protocol;
  using Thrift.Server;
  using Thrift.Transport;

  internal class Program
  {
    private static void Main(string[] args)
    {
      var bookServiceHandler = new BookServiceHandler();
      var userAccountServiceHandler = new UserAccountServiceHandler();

      var bookServiceProcessor = new BookService.Processor(bookServiceHandler);
      var userAccountProcessor = new UserAccountService.Processor(userAccountServiceHandler);

      var processor = new TMultiplexedProcessor();
      processor.RegisterProcessor(nameof(BookService), bookServiceProcessor);
      processor.RegisterProcessor(nameof(UserAccountService), userAccountProcessor);

      TServerTransport transport = new TServerSocket(9090);
      TServer server = new TThreadPoolServer(processor, transport); // TThreadPoolServer accepts multiple clients

      Console.WriteLine("Starting the server...");

      // Start server on a different background thread so the console continues to be responsive
      var serverThread = new Thread(() => server.Serve()) { IsBackground = true };
      serverThread.Start();

      Console.WriteLine("Done. Press any key to stop the server...");
      Console.ReadKey(true);

      server.Stop();
    }
  }
}
