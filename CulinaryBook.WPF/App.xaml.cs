using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BasicServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            BasicService<Recipe> recipeService = new BasicService<Recipe>();
            Recipe recipe = new Recipe()
            {

            };
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            base.OnStartup(e);
        }
    }
}