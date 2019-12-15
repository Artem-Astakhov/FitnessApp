using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Fitness.Controller
{
    public class UserController
    {
    
        public User User { get; }

        public UserController (User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть Null", nameof(user));
        }
        
        public bool Save(User User)
        {

        }



    }
}
