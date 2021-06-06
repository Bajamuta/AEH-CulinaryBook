using System;
using System.Windows;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;
using CulinaryBook.WPF.ViewModels.Factories;
using Microsoft.AspNetCore.Identity;
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
            //ILoginService authentication = serviceProvider.GetRequiredService<ILoginService>();
            /*bool login = authentication.Register("Krzysztof Porządny",
                "krzysztof@gmail.com", "porzadny", "P@$$w0rd", "P@$$w0rd", "user").Result;*/

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
            services.AddSingleton<ICategoryDataService, CategoryDataService>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IPasswordHasher<Author>, PasswordHasher<Author>>();

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
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>( s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}