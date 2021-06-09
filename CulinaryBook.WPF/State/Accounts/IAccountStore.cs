using CulinaryBook.ConsoleApp;

namespace CulinaryBook.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Author CurrentAccount { get; set; }
    }
}