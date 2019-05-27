using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MealPlan.Views
{
    public class HomePage : ContentPage
    {
        public string state;
        public HomePage()
        {
            this.Title = "Select an option"; //Title page
            StackLayout stacklayout = new StackLayout();

            Button BtnAddMeal = new Button();
            BtnAddMeal.Text = "Add a New Meal";
            BtnAddMeal.Clicked += BtnAddMeal_Clicked;
            stacklayout.Children.Add(BtnAddMeal);

            Button BtnListMeals = new Button();
            BtnListMeals.Text = "Get List of Meals";
            BtnListMeals.Clicked += BtnListMeals_Clicked;
            stacklayout.Children.Add(BtnListMeals);

            Button BtnAddIngredient = new Button();
            BtnAddIngredient.Text = "Add a New Ingredient";
            BtnAddIngredient.Clicked += BtnAddIngredient_Clicked;
            stacklayout.Children.Add(BtnAddIngredient);

            Button BtnListIngredients = new Button();
            BtnListIngredients.Text = "Get List of Ingredients";
            BtnListIngredients.Clicked += BtnListIngredients_Clicked;
            stacklayout.Children.Add(BtnListIngredients);

            Content = stacklayout;
        }

        private async void BtnListIngredients_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MealDetailPage("ListIngredient"));
        }

        private async void BtnListMeals_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MealDetailPage("ListMeals"));
        }

        private async void BtnAddMeal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealDetailPage("AddMeal"));
        }

        private async void BtnAddIngredient_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealDetailPage("AddIngredient"));
        }
    }
}
    
