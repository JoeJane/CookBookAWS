using CookBookClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
    /// Interaction logic for List_Ingredient.xaml
    /// </summary>
    public partial class List_Ingredient : Window
    {
        public List_Ingredient()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Add_Ingredient addIngredient = new Add_Ingredient();
            addIngredient.Show();
            this.Close();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnDeleteIngredient.Visibility = Visibility.Hidden;
            await PopulateList();
        }
        private async Task PopulateList()
        {
            var response = await CookBookAPIUtil.GetAllIngredients();
            if (response.Count() == 0)
            {
                response = await CookBookAPIUtil.GetAllIngredients();
            }
            else
            {
                listViewIngredients.ItemsSource = response;
            }
        }

        private async void MouseDoubleClick_IngredientSelected(object sender, MouseButtonEventArgs e)
        {
            Ingredient? selectedIngredient = listViewIngredients.SelectedItem as Ingredient;
            Selected_Ingredient selected_Ingredient = new Selected_Ingredient(selectedIngredient.ingredientId, selectedIngredient.ingredientName);
            selected_Ingredient.Show();
            this.Close();
        }

        private async void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient? selected = listViewIngredients.SelectedItem as Ingredient;
            var response = await CookBookAPIUtil.DeleteIngredient(selected.ingredientId);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                await PopulateList();
            }
        }

        private void listViewIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteIngredient.Visibility = Visibility.Visible;
        }
    }
}
