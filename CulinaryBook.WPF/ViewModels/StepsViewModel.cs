using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Categories;
using CulinaryBook.WPF.Commands.Steps;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class StepsViewModel : ViewModelBase
    {
        private string _stepDescription;
        private Step _selectedStep;
        private List<Step> _steps;

        public string StepDescription
        {
            get => _stepDescription;
            set
            {
                _stepDescription = value;
                OnPropertyChanged(nameof(StepDescription));
            }
        }

        public Step SelectedStep
        {
            get => _selectedStep;
            set
            {
                _selectedStep = value;
                OnPropertyChanged(nameof(SelectedStep));
            }
        }

        public List<Step> Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }
        public ICommand AddStepCommand { get; }
        public ICommand SearchStepCommand { get; }
        public ICommand GetAllStepsCommand { get; }

        public StepsViewModel(IStepService stepDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            AddStepCommand = new AddStepCommand(this, stepDataService);
            SearchStepCommand = new SearchStepCommand(this, stepDataService);
            GetAllStepsCommand = new GetAllStepsCommand(this, stepDataService);
        }
    }
}