
using CommandApi.Models;

namespace CommandApi.Data;

public class SqlCommandApiRepo : ICommandApiRepo
{
    private readonly CommandContext _context;
    public SqlCommandApiRepo(CommandContext context)
    {
        _context = context;
    }

    public void CreateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command>? GetAllCommands()
    {
        return _context.CommandItems?.ToList();
    }

    public Command? GetCommandById(int id)
    {
        return _context.CommandItems?.FirstOrDefault(c => c.Id == id);
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }
}
