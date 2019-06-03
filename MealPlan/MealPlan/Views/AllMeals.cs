using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MealPlan.Views
{
    public class AllMeals : ContentPage
    {
        private ListView listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AllMeals()
        {
            listView = new ListView()
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Meal Name");
                    

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
                                        nameLabel,
                                        
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
            listView.ItemsSource = db.Table<meals>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;

        }
    }
}