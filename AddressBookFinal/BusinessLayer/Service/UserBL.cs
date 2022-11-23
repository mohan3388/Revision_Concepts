using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL:IUserBL
    {
        public IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public RegisterModel userRegistration(RegisterModel model)
        {
            try
            {
                return userRL.userRegistration(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
