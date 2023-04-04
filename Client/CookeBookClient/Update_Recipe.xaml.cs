using CookBookClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for Update_Recipe.xaml
    /// </summary>
    public partial class Update_Recipe : Window
    {
        Recipe UpdateRecipe;
        List<Ingredient> Ingredients;
        int numberOfIngredients;
        Selected_Recipe Selected_RecipeWindow;
        public Update_Recipe()
        {
            InitializeComponent();
        }
        public Update_Recipe(Recipe recipe, Selected_Recipe selected_Recipe)
        {
            InitializeComponent();
            this.UpdateRecipe = recipe;

            this.txtRecipeId.Text = recipe.recipeId.ToString();
            this.txtRecipeName.Text = recipe.recipeName;
            this.txtCuisine.Text = recipe.cuisine;
            this.txtDescription.Text = recipe.description;
            this.txtInstruction.Text = recipe.instruction;
            this.txtPrepTime.Text = recipe.prepTime;
            this.txtRating.Text = recipe.rating;
            this.txtPrepVideoUrl.Text = recipe.prepVideoUrl;
            this.txtComplexity.Text = recipe.complexity;
            this.txtNumberOfIngredients.Text = recipe.numberOfIngredients.ToString();
            this.numberOfIngredients = Int32.Parse(recipe.numberOfIngredients.ToString());
            this.Selected_RecipeWindow = selected_Recipe;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Selected_Recipe selected_Recipe = new Selected_Recipe(UpdateRecipe);
            selected_Recipe.Show();
        }



        private async void btnUpdateRecipe_Click(object sender, RoutedEventArgs e)

        {
            int id = Int32.Parse(txtRecipeId.Text.Trim());

            RecipeCreation updatedRecipe = new RecipeCreation();
            updatedRecipe.RecipeName = this.txtRecipeName.Text;
            updatedRecipe.Cuisine = this.txtCuisine.Text;
            updatedRecipe.Description = this.txtDescription.Text;
            updatedRecipe.Instruction = this.txtInstruction.Text;
            updatedRecipe.PrepTime = this.txtPrepTime.Text;
            updatedRecipe.Rating = this.txtRating.Text;
            updatedRecipe.PrepVideoUrl = this.txtPrepVideoUrl.Text;
            updatedRecipe.Complexity = this.txtComplexity.Text;
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
            List<Recipeingredient> Recipeingredients = new List<Recipeingredient>();

            for (int i = 0; i < numberOfIngredients; i++)
            {
                ingredientMeasurements.Add(new IngredientMeasurement(ingredients[i].ingredientId, measurement[i]));
                Recipeingredients.Add(new Recipeingredient(measurement[i], ingredients[i]));
            }
            updatedRecipe.RecipeIngredients = ingredientMeasurements;
            var response = await CookBookAPIUtil.UpdateRecipe(id, updatedRecipe);

            Recipe recipe = new Recipe(id, updatedRecipe.RecipeName, updatedRecipe.Cuisine, updatedRecipe.Description,
                          updatedRecipe.Instruction, updatedRecipe.PrepTime, updatedRecipe.Rating, updatedRecipe.PrepVideoUrl,
                          updatedRecipe.Complexity, numberOfIngredients, Recipeingredients);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
                Selected_Recipe selected_Recipe = new Selected_Recipe(recipe);
                selected_Recipe.Show();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var response = await CookBookAPIUtil.GetAllIngredients();
            Ingredients = (List<Ingredient>)response;

            foreach (Recipeingredient ri in UpdateRecipe.recipeIngredients)
            {
                ComboBox cmbIngredient = new ComboBox();

                cmbIngredient.ItemsSource = Ingredients;
                cmbIngredient.DisplayMemberPath = "ingredientName";
                cmbIngredient.SelectedValuePath = "ingredientId";
                cmbIngredient.SelectedValue = ri.ingredient.ingredientId;
                cmbIngredient.Width = 150;
                cmbIngredient.Height = 20;
                this.ingredientList.Children.Add(cmbIngredient);

                TextBox txtBox = new TextBox();
                txtBox.Text = ri.measurement;
                txtBox.Height = 20;
                txtBox.Width = 150;
                this.measurements.Children.Add(txtBox);
            }

        }
    }
}
