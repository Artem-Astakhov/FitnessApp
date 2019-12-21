using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Fitness.Controller
{
    public class UserController
    {
    
        public User User { get; }

        public UserController (string userName, string genderName, DateTime birthday, double weight, double height )
        {
            var gender = new Gender(genderName);
            var user = new User(userName, gender, birthday, weight, height);
            User = user;
        }
        
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Загрузить данные.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public User Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                var user = (User)formatter.Deserialize(fs);
                return user;
            }
        }

        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user) User = user;
            }

        }

    }
}
