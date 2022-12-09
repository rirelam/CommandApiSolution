using AutoMapper;
using CommandApi.Data;
using CommandApi.Dtos;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace CommandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandController : ControllerBase
{
    //Add the following code to our class
    private readonly ICommandApiRepo _repository;
    private readonly IMapper _mapper;
   
    public CommandController(ICommandApiRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
        var commandItems = _repository.GetAllCommands();
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var commandItem = _repository.GetCommandById(id);
        if (commandItem == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
        var commandModel = _mapper.Map<Command>(commandCreateDto);

        _repository.CreateCommand(commandModel);
        _repository.SaveChanges();

        var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
        return CreatedAtRoute($"GetCommandById", new { commandReadDto.Id }, commandReadDto);
    }
}