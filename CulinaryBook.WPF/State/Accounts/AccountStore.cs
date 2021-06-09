using CulinaryBook.ConsoleApp;

namespace CulinaryBook.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        public Author CurrentAccount { get; set; }
    }
}