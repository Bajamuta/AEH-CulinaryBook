using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class SearchAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _authorsViewModel;
        private readonly IAuthorDataService _authorDataService;
        
        public SearchAuthorCommand(
            AuthorsViewModel authorsViewModel, 
            IAuthorDataService authorDataService)
        {
            _authorsViewModel = authorsViewModel;
            _authorDataService = authorDataService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                IEnumerable authors = await _authorDataService.GetAllByName(_authorsViewModel.Search);
                if (authors != null)
                {
                    _authorsViewModel.Authors = new List<Author>();
                    foreach (Author author in authors)
                    {
                        _authorsViewModel.Authors.Add(author);
                    }
                }
      }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}