using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Steps
{
    public class SearchStepCommand : ICommand
    {
        private readonly StepsViewModel _stepsViewModel;
        private readonly IStepService _stepService;
        
        public SearchStepCommand(
            StepsViewModel stepsViewModel, 
            IStepService stepService)
        {
            _stepsViewModel = stepsViewModel;
            _stepService = stepService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                IEnumerable steps = await _stepService.GetAllByText(_stepsViewModel.Search);
                if (steps != null)
                {
                    _stepsViewModel.Steps = new List<Step>();
                    foreach (Step step in steps)
                    {
                        _stepsViewModel.Steps.Add(step);
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