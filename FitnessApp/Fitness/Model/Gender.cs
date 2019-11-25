using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Fitness.Model
{
    public class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
  
}