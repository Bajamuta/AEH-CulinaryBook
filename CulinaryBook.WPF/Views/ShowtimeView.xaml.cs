using System.Windows;
using System.Windows.Controls;

namespace CulinaryBook.WPF.Views
{
    public partial class ShowtimeView : UserControl
    {
        public ShowtimeView()
        {
            InitializeComponent();
        }

        private void ShowRecipe(object sender, RoutedEventArgs e)
        {
            LbIngredients.Items.Refresh();
            LbSteps.Items.Refresh();
        }
    }
}