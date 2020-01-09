using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
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
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CND.Languages.Messages",typeof(Program).Assembly);
           
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exercisesConrroller = new ExerciseController(userController.CurrentUser);

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
            Console.WriteLine("2 - ввести упражнение. ");
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
                case 2:
                    var exercises = EnterExercise();
                    exercisesConrroller.Add(exercises.activity, exercises.begin, exercises.end);
                    foreach(var item in exercisesConrroller.Exersises)
                    {
                        Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                    }
                    break;
            }

            


            Console.ReadLine();
        }

       
        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            Console.WriteLine("введите название упражнения: ");
            var name = Console.ReadLine();
            var start = ParseTime("начало упражнения ");
            var end = ParseTime("конец упражнения ");
            var energy = ParseDouble("расход енергии в минуту ");
            var act = new Activity(name, energy);

            return (start, end, act);


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

        private static DateTime ParseTime(string value)
        {
            DateTime time;
            
            while (true)
            {
                Console.Write($"введите {value} в формате чч:мм : ");
                if (DateTime.TryParse(Console.ReadLine(), out time))
                {
                    return time;
                }
                else
                {
                    Console.WriteLine($"Введите {value} в формате чч:мм :");
                }

            }
            
        }
    }
}
