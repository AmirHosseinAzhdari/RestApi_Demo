using Microsoft.AspNetCore.Mvc;
using RestApi_Demo.Data;

namespace RestApi_demo.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //Get api/commands
        [HttpGet]
        public IActionResult GetAllCommands(){
            var comandsList = _repository.GetAppCommands();

            return Ok(comandsList);
        }

        //Get api/commands/5
        [HttpGet("{id}")]
         public IActionResult GetCommandById(int id){
            var command = _repository.GetCommandById(id);

            return Ok(command);
        }
    }
}