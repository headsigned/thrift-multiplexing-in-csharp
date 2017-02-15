namespace Server
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Common.ThriftGenerated;

  /// <summary>
  /// Concrete implementation of the thrift-generated UserAccountService interface.
  /// </summary>
  internal class UserAccountServiceHandler : UserAccountService.Iface
  {
    private readonly List<UserAccount> userAccounts;

    public UserAccountServiceHandler()
    {
      // Initialize with dummy data
      userAccounts = new List<UserAccount>
        {
          new UserAccount {Id = 1, Username = "Alice"},
          new UserAccount {Id = 2, Username = "Bob"},
          new UserAccount {Id = 3, Username = "Charlie"},
        };
    }

    public List<UserAccount> GetAllUserAccounts()
    {
      Console.WriteLine("Returning all user accounts...");
      return userAccounts;
    }

    public UserAccount GetUserAccount(int userAccountId)
    {
      Console.WriteLine($"Returning user account {userAccountId}...");
      return userAccounts.First(userAccount => userAccount.Id == userAccountId);
    }
  }
}
