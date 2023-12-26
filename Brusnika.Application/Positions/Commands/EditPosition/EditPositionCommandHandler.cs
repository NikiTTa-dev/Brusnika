using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Positions.Common;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.EditPosition;

public class EditPositionCommandHandler : IRequestHandler<EditPositionCommand, ErrorOr<PositionSuccessCommandResult>>
{
    private readonly IPositionRepository _positionRepository;

    public EditPositionCommandHandler(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }
    
    public async Task<ErrorOr<PositionSuccessCommandResult>> Handle(EditPositionCommand request, CancellationToken cancellationToken)
    {
        var group = await _positionRepository.FindOneAsync(PositionId.Create(request.Id));
        group.UpdateFields(request.RoleName, request.Type, request.WorkType, request.FirstName, request.LastName, request.Patronymic);
        await _positionRepository.UpdateOneAsync(group);
        await _positionRepository.PublishDomainEvents();

        return new PositionSuccessCommandResult();
    }
}