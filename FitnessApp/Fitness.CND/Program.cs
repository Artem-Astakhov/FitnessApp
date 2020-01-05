using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.Controller;
using Fitness.Model;

namespace Fitness.CND
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            Console.WriteLine("Fitness App!");
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();                
                var birthDate = ParseDate();

                Console.Write("Введите свой вес: ");
                var weight = ParseDouble("вес");
                
                Console.Write("Введите свой рост: ");
                var height = ParseDouble("рост");
              
                userController.SetNewUserDate(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что сделать? ");
            Console.WriteLine("1 - ввести прием пищи.");
            var key = int.Parse(Console.ReadLine());

            switch (key)
            {
                case 1:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);
                    foreach(var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t {item.Key} - {item.Value}");
                    }
                    break;
            }

            


            Console.ReadLine();
        }

       
        
        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта:");
            var food = Console.ReadLine();
            
            var calories = ParseDouble("калорийность: ");
            var protein = ParseDouble("белки: ");
            var fats = ParseDouble("жири: ");
            var carbohydrates = ParseDouble("углеводи: ");
            
            var weight = ParseDouble("вес порции");

            var product = new Food(food, protein, fats, carbohydrates);
            return (Food: product, Weight: weight);
        }
        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (дд. мм. гггг) : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный формат даты! ");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                double value;
                Console.Write($"Введите {name}:");
                if(Double.TryParse(Console.ReadLine(), out value))
                {
                    return value;                   
                }
                else
                {
                    Console.WriteLine($"Введите {name} в числовом формате");
                }              
            }
        }
    }
}
