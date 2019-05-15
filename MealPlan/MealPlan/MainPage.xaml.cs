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
        public MainPage()
        {
            InitializeComponent();

            meals = new List<meals>();
            meals.Add(new meals
            {
                ID = 1,
                Name = "Meal 1"
            });

            meals.Add(new meals
            {
                ID = 2,
                Name = "Meal 2"
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
    }
}
