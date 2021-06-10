using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Authors
{
    public class GetAllAuthorsCommand : ICommand
    {
        private readonly IAuthorDataService _service;
        private readonly AuthorsViewModel _authorsViewModel;
        public GetAllAuthorsCommand(AuthorsViewModel authorsViewModel, IAuthorDataService service)
        {
            _service = service;
            _authorsViewModel = authorsViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                IEnumerable items = await _service.GetAll();
                if (items != null)
                {
                    _authorsViewModel.Authors = new List<Author>();
                    foreach (Author item in items)
                    {
                        _authorsViewModel.Authors.Add(
                            item);
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}