using Microsoft.AspNetCore.Mvc;
using RestApi_Demo.Data;

namespace RestApi_demo.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;

        public CommandsController(ICommanderRepo commanderRepo)
        {
            _commanderRepo = commanderRepo;
        }

        //Get api/commands
        [HttpGet]
        public IActionResult GetAllCommands(){
            var comandsList = _commanderRepo.GetAllCommands();

            return Ok(comandsList);
        }

        //Get api/commands/5
        [HttpGet("{id}")]
         public IActionResult GetCommandById(int id){
            var command = _commanderRepo.GetCommandById(id);

            return Ok(command);
        }
    }
}