using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL userBL;
      
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
           
        }
        [HttpPost("Register")]
        public IActionResult userRegister(RegisterModel model)
        {
            try
            {
                var result = userBL.userRegistration(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registered", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(LoginModel model)
        {
            try
            {
                var result = userBL.UserLogin(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "login successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("Forgetpass")]
        public IActionResult ForgetPassword(string Email)
        {
            try
            {
                var result = userBL.ForgetPassword(Email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "sent successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("ResetPass")]
        public IActionResult ResetPassword(string Email, ResetPasswordModel resetModel)
        {
            try
            {
                var result = userBL.ResetPassword(Email,resetModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "reset pass successfully"});
                }
                else
                {
                    return BadRequest(new { success = false, message = "failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
      
    }
}
