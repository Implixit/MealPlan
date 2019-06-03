using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MealPlan.Views
{
    public class HomePage : ContentPage
    {
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        //string _dbIngredientPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "IngredientDB.db3");
        public string state;
        public HomePage()
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<meals>();
            //db = new SQLiteConnection(_dbIngredientPath);
            //db.CreateTable<Ingredients>();
            this.Title = "Select an option"; //Title page
            StackLayout stacklayout = new StackLayout();

            Label PageTitle = new Label();
            PageTitle.Text = "Welcome, What would you like to do?";
            PageTitle.FontSize = 30;
            PageTitle.FontAttributes = FontAttributes.Bold;
            stacklayout.Children.Add(PageTitle);

            Button BtnAddMeal = new Button();
            BtnAddMeal.Text = "Add a New Meal";
            BtnAddMeal.Clicked += BtnAddMeal_Clicked;
            stacklayout.Children.Add(BtnAddMeal);

            Button BtnListIngredients = new Button();
            BtnListIngredients.Text = "View All Meals";
            BtnListIngredients.Clicked += BtnListIngredients_Clicked;
            stacklayout.Children.Add(BtnListIngredients);



            Content = stacklayout;
            
        }

        private  void BtnListIngredients_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MealDetailPage("ListIngredient"));
        }

        private async void BtnListMeals_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealDetailPage("AllMeals"));
        }

        private async void BtnAddMeal_Clicked(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
           
=======
            meals NullMeal = new meals();
>>>>>>> Stashed changes

            await Navigation.PushModalAsync(new MealDetailPage("AddMeal", NullMeal));
        }

        private async void BtnAddIngredient_Clicked(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            
=======
            //await Navigation.PushAsync(new MealDetailPage("AddIngredient"));
>>>>>>> Stashed changes
        }
    }
}
    
