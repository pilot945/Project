﻿using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public static class UserService
    {  
        public static User Find(string login, string password)
        { 
          var user = new User();
            using (var context = new SQLServerDBContext())
            {
                return context.Users.Where(u => u.Password == password && u.Login == login).FirstOrDefault();
            }
        }

        public static void AddUser(string lastName, string firstName, string middleName, string login, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Login = login,
                IsDeleted = false,
                Password = password
            };

            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.AddAsync(user);
                    context.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Пользователь добавлен!");
        }
        public static void UpdateUser(User user, string lastName, string firstName, string middleName, string login, string password)
        {

            user.LastName = lastName;
            user.FirstName = firstName;
            user.MiddleName = middleName;
            user.Login = login;
            user.Password = password;


            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Пользователь обновлён");
        }
        public static void DeleteUser(User user)
        {
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Users.Remove(user);
                    context.SaveChangesAsync();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Пользователь удалён");
        }
        public static void Hide(User user)
        {
            user.IsDeleted = true;
            using (var context = new SQLServerDBContext())
            {
                context.Users.Update(user);
                context.SaveChangesAsync();

            }
            Debug.WriteLine("Пользователь скрыт");
        }


    }
}
