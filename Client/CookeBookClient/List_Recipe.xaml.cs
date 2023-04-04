using CookBookClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookeBookClient
{
    /// <summary>
    /// Interaction logic for List_Recipe.xaml
    /// </summary>
    public partial class List_Recipe : Window
    {
        MainWindow MainWindow;
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();


        public List_Recipe()
        {
            InitializeComponent();
        }

        public List_Recipe(MainWindow mainWindow)
        {
            InitializeComponent();
            this.MainWindow = mainWindow;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnDeleteRecipe.Visibility = Visibility.Hidden;
            var response = await CookBookAPIUtil.GetAllRecipes();
            listViewRecipes.ItemsSource = response;

        }



        private async void listViewRecipes_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Recipe item = (Recipe)listViewRecipes.SelectedValue;
            Recipe recipe = await CookBookAPIUtil.GetRecipeById(item.recipeId);
            Selected_Recipe selected_Recipe = new Selected_Recipe(recipe, this);
            this.Hide();
            selected_Recipe.Show();
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            Add_Recipe add_Recipe = new Add_Recipe();
            this.Close();
            add_Recipe.Show();
        }



        private async void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe item = (Recipe)listViewRecipes.SelectedValue;
            var response = await CookBookAPIUtil.DeleteRecipe(item.recipeId);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
                List_Recipe list_Recipe = new List_Recipe();
                list_Recipe.Show();
            }
        }

        private void listViewRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteRecipe.Visibility = Visibility.Visible;
        }
    }
}
