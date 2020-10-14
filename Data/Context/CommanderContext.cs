using Microsoft.EntityFrameworkCore;
using RestApi_Demo.Models;

namespace RestApi_Demo.Models.Context
{
    public class CommanderContext:DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options):base(options)
        {
        }

        public DbSet<Command> Commands {get;set;}
    }
}