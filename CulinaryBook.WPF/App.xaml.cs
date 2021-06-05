using System;
using System.Windows;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;
using CulinaryBook.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // TODO Api: photos from internet
            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<CulinaryBookContextFactory>();
            services.AddSingleton<IAuthorDataService, AuthorDataService>();
            services.AddSingleton<IIngredientDataService, IngredientDataService>();
            services.AddSingleton<IBookDataService, BookDataService>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewFactory>();
            services.AddSingleton<IViewModelFactory<AuthorsViewModel>, AuthorsViewFactory>();
            services.AddSingleton<IViewModelFactory<BooksViewModel>, BooksViewFactory>();
            services.AddSingleton<IViewModelFactory<CategoriesViewModel>, CategoriesViewFactory>();
            services.AddSingleton<IViewModelFactory<IngredientsViewModel>, IngredientsViewFactory>();
            services.AddSingleton<IViewModelFactory<RecipesViewModel>, RecipesViewFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewFactory>();
            services.AddSingleton<IViewModelFactory<LogoutViewModel>, LogoutViewFactory>();
            
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>( s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}