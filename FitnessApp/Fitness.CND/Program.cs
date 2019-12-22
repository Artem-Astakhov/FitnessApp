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
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.WriteLine("Fitness App!");
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();                
                var birthDate = ParseDate();

                Console.Write("Введите свой вес: ");
                var weight = Double.Parse(Console.ReadLine());
                //TODO Сделать проверку.
                Console.Write("Введите свой рост: ");
                var height = Double.Parse(Console.ReadLine());
                //TODO Сделать проверку.

                userController.SetNewUserDate(gender, birthDate, weight, height);
            }






            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
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
    }
}
