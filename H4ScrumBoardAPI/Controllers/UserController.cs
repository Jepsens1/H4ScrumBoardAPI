using H4ScrumBoardAPI.Managers;
using H4ScrumBoardAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace H4ScrumBoardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserManager _manager = new UserManager(new CryptoService());
        [Route("[action]")]
        [HttpPost]
        public IActionResult RegisterUser(string username, string password)
        {
            try
            {
                return Ok(_manager.RegisterUser(username, password));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                return Ok(_manager.Login(username, password));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
