﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }


        //UC8 method
        public bool DeleteGreeting(int id)
        {
            var result = _greetingRL.DeleteGreeting(id);
            return result;
        }

        //UC7  method
        public UserEntity UpdateGreeting(int id, string newMessage)
        {
            var result = _greetingRL.UpdateGreeting(id, newMessage);
            return result;
        }



        //UC6 method 
        public List<UserEntity> GetAllGreetings()
        {
            var result =  _greetingRL.GetAllGreetings();
            return result;
        }

        //UC5 method 
        public UserEntity GetGreetingById(int id)
        {
           var result = _greetingRL.GetGreetingById(id);
            return result;
        }

        //UC4 method
        public UserEntity SaveGreetings(string message)
        {
            var result = _greetingRL.SaveGreetings(message);
            return result;
        }


        public string GreetingMessage(string? firstName, string? lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return "Hello " + firstName + " " + lastName;
            }

            else if (!string.IsNullOrEmpty(firstName))
            {
                return "Hello " + firstName;
            }
            else if (!string.IsNullOrEmpty(lastName))
            {
                return "Hello " + lastName;
            }
            else
            {
                return "Hello World!";
            }
                    
        }
    }
}
