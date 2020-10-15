using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi_Demo.Data;
using RestApi_Demo.Dtos;
using RestApi_Demo.Models;

namespace RestApi_demo.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _commanderRepo = commanderRepo;
            _mapper = mapper;
        }

        //Get api/commands
        [HttpGet]
        public IActionResult GetAllCommands()
        {
            var commandsList = _commanderRepo.GetAllCommands();
            var commandsDto = _mapper.Map<IEnumerable<CommandReadDto>>(commandsList);

            return Ok(commandsDto);
        }

        //Get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult GetCommandById(int id)
        {
            var command = _commanderRepo.GetCommandById(id);

            if(command != null)
            {
                var commanddto = _mapper.Map<CommandReadDto>(command);
                return Ok(commanddto);
            }

            return NotFound();
        }

        //Post api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commanderRepo.CreateCommand(commandModel);
            _commanderRepo.SaveChanges();

            return Ok(commandModel);
        }
    }
}