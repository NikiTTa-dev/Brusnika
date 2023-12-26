using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Positions.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Positions.Commands.RemovePosition;

public class RemovePositionCommandHandler : IRequestHandler<RemovePositionCommand, ErrorOr<PositionSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public RemovePositionCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<PositionSuccessCommandResult>> Handle(RemovePositionCommand request, CancellationToken cancellationToken)
    {
        var parentGroup = await _groupRepository.FindOneAsync(GroupId.Create(request.GroupId));
        parentGroup.RemovePosition(PositionId.Create(request.PositionId));

        await _groupRepository.UpdateOneAsync(parentGroup);
        await _groupRepository.PublishDomainEvents();

        return new PositionSuccessCommandResult();
    }
}