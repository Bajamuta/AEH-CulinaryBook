using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.WPF.Models
{
    public class FullRecipe
    {
        public Recipe Recipe;
        public Author Author;
        public Book Book;
        public Category Category;
        public StepsList StepsList;
        public IngredientsList IngredientsList;
    }
}