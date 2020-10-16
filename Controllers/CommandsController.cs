using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetCommandById")]
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

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _commanderRepo.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();

            _mapper.Map(commandUpdateDto , commandModelFromRepo);
            _commanderRepo.UpdateCommand(commandModelFromRepo);
            _commanderRepo.SaveChanges();

           var commandReadDto = _mapper.Map<CommandReadDto>(commandModelFromRepo);

            return Ok(commandReadDto);
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepo = _commanderRepo.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _commanderRepo.UpdateCommand(commandModelFromRepo);
            _commanderRepo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModelFromRepo);

            return Ok(commandReadDto);
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _commanderRepo.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();

            _commanderRepo.DeleteCommand(commandModelFromRepo);
            _commanderRepo.SaveChanges();

            return Ok("SUCCESS");
        }
    }
}