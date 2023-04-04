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
    /// Interaction logic for Update_Ingredient.xaml
    /// </summary>
    public partial class Update_Ingredient : Window
    {
        Ingredient patchIngredient { get; set; }
        public int IdIngredient { get; set; }
        public string NameIngredient { get; set; }
        Ingredient updIngredient { get; set; }
        public Update_Ingredient(int id, string name)
        {
            InitializeComponent();
            IdIngredient = id;
            NameIngredient = name;
            txtIngredientName.Text = name;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            List_Ingredient list = new List_Ingredient();
            list.Show();
            this.Close();
        }
        private async void btnUpdateIngridient_Click(object sender, RoutedEventArgs e)
        {
            NameIngredient = txtIngredientName.Text;
            updIngredient = new Ingredient { ingredientId = IdIngredient, ingredientName = NameIngredient };
            var response = await CookBookAPIUtil.UpdateIngredient(updIngredient);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                List_Ingredient list = new List_Ingredient();
                list.Show();
                this.Close();
            }

        }
        private async void btnPatchIngridient_Click(object sender, RoutedEventArgs e)
        {
            NameIngredient = txtIngredientName.Text;
            patchIngredient = new Ingredient { ingredientId = IdIngredient, ingredientName = NameIngredient };
            var response = await CookBookAPIUtil.PatchIngredient(patchIngredient);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                List_Ingredient list = new List_Ingredient();
                list.Show();
                this.Close();
            }
        }
    }
}
