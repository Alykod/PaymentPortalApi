using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Models;
using PaymentApi.Services;

namespace PaymentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;


        public UserController(UserService userService) => _userService = userService;




        // GET api/values
        [HttpGet]
        public ActionResult<List<User>> Get() => _userService.Get();

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }


        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id =  user.Id.ToString() }, user);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if(user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }
            _userService.Remove(user.Id);
            return NoContent();
        }
      
    }
}
