using System.Collections.Generic;
using System.Linq;
using RestApi_Demo.Models;
using RestApi_Demo.Models.Context;

namespace RestApi_Demo.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c=>c.Id == id);
        }
    }
}