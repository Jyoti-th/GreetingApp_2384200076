using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        UserEntity SaveGreetings(string message);

        public UserEntity GetGreetingById(int id);

        public string GreetingMessage(string? firstName, string? lastName);

        public List<UserEntity> GetAllGreetings();

        public UserEntity UpdateGreeting(int id, string newMessage);
    }
}
