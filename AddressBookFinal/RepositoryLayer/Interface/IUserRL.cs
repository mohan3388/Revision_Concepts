using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public RegisterModel userRegistration(RegisterModel userRegister);
        public string UserLogin(LoginModel userLogin);
        public string ForgetPassword(string Email);
    }
}
