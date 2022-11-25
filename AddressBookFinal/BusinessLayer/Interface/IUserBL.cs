using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public RegisterModel userRegistration(RegisterModel model);
        public string UserLogin(LoginModel userLogin);
        public string ForgetPassword(string Email);
        public bool ResetPassword(string Email, ResetPasswordModel resetModel);
    }
}
