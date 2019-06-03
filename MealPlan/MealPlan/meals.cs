using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan
{
    public class meals
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Ingredient { get; set; }
        //public int Ingredients_1 { get; set; }
        //public int Ingredients_2 { get; set; }
        //public int Ingredients_3 { get; set; }
        //public int Ingredients_4 { get; set; }
        //public int Ingredients_5 { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
