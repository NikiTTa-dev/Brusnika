using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Groups.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.AddGroup;

public class AddGroupCommandHandler : IRequestHandler<AddGroupCommand, ErrorOr<GroupSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public AddGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<GroupSuccessCommandResult>> Handle(AddGroupCommand request, CancellationToken cancellationToken)
    {
        var parent = await _groupRepository.FindOneAsync(GroupId.Create(request.ParentId));
        parent.AddChildGroup(GroupId.Create(request.ChildId));
        await _groupRepository.UpdateOneAsync(parent);
        await _groupRepository.PublishDomainEvents();

        return new GroupSuccessCommandResult();
    }
}