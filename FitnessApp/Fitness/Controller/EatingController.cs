using Fitness.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Controller
{
    [Serializable]
   public class EatingController:ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eatings.dat";
        
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть Null", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEatings();
        }

        private List<Food> GetAllFoods()
        {
           return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private Eating GetEatings()
        {
            return Load<Eating> (EATING_FILE_NAME) ?? new Eating(user);
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }     

        public void Add(Food food, double weigth)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weigth);
                Save();
            }
            else
            {
                Eating.Add(product, weigth);
                Save();
            }
        }
    }
}
