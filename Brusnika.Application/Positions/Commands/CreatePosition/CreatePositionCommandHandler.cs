using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.PositionAggregate;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.CreatePosition;

public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, ErrorOr<CreatePositionCommandResult>>
{
    private readonly IPositionRepository _positionRepository;

    public CreatePositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }
    
    public async Task<ErrorOr<CreatePositionCommandResult>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var group = Position.Create(
            request.RoleName,
            request.Type,
            request.WorkType,
            request.FirstName,
            request.LastName,
            request.Patronymic);
        await _positionRepository.InsertOneAsync(group);
        await _positionRepository.PublishDomainEvents();

        return new CreatePositionCommandResult(group.Id.Value);
    }
}