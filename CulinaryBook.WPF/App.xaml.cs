using System;
using System.Windows;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.IngredientsListServices;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.ConsoleApp.Services.StepsListServices;
using CulinaryBook.WPF.State.Accounts;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;
using CulinaryBook.WPF.ViewModels.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Type = CulinaryBook.ConsoleApp.Models.Type;

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
            
            CreateAdditional(serviceProvider);
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
            services.AddSingleton<IRecipeDataService, RecipeDataService>();
            services.AddSingleton<IIngredientsListDataService, IngredientsListDataService>();
            services.AddSingleton<IStepsListDataService, StepsListDataService>();
            services.AddSingleton<IStepService, StepService>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IPasswordHasher<Author>, PasswordHasher<Author>>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewFactory>();
            services.AddSingleton<IViewModelFactory<AuthorsViewModel>, AuthorsViewFactory>();
            services.AddSingleton<IViewModelFactory<BooksViewModel>, BooksViewFactory>();
            services.AddSingleton<IViewModelFactory<CategoriesViewModel>, CategoriesViewFactory>();
            services.AddSingleton<IViewModelFactory<IngredientsViewModel>, IngredientsViewFactory>();
            services.AddSingleton<IViewModelFactory<RecipesViewModel>, RecipesViewFactory>();
            services.AddSingleton<IViewModelFactory<StepsViewModel>, StepsViewFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>>(
                (services) => new LoginViewFactory(services.GetRequiredService<IAuthenticator>(),
                    new Renavigator<HomeViewModel>(
                        services.GetRequiredService<INavigator>(),
                        services.GetRequiredService<IViewModelFactory<HomeViewModel>>()
                        )));
            services.AddSingleton<IViewModelFactory<LogoutViewModel>, LogoutViewFactory>();
            
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>( s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
        
        private async void CreateAdditional(IServiceProvider serviceProvider)
        {
            ILoginService authentication = serviceProvider.GetRequiredService<ILoginService>();
            /*authentication.Register("Krzysztof Porządny",
                "krzysztof@gmail.com", "porzadny", "P@$$w0rd", "P@$$w0rd", "Main admin",Type.Admin);*/
            IIngredientDataService ingredientDataService = serviceProvider.GetRequiredService<IIngredientDataService>();
            /*await ingredientDataService.Create(
                new Ingredient()
                {
                    Name = "potatoes",
                    Junit = "g"
                });
            await ingredientDataService.Create(
                new Ingredient()
                {
                    Name = "rice",
                    Junit = "g"
                });
            await ingredientDataService.Create(
                new Ingredient()
                {
                    Name = "onion",
                    Junit = "oz"
                });*/
            Ingredient ingredient1 = await ingredientDataService.Get(1);
            Ingredient ingredient2 = await ingredientDataService.Get(2);
            Ingredient ingredient3 = await ingredientDataService.Get(3);
            IRecipeDataService recipeDataService = serviceProvider.GetRequiredService<IRecipeDataService>();
            /*recipeDataService.Create(new Recipe()
            {
                Name = "Boiled potatoes",
                Id_Author = 1,
                Photo = "http://google.com"
            });*/
            recipeDataService.Create(
                new Recipe()
                {
                    Id_Author = 1,
                    Name = "Simple vegetables"
                });
            Recipe recipe = await recipeDataService.Get(1);
            IIngredientsListDataService listDataService =
                serviceProvider.GetRequiredService<IIngredientsListDataService>();
            /*await listDataService.Create(
                new IngredientsList()
                {
                    Id_Ingredient = ingredient1.ID,
                    Id_Recipe = recipe.ID,
                    Quantity = 300
                });*/
            await listDataService.Create(
                new IngredientsList()
                {
                    Id_Ingredient = ingredient2.ID,
                    Id_Recipe = recipe.ID,
                    Quantity = 150
                });
            await listDataService.Create(
                new IngredientsList()
                {
                    Id_Ingredient = ingredient3.ID,
                    Id_Recipe = recipe.ID,
                    Quantity = 30
                });
            IStepService stepService = serviceProvider.GetRequiredService<IStepService>();
            /*await stepService.Create(
                new Step()
                {
                    Description = "chop vegetables"
                });
            await stepService.Create(
                new Step()
                {
                    Description = "boil in water"
                });
            await stepService.Create(
                new Step()
                {
                    Description = "add salt"
                });*/
            Step step1 = await stepService.Get(1);
            Step step2 = await stepService.Get(2);
            Step step3 = await stepService.Get(3);
            IStepsListDataService stepsListDataService = serviceProvider.GetRequiredService<IStepsListDataService>();
            /*await stepsListDataService.Create(
                new StepsList()
                {
                    Id_Step = step1.ID,
                    Id_Recipe = recipe.ID,
                    Step_Number = 1
                });
            await stepsListDataService.Create(
                new StepsList()
                {
                    Id_Step = step2.ID,
                    Id_Recipe = recipe.ID,
                    Step_Number = 2
                });
            await stepsListDataService.Create(
                new StepsList()
                {
                    Id_Step = step3.ID,
                    Id_Recipe = recipe.ID,
                    Step_Number = 3
                });*/
            
        }
    }
}