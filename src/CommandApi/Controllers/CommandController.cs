using CommandApi.Data;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace CommandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandController : ControllerBase
{
    //Add the following code to our class
    private readonly ICommandApiRepo _repository;
    public CommandController(ICommandApiRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
        var commandItems = _repository.GetAllCommands();
        return Ok(commandItems);
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var commandItem = _repository.GetCommandById(id);
        if (commandItem == null)
        {
            return NotFound();
        }
        return Ok(commandItem);
    }
}