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
    /// Interaction logic for Selected_Ingredient.xaml
    /// </summary>
    public partial class Selected_Ingredient : Window
    {
        public int IdIngredient { get; set; }
        public string NameIngredient { get; set; }
        public Selected_Ingredient(int id, string name)
        {
            IdIngredient = id;
            NameIngredient = name;
            InitializeComponent();
        }
        private void Loaded_Ingredient(object sender, RoutedEventArgs e)
        {
            txtBlIngredientName.Text = NameIngredient;
        }

        private async void btnUpdateIngredient_Click(object sender, RoutedEventArgs e)
        {
            Update_Ingredient update_Ingredient = new Update_Ingredient(IdIngredient, NameIngredient);
            update_Ingredient.Show();
            this.Hide();
        }

        private async void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            var response = await CookBookAPIUtil.DeleteIngredient(IdIngredient);
            MessageBoxResult result = MessageBox.Show(response);
            if (result == MessageBoxResult.OK)
            {
                List_Ingredient list = new List_Ingredient();
                list.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            List_Ingredient list = new List_Ingredient();
            list.Show();
            this.Close();
        }


    }
}
