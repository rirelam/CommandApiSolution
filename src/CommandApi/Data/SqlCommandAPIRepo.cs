
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
        if (cmd == null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }
        _context.CommandItems?.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
        if (cmd == null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }
        _context.CommandItems?.Remove(cmd);
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
        return _context.SaveChanges() >= 0;
    }

    public void UpdateCommand(Command cmd)
    {
        //We don't need to do anything here
    }
}
