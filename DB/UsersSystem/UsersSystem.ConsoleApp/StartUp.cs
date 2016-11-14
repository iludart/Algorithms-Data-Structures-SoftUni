using System;
using System.Data.Entity.Validation;
using UsersSystem.Data;
using UsersSystem.Models;

namespace UsersSystem.ConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                UsersDbContext db = new UsersDbContext();

                User user = new User()
                {
                    Username = "Pesho",
                    Password = "aA#123",
                    Email = "pesho@abv.bg",
                    Age = 2,
                    RegisteredOn = DateTime.Now,
                    LastTimeLoggedIn = DateTime.Now,
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eValidationResult in e.EntityValidationErrors)
                {
                    foreach (var error in eValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            
        }
    }
}
