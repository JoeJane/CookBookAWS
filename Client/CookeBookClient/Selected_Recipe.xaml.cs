using CookBookClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Selected_Recipe.xaml
    /// </summary>
    public partial class Selected_Recipe : Window
    {
        Recipe selectedRecipe;
        List_Recipe ListRecipeWindow;
        public Selected_Recipe()
        {
            InitializeComponent();
        }
        public Selected_Recipe(Recipe recipe)
        {
            InitializeComponent();
            this.selectedRecipe = recipe;
            this.txtBlRecipeName.Text = recipe.recipeName;
            this.txtBlCuisine.Text = recipe.cuisine;
            this.txtBlDescription.Text = recipe.description;
            this.txtBlInstruction.Text = recipe.instruction;
            this.txtBlPrepTime.Text = recipe.prepTime;
            this.txtBlRating.Text = recipe.rating;
            if (recipe.prepVideoUrl != null)
            {
                linkprepurl.NavigateUri = new Uri(recipe.prepVideoUrl);
            }
            this.txtBlComplexity.Text = recipe.complexity;
            this.txtBlNumberOfIngredients.Text = recipe.numberOfIngredients.ToString();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Recipeingredient ingredient in recipe.recipeIngredients)
            {
                stringBuilder.AppendLine(ingredient.ToString() + "\n");
            }
            this.txtBlIngredients.Text = stringBuilder.ToString();
        }
        public Selected_Recipe(Recipe recipe, List_Recipe list_RecipeWindow)
        {
            InitializeComponent();
            this.selectedRecipe = recipe;
            this.ListRecipeWindow = list_RecipeWindow;
            this.txtBlRecipeName.Text = recipe.recipeName;
            this.txtBlCuisine.Text = recipe.cuisine;
            this.txtBlDescription.Text = recipe.description;
            this.txtBlInstruction.Text = recipe.instruction;
            this.txtBlPrepTime.Text = recipe.prepTime;
            this.txtBlRating.Text = recipe.rating;
            if (recipe.prepVideoUrl != null)
            {
                linkprepurl.NavigateUri = new Uri(recipe.prepVideoUrl);
            }
            this.txtBlComplexity.Text = recipe.complexity;
            this.txtBlNumberOfIngredients.Text = recipe.numberOfIngredients.ToString();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Recipeingredient ingredient in recipe.recipeIngredients)
            {
                stringBuilder.AppendLine(ingredient.ToString() + "\n");
            }
            this.txtBlIngredients.Text = stringBuilder.ToString();

        }



        private void btnUpdateRecipe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Update_Recipe update_Recipe = new Update_Recipe(selectedRecipe, this);
            update_Recipe.Show();
        }

        private async void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            var response = await CookBookAPIUtil.DeleteRecipe(selectedRecipe.recipeId);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
                List_Recipe list_Recipe = new List_Recipe();
                list_Recipe.Show();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            List_Recipe list_Recipe = new List_Recipe();
            list_Recipe.Show();
        }

        private void linkprepurl_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void btnPatch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UpdateMeasurement updateMeasurement = new UpdateMeasurement(selectedRecipe);
            updateMeasurement.Show();
        }
    }
}
