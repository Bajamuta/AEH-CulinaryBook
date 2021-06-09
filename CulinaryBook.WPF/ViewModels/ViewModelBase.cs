using System.Collections.Generic;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string _search;
        private List<ItemList> _items;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
        
        public List<ItemList> ItemsList
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(ItemsList));
            }
        }
    }
}