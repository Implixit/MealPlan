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
        //Form
        private Button button;

        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        meals Meal = new meals();

        public MealDetailPage (string state)
		{
            
            this.Title = "Detail of Meal";
            StackLayout stackLayout = new StackLayout();
            switch (state)
            {
                case "AddMeal" :
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
            Content = stackLayout;


        }

        private void DeteleButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<meals>();

            var maxPK = db.Table<meals>().OrderByDescending(c => c.ID).FirstOrDefault();

            meals newMeal = new meals()
            {
                ID = (maxPK == null ? 1 : maxPK.ID + 1),

            };
        }
    }
}