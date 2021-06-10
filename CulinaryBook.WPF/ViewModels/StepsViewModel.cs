using System.Collections.Generic;
using System.Windows.Input;
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

        public string StepDescription
        {
            get => _stepDescription;
            set
            {
                _stepDescription = value;
                OnPropertyChanged(nameof(StepDescription));
            }
        }
        public ICommand AddStepCommand { get; }

        public StepsViewModel(IStepService stepDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            AddStepCommand = new AddStepCommand(this, stepDataService);
        }
    }
}