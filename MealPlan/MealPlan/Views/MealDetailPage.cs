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
        //use in the layout 
        private Button button;
        private Entry titleEntry;
        private Entry MealID;
        private Editor method;
        private Label pageTitle;
        private Editor ingredientsEditor;



        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
       
        meals Meal = new meals();

        // state is received from other place: ADD , View , Change
        // SelectedMeal is received the meal from elsewhere. e.g. All meal page , and current page
        public MealDetailPage(string state, meals SelectedMeal)
        {                
            StackLayout stackLayout = new StackLayout();
            switch (state)
            {
               // ADD function 
                case "AddMeal":
                    // Layout 
                    this.Title = "Add of Meal";
                    Meal = new meals();
                    pageTitle = new Label();
                    pageTitle.Text = "Add a Meal";
                    pageTitle.FontAttributes = FontAttributes.Bold;
                    pageTitle.FontSize = 25;
                    pageTitle.HorizontalTextAlignment = TextAlignment.Center;
                    stackLayout.Children.Add(pageTitle);

                    
                    titleEntry = new Entry(); //requiment
                    titleEntry.Keyboard = Keyboard.Text;
                    titleEntry.Placeholder = "Meal Name";
                    stackLayout.Children.Add(titleEntry);

                    ingredientsEditor = new Editor(); //requiment
                    ingredientsEditor.Placeholder = "Enter your ingredients";
                    ingredientsEditor.Keyboard = Keyboard.Text;
                    ingredientsEditor.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(ingredientsEditor);
                   
                    method = new Editor();//requiment
                    method.Placeholder = "Enter your method";
                    method.Keyboard = Keyboard.Text;
                    method.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(method);

                    button = new Button();//Add button 
                    button.Text = "Add";
                    button.Clicked += AddButton_Clicked;
                    stackLayout.Children.Add(button);

                    button = new Button();// Cancel button 
                    button.Text = "Cancel";
                    button.Clicked += CancelButton_Clicked;
                    stackLayout.Children.Add(button);

                    
                    break;
                // View of the detail page 
                case "Detail":
                    //layout most of them is read only 
                    Meal = new meals();//Empty the Meal
                    pageTitle = new Label();
                    pageTitle.Text = "Detail a Meal";
                    pageTitle.FontAttributes = FontAttributes.Bold;
                    pageTitle.FontSize = 25;
                    pageTitle.HorizontalTextAlignment = TextAlignment.Center;
                    stackLayout.Children.Add(pageTitle);


                    titleEntry = new Entry(); //requiment
                    titleEntry.Keyboard = Keyboard.Text;
                    titleEntry.Placeholder = "Meal Name";
                    titleEntry.Text = SelectedMeal.Name;
                    titleEntry.IsReadOnly = true;
                    stackLayout.Children.Add(titleEntry);

                    ingredientsEditor = new Editor(); //requiment
                    ingredientsEditor.Placeholder = "Enter your ingredients";
                    ingredientsEditor.Text = SelectedMeal.Ingredient;
                    ingredientsEditor.IsReadOnly = true;
                    ingredientsEditor.Keyboard = Keyboard.Text;
                    ingredientsEditor.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(ingredientsEditor);

                    method = new Editor();//requiment
                    method.Placeholder = "Enter your method";
                    method.Text = SelectedMeal.Method;
                    method.IsReadOnly = true;
                    method.Keyboard = Keyboard.Text;
                    method.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(method);

                    
                    button = new Button();// Back to the List of all meal
                    button.Text = "Back";
                    button.Clicked += CancelButton_Clicked;
                    stackLayout.Children.Add(button);

                    button = new Button();// Edit selected meal 
                    button.Text = "Change";
                    button.Clicked += ChangeButton_clicked; ;
                    stackLayout.Children.Add(button);

                    Meal = SelectedMeal; //store the selected Meal
                    break;
                //Able to change field 
                case "Change":
                    //layout 
                    Meal = new meals(); //Empty the Meal
                    pageTitle = new Label();
                    pageTitle.Text = "Edit a Meal";
                    pageTitle.FontAttributes = FontAttributes.Bold;
                    pageTitle.FontSize = 25;
                    pageTitle.HorizontalTextAlignment = TextAlignment.Center;
                    stackLayout.Children.Add(pageTitle);

                    MealID = new Entry();
                    MealID.Text = SelectedMeal.ID.ToString();
                    MealID.IsReadOnly = true;
                    stackLayout.Children.Add(MealID);

                    titleEntry = new Entry(); //requiment
                    titleEntry.Keyboard = Keyboard.Text;
                    titleEntry.Placeholder = "Meal Name";
                    titleEntry.Text = SelectedMeal.Name;
                    stackLayout.Children.Add(titleEntry);

                    ingredientsEditor = new Editor(); //requiment
                    ingredientsEditor.Placeholder = "Enter your ingredients";
                    ingredientsEditor.Text = SelectedMeal.Ingredient;
                    ingredientsEditor.Keyboard = Keyboard.Text;
                    ingredientsEditor.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(ingredientsEditor);

                    method = new Editor();//requiment
                    method.Placeholder = "Enter your method";
                    method.Text = SelectedMeal.Method;
                    method.Keyboard = Keyboard.Text;
                    method.AutoSize = EditorAutoSizeOption.TextChanges;
                    stackLayout.Children.Add(method);


                    button = new Button();//back to the List of all meal
                    button.Text = "Back";
                    button.Clicked += CancelButton_Clicked;
                    stackLayout.Children.Add(button);

                    button = new Button(); // Deleted selected meal 
                    button.Text = "Detele";
                    button.Clicked += DeteleButton_Clicked;
                    stackLayout.Children.Add(button);
                    button = new Button();// Save the change 
                    button.Text = "Save";
                    button.Clicked += UpdateButton_Clicked;
                    stackLayout.Children.Add(button);


                    Meal = SelectedMeal; //store the selected Meal 
                    break;


                default: // if there are any error 
                    DisplayAlert("ERROR", "There is an Error. Please Try again", "Back");
                    base.OnBackButtonPressed();
                    break;

            }
            Content = stackLayout;
        }

        private async void ChangeButton_clicked(object sender, EventArgs e)
        {
            // New page for this page but is not all read only
            await Navigation.PushModalAsync(new MealDetailPage("Change", Meal));
           
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            // back to the All of List
            await Navigation.PushModalAsync(new AllMeals());
        }

        private async void DeteleButton_Clicked(object sender, EventArgs e)
        {
            //Connection to database
            var db = new SQLiteConnection(_dbPath);
            // Vaildation make sure there are no null in the field 
            if (Vaildation())
            {
                // find the ID in stored Meal and Delete the one have the same ID
                db.Table<meals>().Delete(x => x.ID == Meal.ID);
                // Show to user Which one has been deleted.
                await DisplayAlert(null, Meal.Name + " Deleted", "OK");
                //Back to List of all meals
                await Navigation.PushModalAsync(new AllMeals());
            }
            
            
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            //Connection to DB
            var db = new SQLiteConnection(_dbPath);
            // Vaildation make sure there are no null in the field 
            if (Vaildation())
            {
                //Create a meals to store new information 
                meals newMeal = new meals()
                {
                    // These are from the field in the layout
                    ID = Convert.ToInt32(MealID.Text),
                    Name = titleEntry.Text,
                    Method = method.Text,
                    Ingredient = ingredientsEditor.Text
                };
                db.Update(newMeal);// Update above infromation to the database 
                //Show to user they are save what they have change
                await DisplayAlert(null, newMeal.Name + " Saved", "OK");
                //Back to the List of all meals 
                await Navigation.PushModalAsync(new AllMeals());
            }
            
            
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            //Connection in the databse 
            var db = new SQLiteConnection(_dbPath);
            //Vaildtion to make sure there are no empty in all field 
            if (Vaildation())
            {
                //Find Max primary key in current table
                var maxPK = db.Table<meals>().OrderByDescending(c => c.ID).FirstOrDefault();

                meals newMeal = new meals()
                {
                    //Get Max PK in current table and +1 to create a new record 
                    ID = (maxPK == null ? 1 : maxPK.ID + 1),
                    // These information is from the field that let user to enter 
                    Name = titleEntry.Text,
                    Method = method.Text,
                    Ingredient = ingredientsEditor.Text
                };
                // Add to the database
                db.Insert(newMeal);
                // Store information to the Meal 
                Meal = newMeal;
                //Show to user they are save what they have change
                await DisplayAlert(null, newMeal.Name + "Saved", "OK");
                //Back to the Home Page 
                await Navigation.PopModalAsync();
            }
           
            
        }

        //Vaildation to make sure information needed is not empty 
        private bool Vaildation()
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text)  || string.IsNullOrWhiteSpace(method.Text) || string.IsNullOrWhiteSpace(ingredientsEditor.Text))
            {
                // Tell user need to fill all field 
                DisplayAlert(null, "Please complete form to continue", "OK");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}