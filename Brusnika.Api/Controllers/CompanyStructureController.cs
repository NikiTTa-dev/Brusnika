using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Brusnika.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyStructureController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CompanyStructureController(
        IMapper mapper,
        ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
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
