﻿using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Fitness.Controller
{
    
    public class UserController:ControllerBase
    {
        private const string USER_FILE_NAME = "users.dat";
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController (string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) 
            {
                throw new ArgumentNullException("Имя не может быть Null",nameof(userName));
            }

            Users = GetUsersData();
            
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            
            if (CurrentUser == null) 
            { 
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();          
        }
                                   
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);           
        }

        public void SetNewUserDate(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        

    }
}
