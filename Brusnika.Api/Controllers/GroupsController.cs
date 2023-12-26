using Brusnika.Api.Controllers.Common;
using Brusnika.Application.Groups.Commands.AddGroup;
using Brusnika.Application.Groups.Commands.CreateGroup;
using Brusnika.Application.Groups.Commands.DeleteGroup;
using Brusnika.Application.Groups.Commands.EditGroup;
using Brusnika.Application.Groups.Commands.RemoveGroup;
using Brusnika.Contracts.Editing.ChildrenGroup.Requests;
using Brusnika.Contracts.Editing.ChildrenGroup.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brusnika.Api.Controllers;

[Route("[controller]")]
public class GroupsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public GroupsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup(CreateChildGroupRequest request)
    {
        var command = _mapper.Map<CreateGroupCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(_mapper.Map<CreateChildGroupResponse>(result)),
            errors => Problem(errors));
    }

    [HttpPatch]
    public async Task<IActionResult> EditGroup(EditChildGroupRequest request)
    {
        var command = _mapper.Map<EditGroupCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));   
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteGroup(DeleteChildGroupRequest request)
    {
        var command = _mapper.Map<DeleteGroupCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));   
    }
    
    [HttpPost("children")]
    public async Task<IActionResult> AddGroup(AddChildGroupRequest request)
    {
        var command = _mapper.Map<AddGroupCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));
    }
    
    [HttpDelete("children")]
    public async Task<IActionResult> RemoveGroup(RemoveChildFromParentsRequest request)
    {
        var command = _mapper.Map<RemoveGroupCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));
    }
}