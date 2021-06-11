using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Steps
{
    public class GetAllStepsCommand : ICommand
    {
        private readonly IStepService _service;
        private readonly StepsViewModel _stepsViewModel;
        public GetAllStepsCommand(StepsViewModel stepsViewModel, IStepService service)
        {
            _stepsViewModel = stepsViewModel;
            _service = service;
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
                    _stepsViewModel.Steps = new List<Step>();
                    foreach (Step item in items)
                    {
                        _stepsViewModel.Steps.Add(item);
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