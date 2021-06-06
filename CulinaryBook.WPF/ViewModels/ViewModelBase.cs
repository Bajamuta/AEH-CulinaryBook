using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
    }
}