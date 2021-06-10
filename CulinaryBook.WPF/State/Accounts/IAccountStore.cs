using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Author CurrentAccount { get; set; }
    }
}