using System.Windows.Input;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Books,
        Categories,
        Recipes,
        Ingredients,
        Authors,
        Login,
        Logout
    }
    
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}