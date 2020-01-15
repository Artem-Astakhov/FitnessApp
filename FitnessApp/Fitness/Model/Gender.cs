using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace Fitness.Model
{
   /// <summary>
   /// Пол.
   /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
       
        /// <summary>
        /// Название.
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"></param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
  
}