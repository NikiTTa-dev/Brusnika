using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Position = Brusnika.Domain.PositionAggregate.Position;

namespace Brusnika.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyStructureController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IPositionRepository _positionRepository;
    private readonly IGroupRepository _groupRepository;
    
    public CompanyStructureController(
        IPositionRepository positionRepository, 
        IGroupRepository groupRepository,
        IMapper mapper,
        ISender mediator)
    {
        _positionRepository = positionRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    
    [HttpGet("GetWeatherForecast2")]
    public async Task<IActionResult> Get2()
    {
        var group = Group.Create("Group1");
        var group2 = Group.Create("Group2");
        var position = Position.Create("Position1");
        var position2 = Position.Create("Position2");
        await _positionRepository.InsertOneAsync(position);
        await _positionRepository.InsertOneAsync(position2);
        await _groupRepository.InsertOneAsync(group2);
        var groups = await _groupRepository.AsQueryable.ToListAsync();
        group2 = groups.Last(g => g.GroupName == "Group2");
        var positions = await _positionRepository.AsQueryable.ToListAsync();
        position = positions.Last(g => g.Name == "Position1");
        position2 = positions.Last(g => g.Name == "Position2");
        group.AddPosition(position.Id!);
        group.AddPosition(position2.Id!);
        group.AddGroup(group2.Id!);
        
        await _groupRepository.InsertOneAsync(group);
        group = await _groupRepository.AsQueryable.OrderByDescending(g => g.Id).FirstAsync(g => g.GroupName == "Group1");
        
        return Ok(group);
    }

    [HttpGet]
    public async Task<IActionResult> CompanyStructure([FromQuery]CompanyStructureRequest request)
    {
        var command = _mapper.Map<CompanyStructureQuery>(request);
        var createResult = await _mediator.Send(command);
        
        return createResult.Match(
            result => Ok(_mapper.Map<CompanyStructureResponse>(result)),
            errors => new OkObjectResult("error"));
    }
}
