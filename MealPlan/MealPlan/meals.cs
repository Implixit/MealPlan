using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan
{
    public class meals
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Ingredients_1 { get; set; }
        public int Ingredients_2 { get; set; }
        public int Ingredients_3 { get; set; }
        public int Ingredients_4 { get; set; }
        public int Ingredients_5 { get; set; }
        public int Ingredients_6 { get; set; }
        public int Ingredients_7 { get; set; }
        public int Ingredients_8 { get; set; }
        public int Ingredients_9 { get; set; }
        public int Ingredients_10 { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
