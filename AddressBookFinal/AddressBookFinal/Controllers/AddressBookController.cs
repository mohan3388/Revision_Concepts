using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AddressBookFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        public IAddressBookBL addressBL;
        public AddressBookController(IAddressBookBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost("create")]
        public IActionResult CreateAddressBook(AddressBookModel model)
        {
            try
            {
                var result = addressBL.CreateAddressBook(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addressbook created", data = result });
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
        [HttpGet("GetBook")]
        public IActionResult GetAddressBook()
        {
            try
            {
                var result = addressBL.GetAddressBook();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get All AddressBook", data = result });
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
        [HttpPut("Update")]
        public IActionResult UpdateAddressBook(long Id, AddressBookModel model)
        {
            try
            {
                //long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = addressBL.UpdateAddressBook(Id, model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "updated", data = result });
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
        [HttpDelete("delete")]
        public IActionResult DeleteAddressBook(long Id)
        {
            var result=addressBL.DeleteAddressBook(Id);
            if (result != null)
            {
                return Ok(new { success = true, message = "Deleted"});
            }
            else
            {
                return BadRequest(new { success = false, message = "failed" });
            }
        }
    }
}
