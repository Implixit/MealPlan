using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MealPlan.Views;


using Xamarin.Forms;

namespace MealPlan.Views
{
    public class AllMeals : ContentPage
    {
        private ListView listView;
        private Button button;
        meals SelectedMeal = new meals();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AllMeals()
        {
            //Layout of the Page
            Label PageTitle = new Label();
            PageTitle.Text = "Here is a list of all your meals";
            PageTitle.FontAttributes = FontAttributes.Bold;
            PageTitle.FontSize = 20;
            
            // Format for Each of the meal
            listView = new ListView()
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");


                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(10, 2),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Spacing = 0,
                                    Children =
                                    {
                                        nameLabel
                                        
                                    }
                                }
                            }
                        }
                    };

                })
            };

            this.Title = "All Meals";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            // Get data from DB and order by Name 
            listView.ItemsSource = db.Table<meals>().OrderBy(x => x.Name).ToList();
            // If user selected an item 
            listView.ItemSelected += ListView_ItemSelected;

            stackLayout.Children.Add(PageTitle);

            stackLayout.Children.Add(listView);

            button = new Button();// Back to home page
            button.Text = "Back";
            button.Clicked += BackButton_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedMeal = (meals)e.SelectedItem;// Selected Meal will send to the detail page 
            await Navigation.PushModalAsync(new MealDetailPage("Detail", SelectedMeal));
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            // Back to home page 
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}