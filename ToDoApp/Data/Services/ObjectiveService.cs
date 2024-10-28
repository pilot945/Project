using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public static class ObjectiveService
    {

        public static void AddObject(string title, string description, User creator)
        {
            var objective = new Objective
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreateDate = DateTime.Now,
                Creator = creator,
                //ExecuteDate = null!

            };

            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Objectives.AddAsync(objective);
                    context.SaveChangesAsync();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Задача добавлена!");
        }
        public static void UpdateObject(Objective objective, string title, string description, User assignee )
        {

            objective.Title = title;
            objective.Description = description;
            objective.Assignee = assignee;
           

            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Objectives.Update(objective);
                    context.SaveChanges();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Задача обновлена");
        }
        public static void DeleteObjective(Objective objective)
        {
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Objectives.Remove(objective);
                    context.SaveChangesAsync();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Debug.WriteLine("Задача удалена");
        }

        public static void Hide(Objective objective)
        {
            objective.IsDeleted = true;
            using (var context = new SQLServerDBContext())
            {
                context.Objectives.Update(objective);
                context.SaveChangesAsync();

            }
            Debug.WriteLine("Задача скрыта");
        }
        public static void Execute(Objective objective) 
        {
            objective.IsExecuted = true;
            objective.ExecuteDate = DateTime.Now;
            using (var context = new SQLServerDBContext())
            {
                context.Objectives.Update(objective);
                context.SaveChangesAsync();

            }
            Debug.WriteLine("Задача выполнена");
        }
    }
}
