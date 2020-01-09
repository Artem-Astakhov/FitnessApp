using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
