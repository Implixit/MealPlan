﻿using SQLite;
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
        private Editor method;
        private Label pageTitle;
        private Editor ingredientsEditor;



        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
       // string _dbIngredientPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "IngredientDB.db3");
        meals Meal = new meals();


        public MealDetailPage(string state)
        {
           
            
            StackLayout stackLayout = new StackLayout();
            switch (state)
            {
                case "AddMeal":
                    
                    this.Title = "Add of Meal";

                    pageTitle = new Label();
                    pageTitle.Text = "Add a Meal";
                    pageTitle.FontAttributes = FontAttributes.Bold;
                    pageTitle.FontSize = 25;
                    pageTitle.HorizontalTextAlignment = TextAlignment.Center;
                    stackLayout.Children.Add(pageTitle);

                    
                    titleEntry = new Entry();
                    titleEntry.Keyboard = Keyboard.Text;
                    titleEntry.Placeholder = "Meal Name";
                    stackLayout.Children.Add(titleEntry);

                    ingredientsEditor = new Editor();
                    ingredientsEditor.Placeholder = "Enter your ingredients";
                    ingredientsEditor.Keyboard = Keyboard.Text;
                    ingredientsEditor.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(ingredientsEditor);
                   
                    method = new Editor();
                    method.Placeholder = "Enter your method";
                    method.Keyboard = Keyboard.Text;
                    method.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(method);

                    button = new Button();
                    button.Text = "Add";
                    button.Clicked += AddButton_Clicked;
                    stackLayout.Children.Add(button);

                    button = new Button();
                    button.Text = "Cancel";
                    button.Clicked += CancelButton_Clicked;
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

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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