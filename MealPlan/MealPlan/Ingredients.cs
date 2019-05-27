using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan
{
    public class Ingredients
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
