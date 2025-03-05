using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        HelloGreetingContext _dbContext;

        public GreetingRL(HelloGreetingContext dbContext)
        {
            _dbContext = dbContext;
        }

        //UC7 method to update database
        public UserEntity UpdateGreeting(int id, string newMessage)
        {
            var greeting = _dbContext.Greetings.FirstOrDefault(g => g.Id == id);

            if (greeting != null)
            {
                greeting.Message = newMessage; 
                _dbContext.SaveChanges(); 
                return greeting; 
            }

            return null; 
        }




        //UC6 method To Get All messages
        public List<UserEntity> GetAllGreetings()
        {
            var result = _dbContext.Greetings.ToList();
            return result ?? new List<UserEntity>();
        }

        public UserEntity SaveGreetings(string message)
        {
            var greeting = new UserEntity { Message = message };
            _dbContext.Greetings.Add(greeting);
            _dbContext.SaveChanges();
            return greeting;  
        }

        public UserEntity GetGreetingById(int id)
        {
            return _dbContext.Greetings.FirstOrDefault(g => g.Id == id);
        }

    }
}
