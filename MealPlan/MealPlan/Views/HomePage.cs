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
        // connection for DB
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
       
        public string state;
        public HomePage()
        {
            //Connection for DB
            var db = new SQLiteConnection(_dbPath);
            // Create Table for meal
            db.CreateTable<meals>();
            
            // Layout of the page
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


            Button BtnListMeal = new Button();
            BtnListMeal.Text = "View All Meals";
            BtnListMeal.Clicked += BtnListMeals_Clicked;
            stacklayout.Children.Add(BtnListMeal);

            Button BtnRandom = new Button();
            BtnRandom.Text = "Random a  Meals";
            BtnRandom.Clicked += BtnRandom_Clicked;
            stacklayout.Children.Add(BtnRandom);

            Content = stacklayout;

        }

        private async void BtnRandom_Clicked(object sender, EventArgs e)
        {
            meals RanmdomMeal = new meals();
            Random random = new Random();
            var db = new SQLiteConnection(_dbPath);
            
            // min = 1 so not random to 0 
            int RandomID = random.Next(1,db.Table<meals>().OrderBy(c => c.ID).Count()+1);
            //random a number and use it Find that ID in DB
            RanmdomMeal = db.Table<meals>().FirstOrDefault(c => c.ID == RandomID);
            await Navigation.PushModalAsync(new MealDetailPage("Detail", RanmdomMeal));
        }

        private async void BtnListMeals_Clicked(object sender, EventArgs e)
        {
            // Show all List of meal 
            await Navigation.PushModalAsync(new AllMeals());
        }

        private async void BtnAddMeal_Clicked(object sender, EventArgs e)
        {
            // Send a empty meals 
            meals NullMeal = new meals();
            // Send Function and the empty meal
            await Navigation.PushModalAsync(new MealDetailPage("AddMeal", NullMeal));
        }
        

    }
}


