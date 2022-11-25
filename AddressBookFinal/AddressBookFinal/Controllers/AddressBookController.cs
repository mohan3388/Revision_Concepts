using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        public IAddressBookBL addressBL;
        private readonly IDistributedCache distributedCache;
        private readonly IMemoryCache memoryCache;
        private readonly string ConnectionString;
        private readonly ILogger<AddressBookController> logger;
        public AddressBookController(IAddressBookBL addressBL, IDistributedCache distributedCache, IMemoryCache memoryCache,IConfiguration configuration, ILogger<AddressBookController> logger)
        {
            this.addressBL = addressBL;
            this.distributedCache=distributedCache;
            this.memoryCache=memoryCache;
            this.logger=logger;

            this.ConnectionString = configuration.GetConnectionString("TestDb");
        }
        [HttpPost("create")]
        public IActionResult CreateAddressBook(AddressBookModel model)
        {
            try
            {
                var result = addressBL.CreateAddressBook(model);
                if (result != null)
                {
                    logger.LogInformation("addressbook Added Successfully");
                    return Ok(new { success = true, message = "addressbook created", data = result });
                }
                else
                {
                    logger.LogInformation("Failed to Add");
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
                    logger.LogInformation("data retrieved");
                    return Ok(new { success = true, message = "Get All AddressBook", data = result });
                }
                else
                {
                    logger.LogInformation("data retriev failed");
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
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllNoteUsingRedisCache()
        {
            var cacheKey = "LabelList";
            string serializedNoteList;
            var NoteList = new List<AddressBookModel>();
            var redisNoteList = await distributedCache.GetAsync(cacheKey);
            if (redisNoteList != null)
            {
                serializedNoteList = Encoding.UTF8.GetString(redisNoteList);
                NoteList = JsonConvert.DeserializeObject<List<AddressBookModel>>(serializedNoteList);
            }
            else
            {
                Console.WriteLine("not found");
                //NoteList = AddressBookModel;
                //serializedNoteList = JsonConvert.SerializeObject(NoteList);
                //redisNoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                //var options = new DistributedCacheEntryOptions()
                //    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                //    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                //await distributedCache.SetAsync(cacheKey, redisNoteList, options);
            }
            return Ok(NoteList);
        }
    }
}
