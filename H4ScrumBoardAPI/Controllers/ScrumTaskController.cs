using H4ScrumBoardAPI.Managers;
using H4ScrumBoardAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace H4ScrumBoardAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ScrumTaskController : Controller
    {
        ScrumManager _ScrumManager;
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetScrumTasks()
        {
            try
            {
                _ScrumManager = new ScrumManager();
                return Ok(_ScrumManager.GetScrumTasks());
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            } 
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetScrumTaskById(int id)
        {
            try
            {
                _ScrumManager = new ScrumManager();
                return Ok(_ScrumManager.GetScrumTaskByID(id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult CreateNewScrumTask(ScrumTask task)
        {
            try
            {
                _ScrumManager = new ScrumManager();
                return Ok(_ScrumManager.CreateNewScrumTask(task));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateScrumTask(ScrumTask task)
        {
            try
            {
                _ScrumManager = new ScrumManager();
                return Ok(_ScrumManager.UpdateScrumTask(task));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteScrumTask(int id)
        {
            try
            {
                _ScrumManager = new ScrumManager();
                return Ok(_ScrumManager.DeleteScrumTask(id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}
