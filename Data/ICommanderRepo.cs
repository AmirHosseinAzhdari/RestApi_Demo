using System.Collections.Generic;
using RestApi_Demo.Models;

namespace RestApi_Demo.Data
{
    public interface ICommanderRepo
    {
         IEnumerable<Command> GetAllCommands();
         Command GetCommandById(int id);
    }
}