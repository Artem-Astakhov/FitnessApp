using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Controller
{
    public class ExerciseController:ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exersise.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        private readonly User user;

        public List<Exercise> Exersises;
        public List<Activity> Activities;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть Null", nameof(user));
            Exersises = GetAllExersises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExersises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exersises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }

        public void Add (Activity activity, DateTime begin, DateTime finish)
        {           
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            
            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, finish, activity, user);
                Exersises.Add(exercise);               
            }
            else
            {
                var exercise = new Exercise(begin, finish, act, user);
                Exersises.Add(exercise);                
            }
            Save();
        }


    }
}
