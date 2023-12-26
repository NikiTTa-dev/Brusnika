using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Positions.Common;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.DeletePostion;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, ErrorOr<PositionSuccessCommandResult>>
{
    private readonly IPositionRepository _positionRepository;

    public DeletePositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }
    
    public async Task<ErrorOr<PositionSuccessCommandResult>> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        await _positionRepository.DeleteAsync(PositionId.Create(request.PositionId));

        return new PositionSuccessCommandResult();
    }
}