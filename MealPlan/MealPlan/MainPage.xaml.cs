using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealPlan
{
    public partial class MainPage : ContentPage
    {
        //Meal List
        public IList<meals> meals { get; set; }
        public IList<Ingredients> ingredients { get; set; }
        public MainPage()
        {
            InitializeComponent();

            meals = new List<meals>();
            ingredients = new List<Ingredients>();
            ingredients.Add(new Ingredients
            {
                ID = 1,
                Name = "Ingredients 1"
            });
            ingredients.Add(new Ingredients
            {
                ID = 1,
                Name = "Ingredients 2"
            });
            meals.Add(new meals
            {
                ID = 1,
                Name = "Meal 1",
                Ingredients_1 = 1
            });

            meals.Add(new meals
            {
                ID = 2,
                Name = "Meal 2",
                Ingredients_2 =2
            });
            
            BindingContext = this;
        }
        public void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            meals selectedItem = e.SelectedItem as meals;
            
            
        }
        public void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            meals tappedItem = e.Item as meals;
        }

        private void CreateMeal(object sender, EventArgs e)
        {
            NewMeal newPage = new NewMeal();
            Application.Current.MainPage = newPage;
        }
    }
}
