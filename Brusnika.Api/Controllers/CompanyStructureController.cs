using Brusnika.Api.Controllers.Common;
using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Position = Brusnika.Domain.PositionAggregate.Position;
using Group = Brusnika.Domain.GroupAggregate.Group;

namespace Brusnika.Api.Controllers;

[Route("[controller]")]
public class CompanyStructureController : ApiController
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


    [HttpGet("Mock")]
    public async Task<IActionResult> Mock()
    {
        var group = Group.Create("Group1", "category1");
        var group2 = Group.Create("Group2", "category1");
        var group3 = Group.Create("Group3", "category1");
        var group4 = Group.Create("Group4", "category1");
        var position = Position.Create("Position1", "type1", "workTyep1", "fname1", "lname1", "patronymic1");
        var position2 = Position.Create("Position2", "type2", "workTyep2", "fname2", "lname2", "patronymic2");
        await _positionRepository.InsertOneAsync(position);
        await _positionRepository.InsertOneAsync(position2);
        await _groupRepository.InsertOneAsync(group);
        await _groupRepository.InsertOneAsync(group2);
        await _groupRepository.InsertOneAsync(group3);
        await _groupRepository.InsertOneAsync(group4);
        group.AddPosition(position.Id);
        group.AddChildGroup(group2.Id);
        group2.AddPosition(position2.Id);
        group2.AddChildGroup(group3.Id);
        group2.AddChildGroup(group4.Id);

        await _groupRepository.UpdateOneAsync(group);
        await _groupRepository.UpdateOneAsync(group);
        await _groupRepository.UpdateOneAsync(group2);
        await _groupRepository.UpdateOneAsync(group3);
        await _groupRepository.UpdateOneAsync(group4);
        await _groupRepository.PublishDomainEvents();
        await _positionRepository.PublishDomainEvents();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> CompanyStructure()
    {
        var createResult = await _mediator.Send(new CompanyStructureQuery());

        return createResult.Match(
            result => Ok(_mapper.Map<CompanyStructureResponse>(result)),
            errors => Problem(errors));
    }
}