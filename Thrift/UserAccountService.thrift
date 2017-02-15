namespace * Common.ThriftGenerated

struct UserAccount
{
  1: i32 Id,
  2: string Username,
}

service UserAccountService
{
  list<UserAccount> GetAllUserAccounts();
  UserAccount GetUserAccount(1: i32 userAccountId);
}