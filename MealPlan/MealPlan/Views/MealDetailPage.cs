using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MealPlan.Views
{
    public class MealDetailPage : ContentPage
    {
        private Entry idEntry;
        private Entry nameEntry;
        private Entry courseEntry;
        private Entry addressEntry;
        private Entry emailEntry;
        private Button saveButton;

        public MealDetailPage (string state)
		{
            
            this.Title = "Detail of Meal";
            StackLayout stackLayout = new StackLayout();
            switch (state)
            {
                case "AddMeal" :
                    idEntry = new Entry();
                    idEntry.Keyboard = Keyboard.Text;
                    idEntry.Placeholder = "Student ID";
                    stackLayout.Children.Add(idEntry);

                    nameEntry = new Entry();
                    nameEntry.Keyboard = Keyboard.Text;
                    nameEntry.Placeholder = "Student Name";
                    stackLayout.Children.Add(nameEntry);

                    courseEntry = new Entry();
                    courseEntry.Keyboard = Keyboard.Text;
                    courseEntry.Placeholder = "Course";
                    stackLayout.Children.Add(courseEntry);

                    addressEntry = new Entry();
                    addressEntry.Keyboard = Keyboard.Text;
                    addressEntry.Placeholder = "Address";
                    stackLayout.Children.Add(addressEntry);

                    emailEntry = new Entry();
                    emailEntry.Keyboard = Keyboard.Text;
                    emailEntry.Placeholder = "Email";
                    stackLayout.Children.Add(emailEntry);

                    break;
                case "Edit":

                    break;
                case "DeleteMeal":

                    break;
                case "AddIngredient":

                    break;
                case "EditIngredient":

                    break;
                case "DeleteIngredient":

                    break;
                default: //error 
                    DisplayAlert("ERROR", "There is an Error. Please Try again", "Back");
                    base.OnBackButtonPressed();
                    break;
            }


        }
	}
}