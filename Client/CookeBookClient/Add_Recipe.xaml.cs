using CookBookClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Add_Recipe.xaml
    /// </summary>
    public partial class Add_Recipe : Window
    {
        List<Ingredient> Ingredients;
        public Add_Recipe()
        {
            InitializeComponent();
        }


        private async void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeCreation newRecipe = new RecipeCreation();
            newRecipe.RecipeName = this.txtRecipeName.Text;
            newRecipe.Cuisine = this.txtCuisine.Text;
            newRecipe.Description = this.txtDescription.Text;
            newRecipe.Instruction = this.txtInstruction.Text;
            newRecipe.PrepTime = this.txtPrepTime.Text;
            newRecipe.Rating = this.txtRating.Text;
            newRecipe.PrepVideoUrl = this.txtPrepVideoUrl.Text;
            newRecipe.Complexity = this.txtComplexity.Text;
            List<Ingredient> ingredients = new List<Ingredient>();
            List<string> measurement = new List<string>();
            foreach (ComboBox cmb in ingredientList.Children)
            {
                ingredients.Add((Ingredient)cmb.SelectedItem);
            }

            foreach (TextBox txt in measurements.Children)
            {
                measurement.Add(txt.Text);
            }
            List<IngredientMeasurement> ingredientMeasurements = new List<IngredientMeasurement>();

            for (int i = 0; i < ingredientList.Children.Count; i++)
            {
                ingredientMeasurements.Add(new IngredientMeasurement(ingredients[i].ingredientId, measurement[i]));
            }
            newRecipe.RecipeIngredients = ingredientMeasurements;
            var response = await CookBookAPIUtil.AddRecipe(newRecipe);

            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
                List_Recipe list_Recipe = new List_Recipe();
                list_Recipe.Show();

            }
        }

        private void btnAddMore_Click(object sender, RoutedEventArgs e)
        {

            ComboBox cmbIngredient = new ComboBox();
            cmbIngredient.ItemsSource = Ingredients;
            cmbIngredient.DisplayMemberPath = "ingredientName";
            cmbIngredient.SelectedValuePath = "ingredientId";
            cmbIngredient.Width = 150;
            cmbIngredient.Height = 20;
            this.ingredientList.Children.Add(cmbIngredient);

            TextBox txtBox = new TextBox();
            txtBox.Height = 20;
            txtBox.Width = 150;
            this.measurements.Children.Add(txtBox);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var response = await CookBookAPIUtil.GetAllIngredients();
            if (response != null)
            {
                Ingredients = (List<Ingredient>)response;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            List_Recipe list_Recipe = new List_Recipe();
            list_Recipe.Show();
        }
    }
}
