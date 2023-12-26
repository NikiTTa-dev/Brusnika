using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Positions.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.AddPosition;

public class AddPositionCommandHandler : IRequestHandler<AddPositionCommand, ErrorOr<PositionSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public AddPositionCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<PositionSuccessCommandResult>> Handle(AddPositionCommand request, CancellationToken cancellationToken)
    {
        var parent = await _groupRepository.FindOneAsync(GroupId.Create(request.GroupId));
        parent.AddPosition(PositionId.Create(request.PositionId));
        await _groupRepository.UpdateOneAsync(parent);
        await _groupRepository.PublishDomainEvents();

        return new PositionSuccessCommandResult();
    }
}