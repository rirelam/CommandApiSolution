using AutoMapper;
using CommandApi.Models;
using CommandApi.Dtos;

namespace CommandApi.Profiles;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<Command, CommandReadDto>();
    }
}
