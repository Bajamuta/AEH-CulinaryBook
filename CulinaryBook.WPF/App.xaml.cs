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
using CulinaryBook.ConsoleApp.Services.RecipesListServices;
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
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();

            CreateAdditional(serviceProvider);
            CreateFullRecipe(serviceProvider);
            
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
            services.AddSingleton<IRecipesListDataService, RecipesListDataService>();
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
            services.AddSingleton<IViewModelFactory<LogoutViewModel>, LogoutViewFactory>();
            services.AddSingleton<IViewModelFactory<ShowtimeViewModel>, ShowtimeViewFactory>();
            
            services.AddSingleton<IViewModelFactory<LoginViewModel>>(
                services => new LoginViewFactory(services.GetRequiredService<IAuthenticator>(),
                    new Renavigator<HomeViewModel>(
                        services.GetRequiredService<INavigator>(),
                        services.GetRequiredService<IViewModelFactory<HomeViewModel>>()
                    )));
            /*services.AddSingleton<IViewModelFactory<MainViewModel>>(
                services => new MainViewFactory(services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IAuthenticator>(), 
                    services.GetRequiredService<IViewModelAbstractFactory>()));*/

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddScoped<MainViewModel>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }

        private async void CreateAdditional(IServiceProvider serviceProvider)
        {
            var authentication = serviceProvider.GetRequiredService<ILoginService>();
            authentication.Register("Krzysztof Porządny",
                "krzysztof@gmail.com", "porzadny", "P@$$w0rd", "P@$$w0rd", "Main admin",Type.Admin);
            var ingredientDataService = serviceProvider.GetRequiredService<IIngredientDataService>();
            await ingredientDataService.Create(
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
                });
            var ingredient1 = await ingredientDataService.Get(1);
            var ingredient2 = await ingredientDataService.Get(2);
            var ingredient3 = await ingredientDataService.Get(3);
            var recipeDataService = serviceProvider.GetRequiredService<IRecipeDataService>();
            recipeDataService.Create(new Recipe()
            {
                Name = "Boiled potatoes",
                Id_Author = 1,
                Photo = "http://google.com"
            });
            recipeDataService.Create(
                new Recipe()
                {
                    Id_Author = 1,
                    Name = "Simple vegetables",
                    Photo = "http://instagram.com"
                });
            var recipe = await recipeDataService.Get(1);
            var listDataService =
                serviceProvider.GetRequiredService<IIngredientsListDataService>();
            await listDataService.Create(
                new IngredientsList()
                {
                    Id_Ingredient = ingredient1.ID,
                    Id_Recipe = recipe.ID,
                    Quantity = 300
                });
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
            var stepService = serviceProvider.GetRequiredService<IStepService>();
            await stepService.Create(
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
                });
            var step1 = await stepService.Get(1);
            var step2 = await stepService.Get(2);
            var step3 = await stepService.Get(3);
            var stepsListDataService = serviceProvider.GetRequiredService<IStepsListDataService>();
            await stepsListDataService.Create(
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
                });
            var bookDataService = serviceProvider.GetRequiredService<IBookDataService>();
            bookDataService.Create(
                new Book()
                {
                    Name = "Polish Cuisine"
                });
            var book1 = await bookDataService.Get(1);
            var categoryDataService = serviceProvider.GetRequiredService<ICategoryDataService>();
            await categoryDataService.Create(
                new Category()
                {
                    Name = "Breakfast",
                    Description = "Light dishes to wake you up"
                });
            await categoryDataService.Create(
                new Category()
                {
                    Name = "Lunch",
                    Description = "Delicious meals for break at work"
                });
            var category1 = await categoryDataService.Get(1);
            var category2 = await categoryDataService.Get(2);
            var recipesListDataService =
                serviceProvider.GetRequiredService<IRecipesListDataService>();
            await recipesListDataService.Create(
                new RecipesList()
                {
                    Id_Book = book1.ID,
                    Id_Category = category1.ID,
                    Id_Recipe = recipe.ID
                });
        }

        public async void CreateFullRecipe(IServiceProvider serviceProvider)
        {
            var recipeDataService = serviceProvider.GetRequiredService<IRecipeDataService>();
            var categoryDataService = serviceProvider.GetRequiredService<ICategoryDataService>();
            var bookDataService = serviceProvider.GetRequiredService<IBookDataService>();
            var ingredientDataService = serviceProvider.GetRequiredService<IIngredientDataService>();
            var authenticator = serviceProvider.GetRequiredService<IAuthenticator>();
            var stepService = serviceProvider.GetRequiredService<IStepService>();
            var stepsListDataService = serviceProvider.GetRequiredService<IStepsListDataService>();
            var recipesListDataService =
                serviceProvider.GetRequiredService<IRecipesListDataService>();
            var ingredientsListDataService =
                serviceProvider.GetRequiredService<IIngredientsListDataService>();
            if (await authenticator.Login("porzadny", "P@$$w0rd"))
            {
                var author = authenticator.CurrentUser;
                var recipe = await recipeDataService.Create(
                    new Recipe
                    {
                        Name = "Sandwich",
                        Photo = "http://facebook.com",
                        Id_Author = author.ID
                    });
                var category = await categoryDataService.Get(1);
                var ingredient1 = await ingredientDataService.Get(1);
                var ingredient2 = await ingredientDataService.Get(2);
                var ingredient3 = await ingredientDataService.Get(3);
                await ingredientsListDataService.Create(
                    new IngredientsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Ingredient = ingredient1.ID,
                        Quantity = 250
                    });
                await ingredientsListDataService.Create(
                    new IngredientsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Ingredient = ingredient2.ID,
                        Quantity = 150
                    });
                await ingredientsListDataService.Create(
                    new IngredientsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Ingredient = ingredient3.ID,
                        Quantity = 50
                    });
                var ingredientsList = await ingredientsListDataService.GetByRecipe(recipe);
                var step1 = await stepService.Get(1);
                var step2 = await stepService.Get(2);
                var step3 = await stepService.Get(3);
                await stepsListDataService.Create(
                    new StepsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Step = step1.ID
                    });
                await stepsListDataService.Create(
                    new StepsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Step = step2.ID
                    });
                await stepsListDataService.Create(
                    new StepsList
                    {
                        Id_Recipe = recipe.ID,
                        Id_Step = step3.ID
                    });
                var stepsList = await stepsListDataService.GetByRecipe(recipe);
                var book = await bookDataService.Get(1);
                await recipesListDataService.Create(
                    new RecipesList
                    {
                        Id_Book = book.ID,
                        Id_Category = category.ID,
                        Id_Recipe = recipe.ID
                    });
            }
        }
    }
}