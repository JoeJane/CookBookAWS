using CookBookClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookeBookClient
{
    /// <summary>
    /// Interaction logic for UpdateMeasurement.xaml
    /// </summary>
    public partial class UpdateMeasurement : Window
    {
        Recipe selectedRecipe;
        List<Ingredient> Ingredients;

        public UpdateMeasurement()
        {
            InitializeComponent();
        }

        public UpdateMeasurement(Recipe selected_Recipe)
        {
            InitializeComponent();
            this.selectedRecipe = selected_Recipe;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var response = await CookBookAPIUtil.GetAllIngredients();
            Ingredients = (List<Ingredient>)response;

            foreach (Recipeingredient ri in selectedRecipe.recipeIngredients)
            {

                TextBox txtBoxIngredient = new TextBox();
                txtBoxIngredient.Text = ri.ingredient.ingredientName;
                txtBoxIngredient.Height = 20;
                txtBoxIngredient.Width = 150;
                txtBoxIngredient.IsEnabled = false;
                this.ingredientList.Children.Add(txtBoxIngredient);

                TextBox txtBox = new TextBox();
                txtBox.Text = ri.measurement;
                txtBox.Height = 20;
                txtBox.Width = 150;
                txtBox.Name = "txt" + ri.ingredient.ingredientId.ToString();
                this.measurements.Children.Add(txtBox);
                Button btn = new Button();
                btn.Height = 20;
                btn.Width = 100;
                btn.Background = Brushes.LightBlue;
                btn.Foreground = Brushes.White;
                btn.Content = "update";
                btn.Name = "btn" + ri.ingredient.ingredientId.ToString();
                this.editMeasurement.Children.Add(btn);
                btn.Click += new RoutedEventHandler(ButtonCreatedByCode_Click);

            }

        }
        private async void ButtonCreatedByCode_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.Name.Trim();
            string ingredientId = name.Remove(0, 3).Trim();
            string txtboxName = "txt" + ingredientId;
            string measurement = "";
            foreach (TextBox tb in measurements.Children)
            {
                if (tb.Name.Equals(txtboxName))
                {
                    measurement = tb.Text;
                    break;
                }
            }
            var response = await CookBookAPIUtil.PatchRecipe(selectedRecipe.recipeId, Int32.Parse(ingredientId), measurement);

            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
                Recipe recipe = await CookBookAPIUtil.GetRecipeById(selectedRecipe.recipeId);
                Selected_Recipe selected_Recipe = new Selected_Recipe(recipe);
                this.Hide();
                selected_Recipe.Show();
            }
        }
        private async void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Recipe recipe = await CookBookAPIUtil.GetRecipeById(selectedRecipe.recipeId);
            Selected_Recipe selected_Recipe = new Selected_Recipe(recipe);
            this.Hide();
            selected_Recipe.Show();
        }


    }
}
