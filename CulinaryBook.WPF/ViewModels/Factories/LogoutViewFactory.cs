namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LogoutViewFactory : IViewModelFactory<LogoutViewModel>
    {
        public LogoutViewModel CreateViewModel()
        {
            return new LogoutViewModel();
        }
    }
}