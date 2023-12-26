using Brusnika.Api.Controllers.Common;
using Brusnika.Application.Positions.Commands.AddPosition;
using Brusnika.Application.Positions.Commands.CreatePosition;
using Brusnika.Application.Positions.Commands.DeletePostion;
using Brusnika.Application.Positions.Commands.EditPosition;
using Brusnika.Application.Positions.Commands.RemovePosition;
using Brusnika.Contracts.Editing.ChildrenGroup.Responses;
using Brusnika.Contracts.Editing.Positions.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brusnika.Api.Controllers;

[Route("[controller]")]
public class PositionsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public PositionsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePosition(CreatePositionRequest request)
    {
        var command = _mapper.Map<CreatePositionCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(_mapper.Map<CreateChildGroupResponse>(result)),
            errors => Problem(errors));
    }

    [HttpPatch]
    public async Task<IActionResult> EditPosition(EditPositionRequest request)
    {
        var command = _mapper.Map<EditPositionCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));   
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePosition(DeletePositionRequest request)
    {
        var command = _mapper.Map<DeletePositionCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));   
    }
    
    [HttpPost("children")]
    public async Task<IActionResult> AddPosition(AddPositionToGroup request)
    {
        var command = _mapper.Map<AddPositionCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));
    }
    
    [HttpDelete("children")]
    public async Task<IActionResult> RemovePosition(RemovePositionFromGroup request)
    {
        var command = _mapper.Map<RemovePositionCommand>(request);
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            _ => Ok(),
            errors => Problem(errors));
    }
}