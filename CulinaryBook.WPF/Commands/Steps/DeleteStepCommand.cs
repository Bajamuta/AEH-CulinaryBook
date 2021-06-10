using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Steps
{
    public class DeleteStepCommand : ICommand
    {
        private readonly StepsViewModel _stepsViewModel;
        private readonly IStepService _stepService;
        
        public DeleteStepCommand(
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
            try
            {
                await _stepService.Delete(selectedStep.ID);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}