using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        public Author CurrentAccount { get; set; }
    }
}