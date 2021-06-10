using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Steps
{
    public class AddStepCommand : ICommand
    {
        private readonly IStepService _service;
        private readonly StepsViewModel _stepsViewModel;
        public AddStepCommand(StepsViewModel stepsViewModel, IStepService service)
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
                await _service.Create(
                    new Step()
                    {
                        Description = _stepsViewModel.StepDescription
                    });
            }
            catch (Exception e)
            {
                // TODO exception error during create
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}