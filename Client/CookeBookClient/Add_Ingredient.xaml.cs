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
    /// Interaction logic for Add_Ingredient.xaml
    /// </summary>
    public partial class Add_Ingredient : Window
    {
        Ingredient addIngredient { get; set; }
        int addIngredientId = 0;
        public Add_Ingredient()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            List_Ingredient list = new List_Ingredient();
            list.Show();
            this.Close();
        }

        private async void btnAddIngridient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient newIngredient = new Ingredient();
            newIngredient.ingredientName = txtIngredientName.Text;
            var response = await CookBookAPIUtil.AddIngredient(newIngredient);
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
