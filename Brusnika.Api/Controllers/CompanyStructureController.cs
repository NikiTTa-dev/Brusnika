using Brusnika.Api.Controllers.Common;
using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Position = Brusnika.Domain.PositionAggregate.Position;
using Group = Brusnika.Domain.GroupAggregate.Group;

namespace Brusnika.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyStructureController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IPositionRepository _positionRepository;
    private readonly IGroupRepository _groupRepository;

    public CompanyStructureController(
        IPositionRepository positionRepository,
        IGroupRepository groupRepository,
        IMapper mapper,
        IMediator mediator)
    {
        _positionRepository = positionRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
        _mediator = mediator;
    }


    [HttpGet("GetWeatherForecast2")]
    public async Task<IActionResult> Get2()
    {
        var group = Group.Create("Group1", "category1");
        var group2 = Group.Create("Group2", "category1");
        var position = Position.Create("Position1", "type1", "workTyep1", "fname1", "lname1", "patronymic1");
        var position2 = Position.Create("Position2", "type2", "workTyep2", "fname2", "lname2", "patronymic2");
        await _positionRepository.InsertOneAsync(position);
        await _positionRepository.InsertOneAsync(position2);
        await _groupRepository.InsertOneAsync(group2);
        var groups = await _groupRepository.AsQueryable.ToListAsync();
        group2 = groups.Last(g => g.Title == "Group2");
        var positions = await _positionRepository.AsQueryable.ToListAsync();
        position = positions.Last(g => g.Name == "Position1");
        position2 = positions.Last(g => g.Name == "Position2");
        group.AddPosition(position.Id);
        group.AddPosition(position2.Id);
        group.AddChildGroup(group2.Id);

        await _groupRepository.InsertOneAsync(group);
        await _groupRepository.PublishDomainEvents();
        await _positionRepository.PublishDomainEvents();
        group = await _groupRepository.AsQueryable.OrderByDescending(g => g.Id).FirstAsync(g => g.Title == "Group1");

        return Ok(group);
    }

    [HttpGet]
    public async Task<IActionResult> CompanyStructure([FromQuery] CompanyStructureRequest request)
    {
        var command = _mapper.Map<CompanyStructureQuery>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(_mapper.Map<CompanyStructureResponse>(result)),
            errors => new OkObjectResult("error"));
    }
}