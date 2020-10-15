using AutoMapper;
using RestApi_Demo.Dtos;
using RestApi_Demo.Models;

namespace RestApi_Demo.Profiles {
    public class CommandsProfile : Profile {
        public CommandsProfile () {
            // Source => Target
            CreateMap<Command, CommandReadDto> ();
            CreateMap<CommandCreateDto, Command> ();
        }
    }
}