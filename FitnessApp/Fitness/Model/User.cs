using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }

        public Gender Gender { get; set; } 

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть Null.", nameof(gender));
            }
           
            if(birthdate < DateTime.Parse("01.01.1929") || birthdate >= DateTime.Now)
            {
                throw new ArgumentException("Некорректная дата.", nameof(birthdate));
            }
            
            if (weight <= 10)
            {
                throw new ArgumentException("Некорретный вес.", nameof(weight));
            }
           
            if (height <= 0)
            {
                throw new ArgumentException("Некорректный рост.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Weight = weight;
            Height = height;
        }
       
        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }

    }
}
