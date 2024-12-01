﻿using RestaurantChain.DataBase.Entity.User;
using RestaurantChain.DataBase.Repositories;
using RestaurantChain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model
{
    /// <summary>
    /// Менеджер данных для взаимодействия с базой данных
    /// </summary>
    public class DataManager
    {
        public IUserData CurrentUser { get; set; }
        public IRepository<IUserData> UserRepository { get; set; }

        public void Inject(IRepository<IUserData> userRepository)
        {
            UserRepository = userRepository;
        }

        private static DataManager _instance;
        
        /// <summary>
        /// Получение объекта класса при вызове метода.
        /// </summary>
        /// <returns>Объект класса.</returns>
        public static DataManager GetInstance()
        {
            if (_instance == null)
                _instance = new DataManager();
            return _instance;
        }
    }
}