using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.UserModels
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; } // Plain password input from user
    }
}
