using System.Collections.Generic;
using RestApi_Demo.Models;

namespace RestApi_Demo.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
         IEnumerable<Command> GetAllCommands();
         Command GetCommandById(int id);
         void CreateCommand(Command cmd);
         void UpdateCommand(Command cmd);
         void DeleteCommand(Command cmd);
    }
}