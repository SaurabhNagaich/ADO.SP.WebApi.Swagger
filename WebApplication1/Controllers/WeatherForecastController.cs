using Microsoft.AspNetCore.Mvc;

using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        [Route("getall")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(userRepository.GetAllUser());
        }

        [Route("RegisterUser")]
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            bool isUserRegistered = userRepository.InsertUser(user);
            return Ok(isUserRegistered);

        }

    }
    
}