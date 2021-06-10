using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Steps
{
    public class UpdateStepCommand : ICommand
    {
        private readonly StepsViewModel _stepsViewModel;
        private readonly IStepService _stepService;
        
        public UpdateStepCommand(
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
            Step selectedStep = _stepsViewModel.SelectedStep;
            selectedStep.Description = _stepsViewModel.StepDescription;
            try
            {
               await _stepService.Update(selectedStep.ID, selectedStep);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}