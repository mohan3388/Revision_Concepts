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
    }
}
