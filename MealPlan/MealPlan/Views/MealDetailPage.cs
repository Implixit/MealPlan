using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MealPlan.Views
{
    public class MealDetailPage : ContentPage
    {

        
        private Button button;
        private Entry titleEntry;
        private Picker ingredient1;
        private Picker ingredient2;
        private Picker ingredient3;
        private Picker ingredient4;
        private Picker ingredient5;
        private Editor method;



        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        string _dbIngredientPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "IngredientDB.db3");
        meals Meal = new meals();


        public MealDetailPage(string state)
        {
            var db = new SQLiteConnection(_dbIngredientPath);
            List<Ingredients> ingredients = db.Table<Ingredients>().OrderBy(x => x.ID).ToList();
            var picker = new Picker { Title = "Select a Ingredient" };
            
            StackLayout stackLayout = new StackLayout();
            switch (state)
            {
                case "AddMeal":
                    
                    this.Title = "Add of Meal";

                    titleEntry = new Entry();
                    titleEntry.Keyboard = Keyboard.Text;
                    titleEntry.Placeholder = "Meal Name";
                    stackLayout.Children.Add(titleEntry);

                    ingredient1 = picker;
                    ingredient1.Title = "Choose an Ingredient";
                    ingredient1.ItemsSource = ingredients;
                    stackLayout.Children.Add(ingredient1);

                    ingredient2 = picker;
                    ingredient2.Title = "Choose an Ingredient";
                    //ingredient2.ItemsSource; DATABASE LINK GOES HERE
                    stackLayout.Children.Add(ingredient2);

                    ingredient3 = picker;
                    ingredient3.Title = "Choose an Ingredient";
                    //ingredient3.ItemsSource; DATABASE LINK GOES HERE
                    stackLayout.Children.Add(ingredient3);

                    ingredient4 = picker;
                    ingredient4.Title = "Choose an Ingredient";
                    //ingredient4.ItemsSource; DATABASE LINK GOES HERE
                    stackLayout.Children.Add(ingredient4);

                    ingredient5 = picker;
                    ingredient5.Title = "Choose an Ingredient";
                    //ingredient5.ItemsSource; DATABASE LINK GOES HERE
                    stackLayout.Children.Add(ingredient5);

                    method = new Editor();
                    method.Placeholder = "Enter your method";
                    method.Keyboard = Keyboard.Text;
                    stackLayout.Children.Add(method);

                    button = new Button();
                    button.Text = "Add";
                    button.Clicked += AddButton_Clicked;
                    stackLayout.Children.Add(button);

                    break;
                case "EditMeal" :
                    button = new Button();
                    button.Text = "Update";
                    button.Clicked += UpdateButton_Clicked;
                    stackLayout.Children.Add(button);
                    break;
                case "DeleteMeal":

                    button = new Button();
                    button.Text = "Detele";
                    button.Clicked += DeteleButton_Clicked;
                    stackLayout.Children.Add(button);
                    break;

                default: //error 
                    DisplayAlert("ERROR", "There is an Error. Please Try again", "Back");
                    base.OnBackButtonPressed();
                    break;

            }

        }



        private void DeteleButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
           

            var maxPK = db.Table<meals>().OrderByDescending(c => c.ID).FirstOrDefault();

            meals newMeal = new meals()
            {
                ID = (maxPK == null ? 1 : maxPK.ID + 1),
                Name = titleEntry.Text
            };
            db.Insert(newMeal);
            await DisplayAlert(null, newMeal.Name + "Saved", "OK");
            await Navigation.PopAsync();
        }
    }
}