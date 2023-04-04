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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookeBookClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            List_Recipe recipeWindow = new List_Recipe(this);
            recipeWindow.Show();
            this.Hide();
        }

        private void btnAllIngredients_Click(object sender, RoutedEventArgs e)
        {
            List_Ingredient ingredient = new List_Ingredient();
            ingredient.Show();
            this.Close();
        }



    }
}
