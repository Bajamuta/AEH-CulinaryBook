using System.Windows;
using System.Windows.Controls;

namespace CulinaryBook.WPF.Views
{
    public partial class RecipesView : UserControl
    {
        public RecipesView()
        {
            InitializeComponent();
        }

        private void AddIngredientClick(object sender, RoutedEventArgs e)
        {
            LbRecipeIngredients.Items.Refresh();
        }
    }
}