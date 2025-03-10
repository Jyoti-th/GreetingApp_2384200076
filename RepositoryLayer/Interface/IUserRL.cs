using ModelLayer.Model.UserModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserDetailsEntity Register(RegisterModel model);  // ✅ Database me user save karega
        UserDetailsEntity Login(LoginModel model);  // ✅ Login ke liye user check karega
        //string GeneratePasswordResetToken(string email);
        //bool ResetPassword(ResetPasswordModel model);
    }
}
