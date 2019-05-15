using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan
{
    public class meals
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
